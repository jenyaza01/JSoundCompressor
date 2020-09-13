using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NAudio.Utils;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using sts = JSoundCompressor.Settings;

namespace JSoundCompressor
{
    public enum TriState
    {
        False, True, Error
    }

    public enum Channels
    {
        L_Only, L_Mono, Stereo, R_Mono, R_Only, Mono
    }

    public partial class FormMain : Form
    {
        private const float SCALE = 1 / 32768f;
        private const float SCALE2 = SCALE * SCALE;
        private const int DROP_SPEED = 6;

        public FormMain(string[] args)
        {
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            InitializeComponent();
            sts.args = args;
        }

        private WaveInEvent waveInMain, waveInSecond;
        private WaveOut waveOutMain, waveOutSecond;

        private BufferedWaveProvider buffer11, buffer21, buffer22;

        private MixingSampleProvider mixer; // mix buffer11 & buffer21 into waveOutMain

        private bool waveOutMainActive = false;
        private bool waveOutSecondActive = false;

        private float db2_inputRaw = 0f;
        private float db_inputPeak = 0;
        private float db_inputFlat = 0;
        private float db_inputAmp = 0;
        private float db_result = 0;
        private float db_resultLimited = 0;
        private float db_delta = -0;
        private float db_deltaFloat = 0.0f;
        private float cmp_AttackSpeed = 3;
        private float cmp_RelesSpeed = 4;
        private float cmp_preAmp = -0;
        private float cmp_ratio = 1.5f;
        private float cmp_treshold = -18;
        private float cmp_nratio = 1.0f;
        private float cmp_ntreshold = -40;
        private float cmp_postAmp = -0;
        private float cmp_limitSlow = -4;
        private float cmp_limitFast = -4;

        private Channels cmp_channelsMain = Channels.Stereo;
        private Channels cmp_channelsSecond = Channels.Stereo;

        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadDevices();

            cbChannelsMain.DataSource = Enum.GetNames(typeof(Channels));
            cbChannelsMain.SelectedIndex = 2;    //stereo
            cbChannelsSecond.DataSource = Enum.GetNames(typeof(Channels));
            cbChannelsSecond.SelectedIndex = 2;

            pMix.SuspendLayout();
            notifyIcon1.Icon = Icon;

            if (tryParseArgs(sts.args))
                bPlayStop_Click(null, null);

            ThreadPool.SetMaxThreads(64, 16);
        }

        private bool tryParseArgs(string[] args)
        {
            int l = args.Length;
            if (l < 1)
                return false;


            TriState willPlay = TriState.False;
            int c = -1;
            while (++c < l)
            {

                if (sts.args[c].Contains("-load"))
                {
                    if (sts.args[++c].Contains("jscp"))
                    {
                        if (File.Exists(sts.args[c]))
                            loadPresetFile(sts.args[c]);
                        else
                            willPlay = TriState.Error;
                    }
                    else
                        willPlay = TriState.Error;
                    continue;
                }


                if (sts.args[c].Contains("-start"))
                {
                    if (willPlay == TriState.False)
                        willPlay = TriState.True;
                    continue;
                }

                if (sts.args[c].Contains("-input"))
                {
                    int i = cbInput1.FindString(sts.args[++c]);
                    if (i > -1)
                        cbInput1.SelectedIndex = i;
                    else
                    {
                        MessageBox.Show("Not found input device with name \"" + sts.args[c] + "\"");
                        willPlay = TriState.Error;
                    }
                    continue;
                }

                if (sts.args[c].Contains("-output"))
                {
                    int i = cbOutputMain.FindString(sts.args[++c]);
                    if (i > -1)
                        cbOutputMain.SelectedIndex = i;
                    else
                    {
                        MessageBox.Show("Not found output device with name \"" + sts.args[c] + "\"");
                        willPlay = TriState.Error;
                    }
                    continue;
                }

                willPlay = TriState.Error;
            }
            return (willPlay == TriState.True);

        }

