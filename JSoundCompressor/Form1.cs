using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NAudio.Utils;
using NAudio.Wave;

namespace JSoundCompressor
{
	public partial class Form1 : Form
	{
		private const float norm = 1 / 32768f;

		public Form1()
		{
			InitializeComponent();
		}

		private WaveInEvent waveIn;
		private WaveInEvent waveInSecondary;
		private BufferedWaveProvider buffer, bufferSecondary;
		private WaveOut waveOut;
		private bool noWaveOut = false;
		private byte playing = 0;
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
		private float db_limit = -4;
		private float in_max = -100f;
		private float out_max = -100f;
		private int waveSanplesPesSec = 44100;


		private void Form1_Load(object sender, EventArgs e)
		{
			for (int n = 0; n < WaveIn.DeviceCount; n++)
			{
				comboBox1.Items.Add(WaveIn.GetCapabilities(n).ProductName);
				comboBox5.Items.Add(WaveIn.GetCapabilities(n).ProductName);
			}


			for (int n = 0; n < WaveOut.DeviceCount; n++)
				comboBox2.Items.Add(WaveOut.GetCapabilities(n).ProductName);
			comboBox2.Items.Add(" - NO out -");
			comboBox5.Items.Add(" - NO input -");

			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
			comboBox3.SelectedIndex = 1; //48000

			notifyIcon1.Icon = Icon;
		}

		private float db_lastRead;

