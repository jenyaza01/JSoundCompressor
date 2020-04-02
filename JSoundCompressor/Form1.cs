using NAudio.Utils;
using NAudio.Wave;
using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using sts = JSoundCompressor.Settings;

namespace JSoundCompressor
{
    public partial class FormMain : Form
    {
        private const float norm = 1 / 32768f;
        private const float norm2 = norm * norm;

        public FormMain(string[] args)
        {
            InitializeComponent();
            sts.args = args;
        }

        private WaveInEvent waveIn1, waveIn2;
        private BufferedWaveProvider buffer11, buffer21, buffer22;
        private WaveOut waveOut11, waveOut21, waveOut22; //in1 - out1, in2 - out1, in2 - out2

        private bool noWaveOut1 = false;
        private bool noWaveOut2 = false;

        private byte playing = 0; //for audio buffer filing;
        private float db_original = 0;
        private float db_originPre = 0;
        private float db_result = 0;
        private float db_delta = 0;
        private float float_delta = 1.0f;
        private float db_AttSpeed = 4;
        private float db_RelSpeed = 6;
        private float db_preAmp = 0;
        private float db_ratio = 2.0f;
        private float db_treshold = -18;
        private float db_nratio = 1.0f;
        private float db_ntreshold = -36;
        private float db_postAmp = 0;
        private float db_limitS = -4;
        private float db_limitF = -4;
        private float in_max = -100f;
        private float out_max = -100f;
        private int lIN_RP, lMIX_RP;


        private void Form1_Load(object sender, EventArgs e)
        {
            ReloadDevices();

            lIN_RP = label_IN_FAST.Right;
            lMIX_RP = labelMIX.Right;

            pMix.SuspendLayout();
            notifyIcon1.Icon = Icon;

            ParseArgs();
        }

        private void ParseArgs()
        {
            int l = sts.args.Length;
            if (l < 1) return;

            byte willStart = 0; //0 - no, 1 - yes, 2 - errors
            int c = 0;
            while (c < l)
            {

                if (sts.args[c].Contains("-load"))
                {
                    if (sts.args[++c].Contains("jscp"))
                        if (File.Exists(sts.args[c]))
                            loadPresetFile(sts.args[c]);
                        else { c++; willStart = 2; }
                    else { c++; willStart = 2; }
                    continue;
                }

                if (sts.args[c].Contains("-start"))
                {
                    if (willStart == 0) willStart = 1;
                    c++;
                    continue;
                }

                if (sts.args[c].Contains("-input"))
                {
                    int i = cbInput1.FindString(sts.args[++c]);
                    if (i > -1)
                        cbInput1.SelectedIndex = i;
                    else
                    {
                        MessageBox.Show("Not found input device with name \"" + sts.args[c++] + "\"");
                        willStart = 2;
                    }
                    continue;
                }

                if (sts.args[c].Contains("-output"))
                {
                    int i = cbOutput1.FindString(sts.args[++c]);
                    if (i > -1)
                        cbOutput1.SelectedIndex = i;
                    else
                    {
                        MessageBox.Show("Not found output device with name \"" + sts.args[c++] + "\"");
                        willStart = 2;
                    }
                    continue;
                }

                // there must be no legar way to skip all the if-s and be here, 99% error while printing
                willStart = 2;
                c++;
            }
            if (willStart == 1) bPlayStop_Click(null, null);
        }

