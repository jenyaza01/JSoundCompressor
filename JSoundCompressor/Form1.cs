using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Utils;
using NAudio.Wave;
using settings = JSoundCompressor.Settings;

namespace JSoundCompressor
{
	public partial class FormMain : Form
	{
		private const float norm = 1 / 32768f;
		private const float norm2 = norm * norm;

		public FormMain()
		{
			InitializeComponent();
		}

		private WaveInEvent waveIn1, waveIn2;
		private BufferedWaveProvider buffer11, buffer21, buffer22;
		private WaveOut waveOut11, waveOut21, waveOut22; //in1 - out1, in2 - out1, in2 - out2

		private bool noWaveOut1 = false;
		private bool noWaveOut2 = false;
		private byte playing = 0; //for audio buffer filing;
		private float db_read = 0;
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
		private float db_slimit = -4;
		private float db_hlimit = -4;
		private float in_max = -100f;
		private float out_max = -100f;


		int lIN_RP, lMIX_RP;


		private void Form1_Load(object sender, EventArgs e)
		{
			ReloadDevices();

			lIN_RP = label_IN_FAST.Right;
			lMIX_RP = labelMIX.Right;

			notifyIcon1.Icon = Icon;
			System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
			myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
		}

		private int freq = 48000;
		private void ReloadDevices()
		{
			freq = Int32.Parse(settings.freq);
			if (settings.secondInputEnabled)
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

			if (settings.secondOutputEnabled)
				Height = panelCompressor.Top + panelCompressor.Height + 31;
			else
				Height = panelCompressor.Top + panelCompressor.Height;

			cbInput1.Items.Clear();
			for (int n = -1; n < WaveIn.DeviceCount; n++)
				cbInput1.Items.Add(WaveIn.GetCapabilities(n).ProductName);
			cbInput1.SelectedIndex = 0;


			if (settings.secondInputEnabled)
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

			if (settings.secondOutputEnabled)
			{
				cbOutput2.Items.Clear();
				for (int n = 0; n < WaveOut.DeviceCount; n++)
					cbOutput2.Items.Add(WaveOut.GetCapabilities(n).ProductName);
				cbOutput2.Items.Add(" - NO out -");
				cbOutput2.SelectedIndex = 0;
			}
		}



		private void waveIn1_DataAvailable(object sender, WaveInEventArgs e)
		{
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
						this.SuspendLayout();
						pMainIn.Width = (int)(5 * in_db + 300);
						panelMixIn.Width = (int)(5 * db_original + 300);
						label_IN_FAST.Text = (db_original).ToString("0.0");

						label_IN_FAST.Left = lIN_RP - label_IN_FAST.Width;

						if (db_original > -1) panelMixIn.BackColor = Color.Red; // 80%
						else if (db_original > -5) panelMixIn.BackColor = Color.Orange; //60%
						else if (db_original > -12) panelMixIn.BackColor = Color.Yellow;
						else if (db_original > -30) panelMixIn.BackColor = Color.LawnGreen;
						else if (db_original > -45) panelMixIn.BackColor = Color.LightGreen;
						else panelMixIn.BackColor = Color.LightGray;
						this.ResumeLayout();

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


				if (db_original < in_db)
					db_original = clamp((db_original * db_AttSpeed + in_db) / (db_AttSpeed + 1f), 90f);
				else
					db_original = clamp((db_original * db_RelSpeed + in_db) / (db_RelSpeed + 1f), 90f);

				db_originPre = db_original + db_preAmp;

				db_result = GetResultDB(db_originPre);

				db_result += db_postAmp;

				if (db_result > db_slimit) db_result = db_slimit;

				db_delta = (db_result - db_original);

				out_max = max(out_max - 0.05f, db_result); // for display OUT peak val 

				//		-9       -2         -15
				if (in_db + db_delta > db_hlimit)
					//   -2     =   -15     - -11
					db_delta += db_hlimit - (in_db + db_delta);

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
						this.SuspendLayout();
						pMainIn.Width = (int)(5 * in_db + 300);
						panelMixIn.Width = (int)(5 * db_original + 300);
						pMixOut.Width = (int)(5 * db_result + 300);
						label_IN_FAST.Text = (db_original).ToString("0.0");

						float h = 5 * db_delta;
						if (h < -150) { panelDelta.BackColor = Color.Gray; h = -150; } else panelDelta.BackColor = Color.Orange;

						panelDelta.Width = (int)(abs(h) == 0 ? 1 : abs(h) + 1);
						if (h > 0) panelDelta.Left = 191; else panelDelta.Left = 191 + (int)h;
						labelMIX.Text = (db_delta).ToString("0.0");
						pMainOut.Width = (int)(5 * (in_db + db_delta) + 300);

						label_IN_FAST.Left = lIN_RP - label_IN_FAST.Width;
						labelMIX.Left = lMIX_RP - labelMIX.Width;

						this.ResumeLayout();
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
						if (settings.secondInputEnabled && waveOut21.PlaybackState != PlaybackState.Playing)
							waveOut21.Play();
				}