		private void waveIn_DataAvailable(object sender, WaveInEventArgs e)
		{
			int bytesRecorded = e.BytesRecorded;
			float sample = 0f;
			float maxdb = 0f;


			if (!cbCompressBypass.Checked)
			{
				byte[] bytes = e.Buffer;


				{                          // switch calc method
					if (rbPeak.Checked)
						for (int index = 0; index < bytesRecorded; index += 2)
						{
							sample = abs(BitConverter.ToInt16(bytes, index) * norm);
							if (sample > maxdb) maxdb = sample;
						}

					if (rbRMS.Checked)
					{
						for (int index = 0; index < bytesRecorded; index += 2)
						{
							sample = BitConverter.ToInt16(bytes, index) * norm;
							maxdb += sample * sample;
						}
						maxdb = (float)Math.Sqrt(maxdb / (bytesRecorded * 0.5));
					}
				}


				if (Single.IsNegativeInfinity(maxdb)) maxdb = 0.001f;

				db_lastRead = db_read;
				db_read = (float)Decibels.LinearToDecibels(maxdb);

				if (db_original < db_read)
					db_original = clamp((db_original * db_AttSpeed + db_read) / (db_AttSpeed + 1f), 90f);
				else
					db_original = clamp((db_original * db_RelSpeed + db_read) / (db_RelSpeed + 1f), 90f);

				in_max = max(in_max - 0.05f, db_read); // for display IN peak val

				db_originPre = db_original + db_preAmp;

				db_result = GetResultDB(db_originPre);

				db_result += db_postAmp;

				if (db_result > db_limit) db_result = db_limit;

				out_max = max(out_max - 0.05f, db_result); // for display OUT peak val

				db_delta = (db_result - db_original);

				float_delta = (float)Decibels.DecibelsToLinear(db_delta);



				for (int index = 0; index < bytes.Length; index += 2) //left + right
				{
					float t1 = (int)(BitConverter.ToInt16(bytes, index) * float_delta);
					short t2 = clamp(t1, 32767);
					write2bytes(ref bytes, index, BitConverter.GetBytes(t2));
				}

				buffer.AddSamples(bytes, 0, bytesRecorded);

				if (WindowState != FormWindowState.Minimized)
				{
					Invoke(new Action(() =>
					{
						panel_db_original.Width = (int)(5 * db_original + 300);
						label_db_original.Text = (db_original).ToString("0.0");

						if (db_original > -0.9) panel_db_original.BackColor = Color.Red; //0.9 ampl
						else if (db_original > -6) panel_db_original.BackColor = Color.Orange; //0.5 ampl
						else if (db_original > -12) panel_db_original.BackColor = Color.Yellow; //0.25, safe ampl
						else if (db_original > db_ntreshold) panel_db_original.BackColor = Color.LawnGreen;
						else if (db_original > -48) panel_db_original.BackColor = Color.LightGreen;
						else panel_db_original.BackColor = Color.LightGray;

						panel_db_result.Width = (int)(5 * db_result + 300);
						label_db_result.Text = (db_result).ToString("0.0");

						if (db_result > -0.9) panel_db_result.BackColor = Color.Red;
						else if (db_result > -6) panel_db_result.BackColor = Color.Orange;
						else if (db_result > -12) panel_db_result.BackColor = Color.Yellow;
						else if (db_result > db_ntreshold) panel_db_result.BackColor = Color.LawnGreen;
						else if (db_result > -48) panel_db_result.BackColor = Color.LightGreen;
						else panel_db_result.BackColor = Color.LightGray;

						float h = 5 * db_delta;
						if (h < -150) { panelDelta.BackColor = Color.Gray; h = -150; } else panelDelta.BackColor = Color.Orange;

						panelDelta.Width = (int)(abs(h) == 0 ? 1 : abs(h) + 1);
						if (h > 0) panelDelta.Left = 200; else panelDelta.Left = 200 + (int)h;
						label1.Text = (db_delta).ToString("0.0");

						label15.Text = in_max.ToString("0dB");
						label19.Text = out_max.ToString("0dB");

					}));
				}
			}


			else
			{
				buffer.AddSamples(e.Buffer, 0, bytesRecorded);

				{                          // switch calc method
					if (rbPeak.Checked)
						for (int index = 0; index < bytesRecorded; index += 2)
						{
							sample = abs(BitConverter.ToInt16(e.Buffer, index) * norm);
							if (sample > maxdb) maxdb = sample;
						}

					if (rbRMS.Checked)
					{
						for (int index = 0; index < bytesRecorded; index += 2)
						{
							sample = BitConverter.ToInt16(e.Buffer, index) * norm;
							maxdb += sample * sample;
						}
						maxdb = (float)Math.Sqrt(maxdb / (bytesRecorded * 0.5));
					}
				}

				maxdb = (float)Decibels.LinearToDecibels(maxdb);

				db_original = clamp((db_original + maxdb) * 0.5f, 90f);

				in_max = max(in_max - 0.05f, db_original);

				if (WindowState != FormWindowState.Minimized)
				{
					Invoke(new Action(() =>
					{
						panel_db_original.Width = (int)(5 * db_original + 300);
						label_db_original.Text = (db_original).ToString("0.0");

						if (db_original > -1) panel_db_original.BackColor = Color.Red; // 80%
						else if (db_original > -5) panel_db_original.BackColor = Color.Orange; //60%
						else if (db_original > -12) panel_db_original.BackColor = Color.Yellow;
						else if (db_original > -30) panel_db_original.BackColor = Color.LawnGreen;
						else if (db_original > -45) panel_db_original.BackColor = Color.LightGreen;
						else panel_db_original.BackColor = Color.LightGray;

						label15.Text = in_max.ToString("0dB");

					}));
				}
			}

			if (!noWaveOut)
				if (playing == 4 && waveOut.PlaybackState != PlaybackState.Playing)
					waveOut.Play();
				else
					playing++;

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

		private void write2bytes(ref byte[] bytes, int index, byte[] p)
		{
			bytes[index++] = p[0];
			bytes[index] = p[1];
		}

		private float abs(float a)
		{
			return a < 0 ? -a : a;
		}


		private void PlayPress()
		{

			buffer = new BufferedWaveProvider(new WaveFormat(waveSanplesPesSec, 16, 2));
			{
				DiscardOnBufferOverflow = true,
				BufferDuration = TimeSpan.FromMilliseconds(100)
			};
			bufferSecondary = new BufferedWaveProvider(new WaveFormat(waveSanplesPesSec, 16, 2));
			{
				DiscardOnBufferOverflow = true,
				BufferDuration = TimeSpan.FromMilliseconds(100)
			};
			WaveMixerStream32 mixer = new WaveMixerStream32()
			{
				AutoStop = true
			};
			var mstream = new MemoryStream(buffer.BufferedBytes);
			var mstream2 = new MemoryStream(bufferSecondary.BufferedBytes);

			var stream1 = (new WaveFileReader(mstream1)).ToStandardWaveStream();
			var stream2 = (new WaveFileReader(mstream2)).ToStandardWaveStream();

			mixer.AddInputStream(stream1);
			mixer.AddInputStream(stream2);
			
			waveIn.StartRecording();
			waveInSecondary.StartRecording();
			if (!noWaveOut)
			{
				waveOut.Init(buffer.ToSampleProvider());

				playing = 0;

				comboBox1.Enabled = false;
				comboBox2.Enabled = false;
				comboBox3.Enabled = false;
				comboBox5.Enabled = false;
			}
			else
				cbCompressBypass.Checked = true;
		}

		private void StopPress()
		{
			waveIn.StopRecording();
			waveInSecondary.StopRecording();
			waveOut.Stop();
			playing = 0;

			comboBox1.Enabled = true;
			comboBox2.Enabled = true;
			comboBox3.Enabled = true;
			comboBox5.Enabled = true;
		}







		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (waveIn != null)
			{
				waveIn.DataAvailable -= waveIn_DataAvailable;
				waveIn.StopRecording();
				waveIn.Dispose();
			}

			waveIn = new WaveInEvent() { DeviceNumber = comboBox1.SelectedIndex };
			waveIn.WaveFormat = new WaveFormat(waveSanplesPesSec, 16, 2);
			waveIn.DataAvailable += waveIn_DataAvailable;
			waveIn.BufferMilliseconds = 15;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (waveOut != null)
			{
				waveOut.Stop();
				waveOut.Dispose();
			}

			if (comboBox2.SelectedItem.ToString() == " - NO out -") { noWaveOut = true; return; } else noWaveOut = false;

			waveOut = new WaveOut() { DeviceNumber = comboBox2.SelectedIndex };
			waveOut.NumberOfBuffers = 8;
			waveOut.DesiredLatency = 70;
		}