        private void ReloadDevices()
        {
            if (sts.secondInputEnabled)
            {
                panelCompressor.Top = 86;
                cbInput2.Visible = true;
                labelSecondInput.Visible = true;
            }
            else
            {
                panelCompressor.Top = 55;
                cbInput2.Visible = false;
                labelSecondInput.Visible = false;
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

            cbOutput1.Items.Clear();
            for (int n = -1; n < WaveOut.DeviceCount; n++)
                cbOutput1.Items.Add(WaveOut.GetCapabilities(n).ProductName);
            cbOutput1.Items.Add(" - NO out -");
            cbOutput1.SelectedIndex = 0;

            if (sts.secondOutputEnabled)
            {
                cbOutput2.Items.Clear();
                for (int n = 0; n < WaveOut.DeviceCount; n++)
                    cbOutput2.Items.Add(WaveOut.GetCapabilities(n).ProductName);
                cbOutput2.Items.Add(" - NO out -");
                cbOutput2.SelectedIndex = 0;
            }
        }


        private void waveIn1_DataAvailable(object sender, WaveInEventArgs e) =>
            ThreadPool.QueueUserWorkItem(waveIn1_DataAvailableHandler, e);

        private void waveIn1_DataAvailableHandler(object o)
        {
            WaveInEventArgs e = (WaveInEventArgs)o;
            int bytesRecorded = e.BytesRecorded;
            int shortRecorded = bytesRecorded / 2;
            float in_db = 0f;

            short[] data = new short[bytesRecorded];


            Buffer.BlockCopy(e.Buffer, 0, data, 0, bytesRecorded);

            if (cbBypass.Checked)
            {
                buffer11.AddSamples(e.Buffer, 0, bytesRecorded);

                for (int index = 0; index < shortRecorded; index++)
                    in_db += data[index] * data[index] * norm2;

                in_db = (float)Decibels.LinearToDecibels(Math.Sqrt(in_db / (bytesRecorded * 0.5)));

                db_original = clamp((db_original + in_db) * 0.5f, 90f);

                in_max = max(in_max - 0.05f, db_original);

                if (WindowState != FormWindowState.Minimized)
                {
                    Invoke(new Action(() =>
                    {
                        pMainIn.Width = (int)(5 * in_db + 300);
                        pMixIn.Width = (int)(5 * db_original + 300);
                        label_IN_FAST.Text = (db_original).ToString("0.0");
                        label_IN_FAST.Left = lIN_RP - label_IN_FAST.Width;

                        pMix.PerformLayout();
                    }));
                }
            }

            else
            {
                byte[] bytes = e.Buffer;
                for (int index = 0; index < shortRecorded; index++)
                    in_db += data[index] * data[index] * norm2;

                in_db = (float)Decibels.LinearToDecibels(Math.Sqrt(in_db / shortRecorded));

                if (float.IsNaN(db_original))
                {
                    db_original = 0f;
                    db_originPre = 0f;
                    db_delta = 0f;
                    out_max = 0f;
                    pWindowTitle.BackColor = Color.White;
                }


                db_original = db_original < in_db
                    ? clamp((db_original * db_AttSpeed + in_db) / (db_AttSpeed + 1f), 90f)
                    : clamp((db_original * db_RelSpeed + in_db) / (db_RelSpeed + 1f), 90f);

                db_originPre = db_original + db_preAmp;

                db_result = GetResultDB(db_originPre);

                db_result += db_postAmp;

                if (db_result > db_limitS) db_result = db_limitS;

                db_delta = (db_result - db_original);

                out_max = max(out_max - 0.05f, db_result); // for display OUT peak val 

                //		-9       -2         -15
                if (in_db + db_delta > db_limitF)
                    //   -2     =   -15     - -11
                    db_delta += db_limitF - (in_db + db_delta);

                float_delta = (float)Decibels.DecibelsToLinear(db_delta);



                for (int index = 0; index < bytes.Length; index += 2) //left + right
                {
                    float t1 = (int)(BitConverter.ToInt16(bytes, index) * float_delta);
                    short t2 = clamp(t1, 32767);
                    write2bytes(ref bytes, index, BitConverter.GetBytes(t2));
                }

                buffer11.AddSamples(bytes, 0, bytesRecorded);

                if (WindowState != FormWindowState.Minimized)
                {

                    Invoke(new Action(() =>
                    {
                        pMainIn.Width = (int)(5 * in_db + 300);
                        pMixIn.Width = (int)(5 * min(0f, db_originPre) + 300);
                        pMixOut.Width = (int)(5 * db_result + 300);
                        label_IN_FAST.Text = (db_original).ToString("0.0");

                        float h = 5 * db_delta;
                        if (h < -150) { panelDelta.BackColor = Color.Gray; h = -150; } else panelDelta.BackColor = Color.Orange;

                        panelDelta.Width = (int)(abs(h) == 0 ? 1 : abs(h) + 1);
                        panelDelta.Left = (h > 0) ? 191 : 191 + (int)h;
                        labelMIX.Text = (db_delta).ToString("0.0");
                        pMainOut.Width = (int)(5 * (in_db + db_delta) + 300);

                        label_IN_FAST.Left = lIN_RP - label_IN_FAST.Width;
                        labelMIX.Left = lMIX_RP - labelMIX.Width;

                        pMix.PerformLayout();
                    }));
                }
            }


            if (playing == 5) return;
            if (playing < 5) playing++;

            if (playing == 4)
            {
                if (!noWaveOut1)
                {
                    if (waveOut11.PlaybackState != PlaybackState.Playing)
                        waveOut11.Play();
                    if (waveOut21 != null)
                        if (sts.secondInputEnabled && waveOut21.PlaybackState != PlaybackState.Playing)
                            waveOut21.Play();
                }

                if (!noWaveOut2)
                {
                    if (waveOut22 != null)
                        if (sts.secondOutputEnabled && waveOut22.PlaybackState != PlaybackState.Playing)
                            waveOut22.Play();
                }
            }
        }

        private void waveIn2_DataAvailable(object sender, WaveInEventArgs e) =>
            ThreadPool.QueueUserWorkItem(waveIn2_DataAvailableHandler, e);

        private void waveIn2_DataAvailableHandler(object o)
        {
            WaveInEventArgs e = (WaveInEventArgs)o;
            if (sts.secondInputEnabled)
                buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
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

        private short clamp(float t1, int p)
        {
            if (t1 > p) t1 = p;
            if (t1 < -p) t1 = -p;
            return (short)t1;
        }

        private float clamp(float t1, float p)
        {
            if (t1 > p) t1 = p;
            if (t1 < -p) t1 = -p;
            return t1;
        }
        #endregion


        private float GetResultDB(float dbIn) =>
            /*  if (dbIn > db_treshold)
    {
    if (db_ratio == 1 ) return dbIn;
    return dbIn / db_ratio + db_treshold / ((1 / (db_ratio - 1)) + 1);
    }
    else
    {
    if (dbIn > db_ntreshold) return dbIn;
    if (db_nratio == 1) return dbIn;
    return dbIn / db_nratio + db_ntreshold / ((1 / (db_nratio - 1)) + 1);
    }  */

            dbIn > db_treshold
                ? db_ratio == 1 ? dbIn : dbIn / db_ratio + db_treshold / ((1 / (db_ratio - 1)) + 1)
                : dbIn > db_ntreshold ? dbIn : db_nratio == 1 ? dbIn : dbIn / db_nratio + db_ntreshold / ((1 / (db_nratio - 1)) + 1);


        private void PlayPress()
        {
            if (waveIn1 != null)
            {
                buffer11 = new BufferedWaveProvider(new WaveFormat(sts.freq_int, 16, 2))
                {
                    DiscardOnBufferOverflow = true,
                    BufferDuration = TimeSpan.FromMilliseconds(sts.outputMS_int)
                };
                waveIn1.StartRecording();
            }

            if (sts.secondInputEnabled && waveIn2 != null)
            {
                buffer21 = new BufferedWaveProvider(new WaveFormat(sts.freq_int, 16, 2))
                {
                    DiscardOnBufferOverflow = true,
                    BufferDuration = TimeSpan.FromMilliseconds(sts.outputMS_int)
                };
                waveIn2.StartRecording();
            }

            if (sts.secondOutputEnabled && waveIn2 != null)
            {
                buffer22 = new BufferedWaveProvider(new WaveFormat(sts.freq_int, 16, 2))
                {
                    DiscardOnBufferOverflow = true,
                    BufferDuration = TimeSpan.FromMilliseconds(sts.outputMS_int)
                };
                if (!sts.secondInputEnabled)
                    waveIn2.StartRecording();
            }



            if (!noWaveOut1)
            {
                if (waveOut11 != null)
                {
                    waveOut11.Init(buffer11.ToSampleProvider());
                    playing = 0;
                }
                if (waveOut21 != null && sts.secondInputEnabled)
                {
                    waveOut21.Init(buffer21.ToSampleProvider());
                }
            }
            else
                cbBypass.Checked = true;

            if (!noWaveOut2)
            {
                if (waveOut22 != null && sts.secondOutputEnabled)
                {
                    waveOut22.Init(buffer22.ToSampleProvider());
                }
            }

            bSettings.Enabled = false;
            cbInput1.Enabled = false;
            cbInput2.Enabled = false;
            cbOutput1.Enabled = false;
            cbOutput2.Enabled = false;

            bSavePreset.Enabled = false;
            bLoadPreset.Enabled = false;
        }

        private void StopPress()
        {
            if (waveIn1 != null) waveIn1.StopRecording();
            if (waveIn2 != null) waveIn2.StopRecording();
            if (waveOut11 != null) waveOut11.Stop();
            if (waveOut21 != null) waveOut21.Stop();
            if (waveOut22 != null) waveOut22.Stop();

            cbInput1.Enabled = true;
            cbInput2.Enabled = true;
            cbOutput1.Enabled = true;
            cbOutput2.Enabled = true;
            bSettings.Enabled = true;

            bSavePreset.Enabled = true;
            bLoadPreset.Enabled = true;
        }


        private void cbInput1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveIn1 != null)
            {
                waveIn1.DataAvailable -= waveIn1_DataAvailable;
                //	waveIn1.StopRecording();
                waveIn1.Dispose();
            }

            waveIn1 = new WaveInEvent() { DeviceNumber = cbInput1.SelectedIndex - 1 };
            waveIn1.WaveFormat = new WaveFormat(
            int.Parse(sts.freq), 16, 2);
            waveIn1.DataAvailable += waveIn1_DataAvailable;
            waveIn1.BufferMilliseconds = sts.inputMS_int;
        }