				if (!noWaveOut2)
				{
					if (waveOut22 != null)
						if (settings.secondOutputEnabled && waveOut22.PlaybackState != PlaybackState.Playing)
							waveOut22.Play();
				}
			}
		}


		private void waveIn2_DataAvailable(object sender, WaveInEventArgs e)
		{
			if (settings.secondInputEnabled)
				buffer21.AddSamples(e.Buffer, 0, e.BytesRecorded);
			if (settings.secondOutputEnabled)
				buffer22.AddSamples(e.Buffer, 0, e.BytesRecorded);
		}

		#region small functions

		private void write2bytes(ref byte[] bytes, int index, byte[] p)
		{
			bytes[index++] = p[0];
			bytes[index] = p[1];
		}

		private float abs(float a)
		{
			return a < 0 ? -a : a;
		}

		private float min(float a, float b)
		{
			return (a < b) ? a : b;
		}

		private float max(float a, float b)
		{
			return (a > b) ? a : b;
		}

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

		private float GetResultDB(float dbIn)
		{
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

			return dbIn > db_treshold
				? db_ratio == 1 ? dbIn : dbIn / db_ratio + db_treshold / ((1 / (db_ratio - 1)) + 1)
				: dbIn > db_ntreshold ? dbIn : db_nratio == 1 ? dbIn : dbIn / db_nratio + db_ntreshold / ((1 / (db_nratio - 1)) + 1);
		}


		private void PlayPress()
		{
			if (waveIn1 != null)
			{
				buffer11 = new BufferedWaveProvider(new WaveFormat(freq, 16, 2))
				{
					DiscardOnBufferOverflow = true,
					BufferDuration = TimeSpan.FromMilliseconds(
					Int32.Parse(settings.outputMS))
				};
				waveIn1.StartRecording();
			}

			if (settings.secondInputEnabled && waveIn2 != null)
			{
				buffer21 = new BufferedWaveProvider(new WaveFormat(freq, 16, 2))
				{
					DiscardOnBufferOverflow = true,
					BufferDuration = TimeSpan.FromMilliseconds(
					Int32.Parse(settings.outputMS))
				};
				waveIn2.StartRecording();
			}

			if (settings.secondOutputEnabled && waveIn2 != null)
			{
				buffer22 = new BufferedWaveProvider(new WaveFormat(freq, 16, 2))
				{
					DiscardOnBufferOverflow = true,
					BufferDuration = TimeSpan.FromMilliseconds(
					Int32.Parse(settings.outputMS))
				};
				if (!settings.secondInputEnabled)
					waveIn2.StartRecording();
			}



			if (!noWaveOut1)
			{
				if (waveOut11 != null)
				{
					waveOut11.Init(buffer11.ToSampleProvider());
					playing = 0;
				}
				if (waveOut21 != null && settings.secondInputEnabled)
				{
					waveOut21.Init(buffer21.ToSampleProvider());
				}
			}
			else
				cbBypass.Checked = true;

			if (!noWaveOut2)
			{
				if (waveOut22 != null && settings.secondOutputEnabled)
				{
					waveOut22.Init(buffer22.ToSampleProvider());
				}
			}

			bSettings.Enabled = false;
			cbInput1.Enabled = false;
			cbInput2.Enabled = false;
			cbOutput1.Enabled = false;
			cbOutput2.Enabled = false;
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
			Int32.Parse(settings.freq), 16, 2);
			waveIn1.DataAvailable += waveIn1_DataAvailable;
			waveIn1.BufferMilliseconds = Int32.Parse(settings.inputMS);
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
			waveOut11.DesiredLatency = Int32.Parse(settings.outputMS);
			waveOut11.NumberOfBuffers = waveOut11.DesiredLatency / 9;

			if (settings.secondInputEnabled)
			{
				waveOut21 = new WaveOut() { DeviceNumber = cbOutput1.SelectedIndex - 1 };
				waveOut21.DesiredLatency = Int32.Parse(settings.outputMS);
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

		private void tbCompLimit_ValueChanged(object sender, EventArgs e)
		{
			db_slimit = tbCompLimit.Value * 0.5f;
			labelLimiterVal.Text = db_slimit.ToString("0.0dB");
		}

		private void tbCompLimit_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
				tbCompLimit.Value = -8;
		}

		#endregion

		private void cbCompressBypass_CheckedChanged(object sender, EventArgs e)
		{
			bool c = !cbBypass.Checked;
			grCompress.Enabled = c;
			labelMIX.Visible = c;
			panelDelta.Visible = c;
			pMixOut.Visible = c;
			panelMixIn.Visible = c;
			pMainOut.Visible = c;

		}

		private void button1_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void button2_Click_1(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
		}



		private int tmpX;
		private int tmpY;
		private bool flMove = false;

		private void frmMain_MouseDown(object sender, MouseEventArgs e)
		{
			tmpX = Cursor.Position.X;
			tmpY = Cursor.Position.Y;
			flMove = true;
		}

		private void frmMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (flMove)
			{
				Left = Left + (Cursor.Position.X - tmpX);
				Top = Top + (Cursor.Position.Y - tmpY);

				tmpX = Cursor.Position.X;
				tmpY = Cursor.Position.Y;
			}
		}

		private void frmMain_MouseUp(object sender, MouseEventArgs e)
		{
			flMove = false;
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Windows audio stream compressor\nAuthor: Jenyaza01\nPM: jenyaza01@gmail.com\nPowered by NAudio", "About");
		}

		private void tbCompAttackSpeed_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
				tbCompAttackSpeed.Value = 3;
		}

		private void tbCompAttackSpeed_ValueChanged(object sender, EventArgs e)
		{
			db_AttSpeed = tbCompAttackSpeed.Value;
			labelAttackVal.Text = (db_AttSpeed * 15).ToString("0ms");
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
			labelReleaseVal.Text = (db_RelSpeed * 15).ToString("0ms");
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

			if (settings.secondOutputEnabled)
			{
				waveOut22 = new WaveOut() { DeviceNumber = cbOutput2.SelectedIndex };
				waveOut22.DesiredLatency = Int32.Parse(settings.outputMS);
				waveOut22.NumberOfBuffers = waveOut22.DesiredLatency / 9;
			}
		}

		private void tbHLimit_ValueChanged(object sender, EventArgs e)
		{
			db_hlimit = tbHLimitVal.Value * 0.5f;
			labelHLimitVal.Text = db_hlimit.ToString("0.0dB");
		}

		private void notifyIcon1_Click(object sender, EventArgs e)
		{
			Show();
			WindowState = FormWindowState.Normal;
		}

		private void button4_Click(object sender, EventArgs e)
		{
			SaveFileDialog fsd = new SaveFileDialog
			{
				Filter = "JSC Preset|*.jscp"
			};
			if (fsd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
					fw.WriteLine(tbCompLimit.Value.ToString());
				}
		}

		private void button5_Click(object sender, EventArgs e)
		{
			OpenFileDialog fod = new OpenFileDialog
			{
				Filter = "JSC Preset|*.jscp"
			};
			if (fod.ShowDialog() == System.Windows.Forms.DialogResult.OK)
				using (StreamReader fr = new StreamReader(fod.FileName))
				{
					tbCompPreamp.Value = Int32.Parse(fr.ReadLine());
					tbCompAttackSpeed.Value = Int32.Parse(fr.ReadLine());
					tbCompReleaseSpeed.Value = Int32.Parse(fr.ReadLine());

					tbCompTreshold.Value = Int32.Parse(fr.ReadLine());
					tbCompRatio.Value = Int32.Parse(fr.ReadLine());

					tbCompNTreshold.Value = Int32.Parse(fr.ReadLine());
					tbCompNRatio.Value = Int32.Parse(fr.ReadLine());

					tbCompPostAmp.Value = Int32.Parse(fr.ReadLine());
					tbCompLimit.Value = Int32.Parse(fr.ReadLine());
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
			waveIn2.WaveFormat = new WaveFormat(freq, 16, 2);
			waveIn2.DataAvailable += waveIn2_DataAvailable;
			waveIn2.BufferMilliseconds = Int32.Parse(settings.inputMS);
		}

		private void bSettings_Click(object sender, EventArgs e)
		{
			using (FormSettings fs = new FormSettings())
			{
				settings.changed = false;
				Enabled = false;
				fs.ShowDialog();
				Enabled = true;
				if (settings.changed)
					ReloadDevices();
			}
		}
	}
}