		private void tbCompPreamp_ValueChanged(object sender, EventArgs e)
		{
			db_preAmp = tbCompPreamp.Value;
			label3.Text = db_preAmp.ToString("0dB");
		}

		private void tbCompTreshold_ValueChanged(object sender, EventArgs e)
		{
			db_treshold = tbCompTreshold.Value;
			label4.Text = db_treshold.ToString("0dB");
			if (db_treshold < db_ntreshold) tbCompNTreshold.Value = tbCompTreshold.Value;
		}

		private void tbCompRatio_ValueChanged(object sender, EventArgs e)
		{
			db_ratio = tbCompRatio.Value / 10f;
			label6.Text = db_ratio.ToString("1:0.0");
		}

		private void tbCompPostAmp_ValueChanged(object sender, EventArgs e)
		{
			db_postAmp = tbCompPostAmp.Value;
			label8.Text = db_postAmp.ToString("0dB");
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
			db_nratio = tbCompNRatio.Value * 0.05f;
			label10.Text = db_nratio.ToString("1:0.0");
		}

		private void tbCompNRatio_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
				tbCompNRatio.Value = 20;
		}

		private void tbCompLimit_ValueChanged(object sender, EventArgs e)
		{
			db_limit = tbCompLimit.Value * 0.5f;
			label12.Text = db_limit.ToString("0.0dB");
		}

		private void tbCompLimit_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
				tbCompLimit.Value = -8;
		}

		private void cbCompressBypass_CheckedChanged(object sender, EventArgs e)
		{
			bool c = !cbCompressBypass.Checked;
			grCompress.Enabled = c;
			panel_db_result.Visible = c;
			label_db_result.Visible = c;
			label1.Visible = c;
			panelDelta.Visible = c;
			label19.Visible = c;
			panelDelta.Width = 1;
			panelDelta.Left = 189;

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
			label16.Text = (db_AttSpeed * 15).ToString("0ms");
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
			label21.Text = (db_RelSpeed * 15).ToString("0ms");
		}


		private void bPlay_Click(object sender, EventArgs e)
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

		private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
		{
			waveSanplesPesSec = Int32.Parse(comboBox3.Text);
			comboBox1_SelectedIndexChanged(null, null);
			comboBox2_SelectedIndexChanged(null, null);
		}

		private void tbCompNTreshold_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Right)
				tbCompNTreshold.Value = -36;
		}

		private void tbCompNTreshold_ValueChanged(object sender, EventArgs e)
		{
			db_ntreshold = tbCompNTreshold.Value;
			label18.Text = (db_ntreshold).ToString("0dB");
			if (db_treshold < db_ntreshold) tbCompTreshold.Value = tbCompNTreshold.Value;
		}

		private void button3_Click(object sender, EventArgs e)
		{
			WindowState = FormWindowState.Minimized;
			Hide();
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

		private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (waveInSecondary != null)
			{
				waveInSecondary.DataAvailable -= waveIn_DataAvailable;
				waveInSecondary.StopRecording();
				waveInSecondary.Dispose();
			}
			if (comboBox5.Text.Contains("No input")) return;

			waveInSecondary = new WaveInEvent() { DeviceNumber = comboBox5.SelectedIndex };
			waveInSecondary.WaveFormat = new WaveFormat(waveSanplesPesSec, 16, 2);
			waveInSecondary.DataAvailable += waveInSecondary_DataAvailable;
			waveInSecondary.BufferMilliseconds = 15;
		}

		private void waveInSecondary_DataAvailable(object sender, WaveInEventArgs e)
		{
			throw new NotImplementedException();
		}
	}
}