        private void cbOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveOut11 != null)
            {
                waveOut11.Stop();
                waveOut11.Dispose();
            }

            if (waveOut21 != null)
            {
                waveOut21.Stop();
                waveOut21.Dispose();
            }

            if (cbOutput1.Text.Contains("NO out"))
            {
                noWaveOut1 = true;
                cbOutput2.Text = " - NO out -";
                cbOutput2.Enabled = false;
                return;
            }
            else
            {
                noWaveOut1 = false;
                cbOutput2.Enabled = true;
            }

            waveOut11 = new WaveOut() { DeviceNumber = cbOutput1.SelectedIndex - 1 };
            waveOut11.DesiredLatency = sts.outputMS_int;
            waveOut11.NumberOfBuffers = waveOut11.DesiredLatency / 9;

            if (sts.secondInputEnabled)
            {
                waveOut21 = new WaveOut() { DeviceNumber = cbOutput1.SelectedIndex - 1 };
                waveOut21.DesiredLatency = sts.outputMS_int;
                waveOut21.NumberOfBuffers = waveOut21.DesiredLatency / 9;
            }
        }


        #region compressor interface 

        private void tbCompPreamp_ValueChanged(object sender, EventArgs e)
        {
            db_preAmp = tbCompPreamp.Value;
            labelPreampVal.Text = db_preAmp.ToString("0dB");
        }

        private void tbCompTreshold_ValueChanged(object sender, EventArgs e)
        {
            db_treshold = tbCompTreshold.Value;
            labelTresholdVal.Text = db_treshold.ToString("0dB");
            if (db_treshold < db_ntreshold) tbCompNTreshold.Value = tbCompTreshold.Value;
        }

        private void tbCompRatio_ValueChanged(object sender, EventArgs e)
        {
            db_ratio = tbCompRatio.Value / 10f;
            labelRatioVal.Text = db_ratio.ToString("1:0.0");
        }

        private void tbCompPostAmp_ValueChanged(object sender, EventArgs e)
        {
            db_postAmp = tbCompPostAmp.Value;
            labelPostAmpVal.Text = db_postAmp.ToString("0dB");
        }

        private void tbCompPreamp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompPreamp.Value = 0;
        }

        private void tbCompTreshold_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompTreshold.Value = -18;
        }

        private void tbCompRatio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompRatio.Value = 20;
        }

        private void tbCompPostAmp_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompPostAmp.Value = 0;
        }

        private void tbCompNRatio_ValueChanged(object sender, EventArgs e)
        {
            db_nratio = tbCompNRatio.Value * 0.1f;
            labelNRatioVal.Text = db_nratio.ToString("1:0.0");
        }

        private void tbCompNRatio_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompNRatio.Value = 10;
        }

        private void tbCompLimitS_ValueChanged(object sender, EventArgs e)
        {
            db_limitS = tbCompLimitS.Value * 0.5f;
            labelLimiterVal.Text = db_limitS.ToString("0.0dB");
        }

        private void tbCompLimitS_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                tbCompLimitS.Value = -8;
        }

        private void tbCompLimitF_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                tbCompLimitF.Value = -8;
        }
        #endregion


        private void cbCompressBypass_CheckedChanged(object sender, EventArgs e)
        {
            bool c = !cbBypass.Checked;
            grCompress.Enabled = c;
            labelMIX.Visible = c;
            panelDelta.Visible = c;
            pMixOut.Visible = c;
            pMixIn.Visible = c;
            pMainOut.Visible = c;

        }

        private void bClose_Click(object sender, EventArgs e) => Application.Exit();

        private void bMinimise_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;



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


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e) =>
            MessageBox.Show("VST-like compressor, but for Windows audio streams\nVersion 2 include repeaters\n\nAuthor: Jenyaza01\njenyaza01@gmail.com\n\nPowered by NAudio\ngithub.com/naudio/NAudio", "About");

        private void tbCompAttackSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompAttackSpeed.Value = 3;
        }

        private void tbCompAttackSpeed_ValueChanged(object sender, EventArgs e)
        {
            db_AttSpeed = tbCompAttackSpeed.Value;
            labelAttackVal.Text = (db_AttSpeed * sts.inputMS_int).ToString("0ms");
            if (db_RelSpeed < db_AttSpeed) tbCompReleaseSpeed.Value = tbCompAttackSpeed.Value;
        }

        private void tbCompReleaseSpeed_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompReleaseSpeed.Value = 5;
        }

        private void tbCompReleaseSpeed_ValueChanged(object sender, EventArgs e)
        {
            db_RelSpeed = tbCompReleaseSpeed.Value;
            if (db_RelSpeed < db_AttSpeed) tbCompAttackSpeed.Value = tbCompReleaseSpeed.Value;
            labelReleaseVal.Text = (db_RelSpeed * sts.inputMS_int).ToString("0ms");
        }

        private void bPlayStop_Click(object sender, EventArgs e)
        {
            if (bPlay.Text == "STOP")
            {
                StopPress();
                bPlay.Text = "PLAY";
            }
            else
            {
                PlayPress();
                bPlay.Text = "STOP";
            }
            in_max = -100f;
            out_max = -100f;
        }

        private void tbCompNTreshold_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
                tbCompNTreshold.Value = -36;
        }

        private void tbCompNTreshold_ValueChanged(object sender, EventArgs e)
        {
            db_ntreshold = tbCompNTreshold.Value;
            labelNTresholdVal.Text = (db_ntreshold).ToString("0dB");
            if (db_treshold < db_ntreshold) tbCompTreshold.Value = tbCompNTreshold.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
        }


        private void cbOutput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveOut22 != null)
            {
                waveOut22.Stop();
                waveOut22.Dispose();
            }

            if (cbOutput2.Text.Contains("NO out")) { noWaveOut2 = true; return; } else noWaveOut2 = false;

            if (sts.secondOutputEnabled)
            {
                waveOut22 = new WaveOut() { DeviceNumber = cbOutput2.SelectedIndex };
                waveOut22.DesiredLatency = sts.outputMS_int;
                waveOut22.NumberOfBuffers = waveOut22.DesiredLatency / 9;
            }
        }


        private void alwaysOnTopToolStripMenuItem_Click(object sender, EventArgs e) => alwaysOnTopToolStripMenuItem.Checked = (TopMost = !TopMost);

        private void tbLimitF_ValueChanged(object sender, EventArgs e)
        {
            db_limitF = tbCompLimitF.Value * 0.5f;
            labelFLimitVal.Text = db_limitF.ToString("0.0dB");
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
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

        private void cbInput2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (waveIn2 != null)
            {
                waveIn2.DataAvailable -= waveIn2_DataAvailable;
                waveIn2.StopRecording();
                waveIn2.Dispose();
            }
            if (cbInput2.Text.Contains("NO input")) return;

            waveIn2 = new WaveInEvent() { DeviceNumber = cbInput2.SelectedIndex };
            waveIn2.WaveFormat = new WaveFormat(sts.freq_int, 16, 2);
            waveIn2.DataAvailable += waveIn2_DataAvailable;
            waveIn2.BufferMilliseconds = sts.inputMS_int;
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
    }
}