        private void ReloadDevices()
        {
            if (sts.secondInputEnabled)
            {
                panelCompressor.Top = 86;
                cbInput2.Visible = true;
                labelSecondInput.Visible = true;
                cbChannelsSecond.Visible = true;
            }
            else
            {
                panelCompressor.Top = 55;
                cbInput2.Visible = false;
                labelSecondInput.Visible = false;
                cbChannelsSecond.Visible = false;
            }

            Height = sts.secondOutputEnabled
            ? panelCompressor.Top + panelCompressor.Height + 31
            : panelCompressor.Top + panelCompressor.Height;

            cbInput1.Items.Clear();
            for (int n = -1; n < WaveIn.DeviceCount; n++)
                cbInput1.Items.Add(WaveIn.GetCapabilities(n).ProductName);
            cbInput1.SelectedIndex = 0;


            if (sts.secondInputEnabled)
            {
                cbInput2.Items.Clear();
                for (int n = 0; n < WaveIn.DeviceCount; n++)
                    cbInput2.Items.Add(WaveIn.GetCapabilities(n).ProductName);
                cbInput2.Items.Add(" - NO input -");
                cbInput2.SelectedIndex = 0;
            }

            cbOutputMain.Items.Clear();
            for (int n = -1; n < WaveOut.DeviceCount; n++)
                cbOutputMain.Items.Add(WaveOut.GetCapabilities(n).ProductName);
            cbOutputMain.Items.Add(" - NO out -");
            cbOutputMain.SelectedIndex = 0;

            if (sts.secondOutputEnabled)
            {
                cbOutput2.Items.Clear();
                for (int n = 0; n < WaveOut.DeviceCount; n++)
                    cbOutput2.Items.Add(WaveOut.GetCapabilities(n).ProductName);
                cbOutput2.Items.Add(" - NO out -");
                cbOutput2.SelectedIndex = 0;
            }
        }


        private void waveInMain_DataAvailable(object sender, WaveInEventArgs e) =>
            ThreadPool.QueueUserWorkItem(waveInMain_DataAvailableHandler, e);

        private int WaveIn_callNumber = 0;
        private void waveInMain_DataAvailableHandler(object o)
        {
            WaveInEventArgs e = (WaveInEventArgs)o;
            int bytesRecorded = e.BytesRecorded;
            int shortsRecorded = bytesRecorded / 2;

            short[] audioDataSamples = new short[shortsRecorded];
            Buffer.BlockCopy(e.Buffer, 0, audioDataSamples, 0, bytesRecorded);

            float db_inputRaw = 0f;

            if (cbCompActive.Checked)
            {
                float tempf;
                float maxf = 0f;
                for (int index = 0; index < shortsRecorded; index++)
                {
                    tempf = abs(audioDataSamples[index]);
                    if (maxf < tempf)
                        maxf = tempf;
                    db_inputRaw += tempf * tempf * SCALE2;
                }

                db_inputRaw = (float)Decibels.LinearToDecibels(Math.Sqrt(db_inputRaw / shortsRecorded));
                db_inputPeak = (float)(Decibels.LinearToDecibels(maxf / short.MaxValue));

                if (float.IsNaN(db_inputRaw))
                    db_inputRaw = 0;


                // applying smoothing
                db_inputFlat = db_inputFlat < db_inputRaw
                    ? max((db_inputFlat * cmp_AttackSpeed + db_inputRaw) / (cmp_AttackSpeed + 1), -90f)
                    : max((db_inputFlat * cmp_RelesSpeed + db_inputRaw) / (cmp_RelesSpeed + 1), -90f);


                // applying preamp

                db_inputAmp = db_inputFlat + cmp_preAmp;

                if (db_inputRaw + cmp_preAmp >= -3.11f)
                {
                    tbCompPreamp.Value = (int)max(tbCompPreamp.Value - 1, tbCompPreamp.Minimum);
                    tbCompPostAmp.Value = (int)min(tbCompPostAmp.Value + 2, tbCompPostAmp.Maximum);
                }


                //  trackBar1.Value = (int)max((db_inputAmp + 45) * 50, 1);

                //applying compressor or noise gate

                if (db_inputAmp > cmp_treshold)
                    db_result = (cmp_treshold + (db_inputAmp - cmp_treshold) / cmp_ratio);
                else if (db_inputAmp < cmp_ntreshold)
                    db_result = (cmp_ntreshold - (cmp_ntreshold - db_inputAmp) / cmp_nratio);
                else
                    db_result = db_inputAmp;




                // applying postAmp and slow limiter
                db_resultLimited = min(db_result + cmp_postAmp, cmp_limitSlow);


                db_delta = (db_resultLimited - db_inputFlat);

                // applying fast limiter
                if (db_inputRaw + db_delta > cmp_limitFast)
                    db_delta -= db_inputRaw + db_delta - cmp_limitFast;

                float db_outPeak = (db_inputPeak + db_delta);

                if (db_outPeak >= -0.18f) //98%
                {
                    db_delta -= db_outPeak;
                    tbCompPostAmp.Value = (int)max(tbCompPostAmp.Value - 1, tbCompPostAmp.Minimum);
                }

                db_deltaFloat = (float)Decibels.DecibelsToLinear(db_delta);

                short temp;
                switch (cmp_channelsMain)
                {
                    case Channels.L_Only:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            audioDataSamples[index] = (short)(db_deltaFloat * audioDataSamples[index]);
                            audioDataSamples[++index] = 0;
                        }
                        break;

                    case Channels.L_Mono:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            temp = (short)(db_deltaFloat * audioDataSamples[index]);
                            audioDataSamples[index] = temp;
                            audioDataSamples[++index] = temp;
                        }
                        break;


                    case Channels.Stereo:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            audioDataSamples[index] = (short)(db_deltaFloat * audioDataSamples[index]);
                        }
                        break;

                    case Channels.R_Mono:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            temp = (short)(db_deltaFloat * audioDataSamples[index + 1]);
                            audioDataSamples[index] = temp;
                            audioDataSamples[++index] = temp;

                        }
                        break;
                    case Channels.R_Only:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            audioDataSamples[index] = 0;
                            audioDataSamples[++index] = (short)(db_deltaFloat * audioDataSamples[index]);
                        }
                        break;
                    case Channels.Mono:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            temp = (short)clamp(db_deltaFloat * (audioDataSamples[index] + audioDataSamples[index + 1]) * 0.7f, short.MaxValue);
                            audioDataSamples[index] = temp;
                            audioDataSamples[++index] = temp;
                        }
                        break;
                }

                Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, bytesRecorded);

                buffer11.AddSamples(e.Buffer, 0, bytesRecorded);

                db2_inputRaw = db_inputRaw;

                if (visualise)
                    if (WindowState != FormWindowState.Minimized)
                    {
                        Invoke(new Action(() =>
                        {


                            float output_width = min(304,
                                                    max((float)Decibels.DecibelsToLinear(db_outPeak) * 300,
                                                        pOutMain.Width - DROP_SPEED));
                            db_outPeak = (float)Decibels.LinearToDecibels(output_width / 300);

                            pInputRaw.Width = (int)max(maxf * 0.00915f, pInputRaw.Width - DROP_SPEED);
                            pInputFlat.Width = (int)(5 * db_inputFlat + 300);
                            pInputAmp.Width = (int)(5 * db_inputAmp + 300);

                            pOutRes.Width = (int)(5 * db_result + 300);
                            pOutAmp.Width = (int)(5 * db_resultLimited + 300);
                            pOutMain.Width = (int)(output_width);

                            if (db_outPeak > -0.01)
                                pOutMain.BackColor = Color.OrangeRed;
                            else if (db_outPeak > -1)
                                pOutMain.BackColor = Color.Gold;
                            else if (db_outPeak > -4)
                                pOutMain.BackColor = Color.Yellow;
                            else if (db_outPeak > -12)
                                pOutMain.BackColor = Color.GreenYellow;
                            else
                                pOutMain.BackColor = Color.LightGreen;

                            int delt = (int)clamp(5 * db_delta, 150);
                            panelDelta.Width = (int)(abs(delt) == 0 ? 1 : abs(delt) + 1);
                            panelDelta.Left = (delt > 0) ? 154 : 154 + delt;

                            pMix.PerformLayout();
                        }));
                    }

                if (WaveIn_callNumber == 5)
                    return;
                if (WaveIn_callNumber == 4)
                {
                    if (waveOutMainActive)
                    {
                        //  if (waveOutMain.PlaybackState != PlaybackState.Playing)
                        waveOutMain.Play();
                    }

                    if (waveOutSecondActive)
                    {
                        //if (waveOutSecond != null)
                        //   if (sts.secondOutputEnabled && waveOutSecond.PlaybackState != PlaybackState.Playing)
                        waveOutSecond.Play();
                    }
                }
                if (WaveIn_callNumber < 5)
                    WaveIn_callNumber++;
            }

            else // cmp disabled
            {


                float tempf;
                for (int index = 0; index < shortsRecorded; index++)
                {
                    tempf = abs(audioDataSamples[index]);
                    db_inputRaw += tempf * tempf * SCALE2;
                }

                db_inputRaw = (float)Decibels.LinearToDecibels(Math.Sqrt(db_inputRaw / shortsRecorded));

                if (float.IsNaN(db_inputRaw))
                    db_inputRaw = 0;

                db_inputFlat = max((db_inputFlat * 2 + db_inputRaw) * 0.333f, -90f);



                switch (cmp_channelsMain)
                {
                    case Channels.L_Only:
                        for (int index = 1; index < shortsRecorded; index += 2)
                        {
                            audioDataSamples[index] = 0;
                        }
                        Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, bytesRecorded);
                        buffer11.AddSamples(e.Buffer, 0, bytesRecorded);
                        break;

                    case Channels.L_Mono:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            audioDataSamples[index++] = audioDataSamples[index];
                        }
                        Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, bytesRecorded);
                        buffer11.AddSamples(e.Buffer, 0, bytesRecorded);
                        break;

                    case Channels.Stereo:
                        buffer11.AddSamples(e.Buffer, 0, bytesRecorded);
                        break;

                    case Channels.R_Mono:
                        for (int index = 1; index < shortsRecorded; index += 2)
                        {
                            audioDataSamples[index] = audioDataSamples[index - 1];
                        }
                        Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, bytesRecorded);
                        buffer11.AddSamples(e.Buffer, 0, bytesRecorded);
                        break;
                    case Channels.R_Only:
                        for (int index = 0; index < shortsRecorded; index += 2)
                        {
                            audioDataSamples[index] = 0;
                        }
                        Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, bytesRecorded);
                        buffer11.AddSamples(e.Buffer, 0, bytesRecorded);
                        break;
                    case Channels.Mono:
                        for (int index = 0; index < shortsRecorded; index++)
                        {
                            short temp = (short)clamp((audioDataSamples[index] + audioDataSamples[index + 1]) * 0.7f, short.MaxValue);
                            audioDataSamples[index] = temp;
                            audioDataSamples[++index] = temp;
                        }
                        Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, bytesRecorded);
                        buffer11.AddSamples(e.Buffer, 0, bytesRecorded);
                        break;
                }


                if (visualise)
                    if (WindowState != FormWindowState.Minimized)
                    {
                        Invoke(new Action(() =>
                      {
                          pInputRaw.Width = (int)(5 * db_inputRaw + 300);
                          pInputFlat.Width = (int)(5 * db_inputFlat + 300);

                          pMix.PerformLayout();
                      }));
                    }
            }
        }

        private void waveInSecond_DataAvailable(object sender, WaveInEventArgs e) =>
            ThreadPool.QueueUserWorkItem(waveInSecond_DataAvailableHandler, e);

        private void waveInSecond_DataAvailableHandler(object o)
        {
            WaveInEventArgs e = (WaveInEventArgs)o;
            if (sts.secondInputEnabled)
            {
                short temp;
                if (cmp_channelsSecond == Channels.L_Only)
                {
                    int shortsRecorded = e.BytesRecorded / 2;
                    short[] audioDataSamples = new short[shortsRecorded];
                    Buffer.BlockCopy(e.Buffer, 0, audioDataSamples, 0, e.BytesRecorded);
                    for (int index = 0; index < shortsRecorded; index++)
                    {
                        audioDataSamples[index] = (short)clamp(db_deltaFloat * audioDataSamples[index], short.MaxValue);
                        audioDataSamples[++index] = 0;
                    }
                    Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, e.BytesRecorded);
                    buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
                }
                else if (cmp_channelsSecond == Channels.L_Mono)
                {
                    int shortsRecorded = e.BytesRecorded / 2;
                    short[] audioDataSamples = new short[shortsRecorded];
                    Buffer.BlockCopy(e.Buffer, 0, audioDataSamples, 0, e.BytesRecorded);
                    for (int index = 0; index < shortsRecorded; index++)
                    {
                        temp = (short)clamp(db_deltaFloat * audioDataSamples[index], short.MaxValue);
                        audioDataSamples[index] = temp;
                        audioDataSamples[++index] = temp;
                    }
                    Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, e.BytesRecorded);
                    buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
                }
                else if (cmp_channelsSecond == Channels.Stereo)
                {
                    buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
                }
                else if (cmp_channelsSecond == Channels.R_Mono)
                {
                    int shortsRecorded = e.BytesRecorded / 2;
                    short[] audioDataSamples = new short[shortsRecorded];
                    Buffer.BlockCopy(e.Buffer, 0, audioDataSamples, 0, e.BytesRecorded);
                    for (int index = 0; index < shortsRecorded; index++)
                    {
                        temp = (short)clamp(db_deltaFloat * audioDataSamples[index + 1], short.MaxValue);
                        audioDataSamples[index] = temp;
                        audioDataSamples[++index] = temp;

                    }
                    Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, e.BytesRecorded);
                    buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
                }
                else if (cmp_channelsSecond == Channels.R_Only)
                {
                    int shortsRecorded = e.BytesRecorded / 2;
                    short[] audioDataSamples = new short[shortsRecorded];
                    Buffer.BlockCopy(e.Buffer, 0, audioDataSamples, 0, e.BytesRecorded);
                    for (int index = 0; index < shortsRecorded; index++)
                    {
                        audioDataSamples[index] = 0;
                        audioDataSamples[++index] = (short)clamp(db_deltaFloat * audioDataSamples[index], short.MaxValue);
                    }
                    Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, e.BytesRecorded);
                    buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
                }
                else if (cmp_channelsSecond == Channels.Mono)
                {
                    int shortsRecorded = e.BytesRecorded / 2;
                    short[] audioDataSamples = new short[shortsRecorded];
                    Buffer.BlockCopy(e.Buffer, 0, audioDataSamples, 0, e.BytesRecorded);
                    for (int index = 0; index < shortsRecorded; index++)
                    {
                        temp = (short)clamp(db_deltaFloat * (audioDataSamples[index] + audioDataSamples[index + 1] * 0.7f), short.MaxValue);
                        audioDataSamples[index] = temp;
                        audioDataSamples[++index] = temp;
                    }
                    Buffer.BlockCopy(audioDataSamples, 0, e.Buffer, 0, e.BytesRecorded);
                    buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
                }
            }

            if (sts.secondOutputEnabled)
                buffer22.AddSamples(e.Buffer, 0, e.BytesRecorded);
        }


        #region small functions

        private void write2bytes(ref byte[] bytes, int index, byte[] p)
        {
            bytes[index++] = p[0];
            bytes[index] = p[1];
        }

        private float abs(float a) => a < 0 ? -a : a;

        private float min(float a, float b) => (a < b) ? a : b;

        private float max(float a, float b) => (a > b) ? a : b;

        private float clamp(float number, float limit)
        {
            if (limit < 0)
                limit = -limit;
            if (number > limit)
                number = limit;
            if (number < -limit)
                number = -limit;
            return number;
        }
        #endregion


        #region App interface

        private void bTopMost_Click(object sender, EventArgs e) => TopMost = !TopMost;

        private void bTray_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void bMinimise_Click(object sender, EventArgs e) =>
        WindowState = FormWindowState.Minimized;

        private void bClose_Click(object sender, EventArgs e) => Application.Exit();


        private void bPlayStop_Click(object sender, EventArgs e)
        {
            if (bPlay.Text == "STOP")
            {
                Stop();
                bPlay.Text = "PLAY";
            }
            else
            {
                Play();
                bPlay.Text = "STOP";
            }

            WaveIn_callNumber = 0;
        }

        private void Play()
        {
            if (waveInMain != null)
            {
                buffer11 = new BufferedWaveProvider(new WaveFormat(sts.freq_int, 16, 2))
                {
                    DiscardOnBufferOverflow = true,
                    BufferDuration = TimeSpan.FromMilliseconds(sts.outputMS_int)
                };
                waveInMain.StartRecording();
            }

            if (sts.secondInputEnabled && waveInSecond != null)
            {
                buffer21 = new BufferedWaveProvider(new WaveFormat(sts.freq_int, 16, 2))
                {
                    DiscardOnBufferOverflow = true,
                    BufferDuration = TimeSpan.FromMilliseconds(sts.outputMS_int)
                };
                waveInSecond.StartRecording();

                if (sts.secondOutputEnabled)
                {
                    buffer22 = new BufferedWaveProvider(new WaveFormat(sts.freq_int, 16, 2))
                    {
                        DiscardOnBufferOverflow = true,
                        BufferDuration = TimeSpan.FromMilliseconds(sts.outputMS_int)
                    };
                }
            }

            mixer = buffer11 != null && buffer21 != null
                ? new MixingSampleProvider(new[] { buffer11.ToSampleProvider(), buffer21.ToSampleProvider() })
                : null;


            if (waveOutMainActive)
            {
                if (mixer != null)
                    waveOutMain.Init(mixer);
                else
                    waveOutMain.Init(buffer11.ToSampleProvider());
            }

            if (waveOutSecondActive)
            {
                if (waveOutSecond != null && sts.secondOutputEnabled)
                {
                    waveOutSecond.Init(buffer22.ToSampleProvider());
                }
            }

            bSettings.Enabled = false;
            cbInput1.Enabled = false;
            cbInput2.Enabled = false;
            cbOutputMain.Enabled = false;
            cbOutput2.Enabled = false;

            bSavePreset.Enabled = false;
            bLoadPreset.Enabled = cbCompActive.Checked || bSavePreset.Enabled;
        }

        private void Stop()
        {
            if (waveInMain != null)
                waveInMain.StopRecording();
            if (waveInSecond != null)
                waveInSecond.StopRecording();
            if (waveOutMain != null)
                waveOutMain.Stop();
            if (waveOutSecond != null)
                waveOutSecond.Stop();

            cbInput1.Enabled = true;
            cbInput2.Enabled = true;
            cbOutputMain.Enabled = true;
            cbOutput2.Enabled = true;
            bSettings.Enabled = true;

            bSavePreset.Enabled = true;
            bLoadPreset.Enabled = true;
        }

        private void bSettings_Click(object sender, EventArgs e)
        {
            using (FormSettings fs = new FormSettings())
            {
                sts.changed = false;
                Enabled = false;
                fs.ShowDialog();
                Enabled = true;
                if (sts.changed)
                    ReloadDevices();
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void ShowAbout() => MessageBox.Show(
        "VST-like compressor, but for Windows audio streams\n" +
        "Version 2 include repeaters, limiters and more\n\n" +
        "Author: Jenyaza01\njenyaza01@gmail.com\n\n" +
        "Powered by NAudio\ngithub.com/naudio/NAudio", "About");


        private void cbInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveInMain != null)
            {
                waveInMain.DataAvailable -= waveInMain_DataAvailable;
                //	waveIn1.StopRecording();
                waveInMain.Dispose();
            }

            waveInMain = new WaveInEvent() { DeviceNumber = cbInput1.SelectedIndex - 1 };
            waveInMain.WaveFormat = new WaveFormat(
            int.Parse(sts.freq), 16, 2);
            waveInMain.DataAvailable += waveInMain_DataAvailable;
            waveInMain.BufferMilliseconds = sts.inputMS_int;
        }

        private void cbOutputMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveOutMain != null)
            {
                waveOutMain.Stop();
                waveOutMain.Dispose();
            }

            if (cbOutputMain.Text.Contains("NO out"))
            {
                waveOutMainActive = false;
                return;
            }
            else
            {
                waveOutMainActive = true;
            }

            waveOutMain = new WaveOut() { DeviceNumber = cbOutputMain.SelectedIndex - 1 };
            waveOutMain.DesiredLatency = sts.outputMS_int;
            waveOutMain.NumberOfBuffers = waveOutMain.DesiredLatency / 9;
        }

        private void cbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveInSecond != null)
            {
                waveInSecond.DataAvailable -= waveInSecond_DataAvailable;
                waveInSecond.StopRecording();
                waveInSecond.Dispose();
            }
            if (cbInput2.Text.Contains("NO input"))
                return;

            waveInSecond = new WaveInEvent() { DeviceNumber = cbInput2.SelectedIndex };
            waveInSecond.WaveFormat = new WaveFormat(sts.freq_int, 16, 2);
            waveInSecond.DataAvailable += waveInSecond_DataAvailable;
            waveInSecond.BufferMilliseconds = sts.inputMS_int;
        }

        private void cbOutput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveOutSecond != null)
            {
                waveOutSecond.Stop();
                waveOutSecond.Dispose();
            }

            if (cbOutput2.Text.Contains("NO out"))
            { waveOutSecondActive = false; return; }
            else
                waveOutSecondActive = true;

            if (sts.secondOutputEnabled)
            {
                waveOutSecond = new WaveOut() { DeviceNumber = cbOutput2.SelectedIndex };
                waveOutSecond.DesiredLatency = sts.outputMS_int;
                waveOutSecond.NumberOfBuffers = waveOutSecond.DesiredLatency / 9;
            }
        }


        private void cbChannelsMain_IndexChanged(object sender, EventArgs e) =>
        cmp_channelsMain = (Channels)cbChannelsMain.SelectedIndex;

        private void cbChannelsSecond_IndexChanged(object sender, EventArgs e) =>
        cmp_channelsSecond = (Channels)(cbChannelsSecond.SelectedIndex);



        private bool visualise = true;
        private Thread t;
        private void button1_Click(object sender, EventArgs e)
        {
            visualise = !visualise;

            if (visualise)
            {
                button1.Text = "on";
                panelDelta.Visible = true;
                if (t != null)
                    t.Abort();
            }
            else
            {
                button1.Text = "<<";
                panelDelta.Visible = false;
                t = new Thread(Dissipate);
                t.Start();
            }

        }

        private void Dissipate()
        {
            float inputRaw = db2_inputRaw;
            float inputFlat = db_inputFlat;
            float inputAmp = db_inputAmp;
            float result = db_result;
            float resultLimited = db_resultLimited;

            int times = 100;
            while (times-- > 1)
            {
                pInputRaw.Width = (int)(pInputRaw.Width * 0.96f);
                pInputFlat.Width = (int)(pInputFlat.Width * 0.97f);
                pInputAmp.Width = (int)(pInputAmp.Width * 0.97f);

                pOutRes.Width = (int)(pOutRes.Width * 0.97f);
                pOutAmp.Width = (int)(pOutAmp.Width * 0.97f);
                pOutMain.Width = (int)(pOutMain.Width * 0.96f);

                pMix.PerformLayout();
                Thread.Sleep(10);
            }
            button1.Text = "off";
        }

        private void button2_Click(object sender, EventArgs e) => ShowAbout();



        private int titleX, titleY;
        private bool titleMove = false;

        private void title_MouseDown(object sender, MouseEventArgs e)
        {
            titleX = Cursor.Position.X;
            titleY = Cursor.Position.Y;
            titleMove = true;
        }

        private void title_MouseMove(object sender, MouseEventArgs e)
        {
            if (titleMove)
            {
                Left += (Cursor.Position.X - titleX);
                Top += (Cursor.Position.Y - titleY);

                titleX = Cursor.Position.X;
                titleY = Cursor.Position.Y;
            }
        }

        private void title_MouseUp(object sender, MouseEventArgs e) => titleMove = false;

        #endregion


        #region compressor interface 

        private void cbCompActive_CheckedChanged(object sender, EventArgs e)
        {
            grCompress.Enabled = cbCompActive.Checked;
            panelDelta.Visible = cbCompActive.Checked;

            pInputAmp.Visible = cbCompActive.Checked;
            pOutRes.Visible = cbCompActive.Checked;
            pOutAmp.Visible = cbCompActive.Checked;
            pOutMain.Visible = cbCompActive.Checked;
            bLoadPreset.Enabled = cbCompActive.Checked || bSavePreset.Enabled;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog fsd = new SaveFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "JSC Preset|*.jscp"
            };
            if (fsd.ShowDialog() == DialogResult.OK)
                using (StreamWriter fw = new StreamWriter(fsd.FileName))
                {
                    fw.WriteLine(tbCompPreamp.Value.ToString());
                    fw.WriteLine(tbCompAttackSpeed.Value.ToString());
                    fw.WriteLine(tbCompReleaseSpeed.Value.ToString());

                    fw.WriteLine(tbCompTreshold.Value.ToString());
                    fw.WriteLine(tbCompRatio.Value.ToString());

                    fw.WriteLine(tbCompNTreshold.Value.ToString());
                    fw.WriteLine(tbCompNRatio.Value.ToString());

                    fw.WriteLine(tbCompPostAmp.Value.ToString());
                    fw.WriteLine(tbCompLimitS.Value.ToString());
                    if (tbCompLimitS.Value != tbCompLimitF.Value)
                        fw.WriteLine(tbCompLimitF.Value.ToString());
                }
        }
        private void bLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog fod = new OpenFileDialog
            {
                InitialDirectory = Application.StartupPath,
                Filter = "JSC Preset|*.jscp"
            };
            if (fod.ShowDialog() == DialogResult.OK)
                loadPresetFile(fod.FileName);
        }
        public void loadPresetFile(string filename)
        {
            using (StreamReader fr = new StreamReader(filename))
            {
                tbCompPreamp.Value = int.Parse(fr.ReadLine());
                tbCompAttackSpeed.Value = int.Parse(fr.ReadLine());
                tbCompReleaseSpeed.Value = int.Parse(fr.ReadLine());

                tbCompTreshold.Value = int.Parse(fr.ReadLine());
                tbCompRatio.Value = int.Parse(fr.ReadLine());

                tbCompNTreshold.Value = int.Parse(fr.ReadLine());
                tbCompNRatio.Value = int.Parse(fr.ReadLine());

                tbCompPostAmp.Value = int.Parse(fr.ReadLine());
                tbCompLimitS.Value = int.Parse(fr.ReadLine());
                tbCompLimitF.Value = !fr.EndOfStream ? int.Parse(fr.ReadLine()) : tbCompLimitS.Value;
            }
        }

        private void tbCompPreamp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompPreamp.Value = 0;
        }
        private void tbCompPreamp_ValueChanged(object sender, EventArgs e)
        {
            cmp_preAmp = tbCompPreamp.Value / 2f;
            labelPreampVal.Text = cmp_preAmp.ToString("0.0dB");
        }

        private void tbCompAttackSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompAttackSpeed.Value = 3;
        }
        private void tbCompAttackSpeed_ValueChanged(object sender, EventArgs e)
        {
            cmp_AttackSpeed = tbCompAttackSpeed.Value;
            labelAttackVal.Text = (cmp_AttackSpeed * sts.inputMS_int).ToString("0ms");
            if (cmp_RelesSpeed < cmp_AttackSpeed)
                tbCompReleaseSpeed.Value = tbCompAttackSpeed.Value;
        }

        private void tbCompReleaseSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompReleaseSpeed.Value = 4;
        }
        private void tbCompReleaseSpeed_ValueChanged(object sender, EventArgs e)
        {
            cmp_RelesSpeed = tbCompReleaseSpeed.Value;
            if (cmp_RelesSpeed < cmp_AttackSpeed)
                tbCompAttackSpeed.Value = tbCompReleaseSpeed.Value;
            labelReleaseVal.Text = (cmp_RelesSpeed * sts.inputMS_int).ToString("0ms");
        }

        private void tbCompTreshold_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompTreshold.Value = -18;
        }
        private void tbCompTreshold_ValueChanged(object sender, EventArgs e)
        {
            cmp_treshold = tbCompTreshold.Value;
            labelTresholdVal.Text = cmp_treshold.ToString("0dB");
            if (cmp_treshold < cmp_ntreshold)
                tbCompNTreshold.Value = tbCompTreshold.Value;
        }

        private void tbCompRatio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompRatio.Value = 18;
        }
        private void tbCompRatio_ValueChanged(object sender, EventArgs e)
        {
            cmp_ratio = (float)Math.Exp(tbCompRatio.Value / 20f) - 1f;
            labelRatioVal.Text = (cmp_ratio < 1)
            ? cmp_ratio.ToString("1:0.00")
            : cmp_ratio.ToString("1:0.0");
        }

        private void tbCompNTreshold_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompNTreshold.Value = -40;
        }
        private void tbCompNTreshold_ValueChanged(object sender, EventArgs e)
        {
            cmp_ntreshold = tbCompNTreshold.Value;
            labelNTresholdVal.Text = (cmp_ntreshold).ToString("0dB");
            if (cmp_treshold < cmp_ntreshold)
                tbCompTreshold.Value = tbCompNTreshold.Value;
        }

        private void tbCompNRatio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompNRatio.Value = 21;
        }
        private void tbCompNRatio_ValueChanged(object sender, EventArgs e)
        {
            cmp_nratio = (float)Math.Exp(tbCompNRatio.Value / 30f) - 1f;
            labelNRatioVal.Text = (cmp_nratio < 1)
            ? cmp_nratio.ToString("1:0.00")
            : cmp_nratio.ToString("1:0.0");
        }

        private void tbCompPostAmp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompPostAmp.Value = 0;
        }
        private void tbCompPostAmp_ValueChanged(object sender, EventArgs e)
        {
            cmp_postAmp = tbCompPostAmp.Value / 2f;
            labelPostAmpVal.Text = cmp_postAmp.ToString("0.0dB");
        }

        private void tbCompLimitS_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                tbCompLimitS.Value = -8;
        }
        private void tbCompLimitS_ValueChanged(object sender, EventArgs e)
        {
            cmp_limitSlow = tbCompLimitS.Value * 0.5f;
            labelLimiterVal.Text = cmp_limitSlow.ToString("0.0dB");
        }

        private void tbCompLimitF_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                tbCompLimitF.Value = -8;
        }
        private void tbCompLimitF_ValueChanged(object sender, EventArgs e)
        {
            cmp_limitFast = tbCompLimitF.Value * 0.5f;
            labelFLimitVal.Text = cmp_limitFast.ToString("0.0dB");
        }

        #endregion

    }
}
