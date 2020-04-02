using System;
using System.Windows.Forms;
using sts = JSoundCompressor.Settings;

namespace JSoundCompressor
{

	public partial class FormSettings : Form
	{
		public FormMain parentForm;

		public FormSettings()
		{
			InitializeComponent();

			if (sts.secondInputEnabled)
				rbTwoInputs.Checked = true;
			else
				rbOneInput.Checked = true;

			if (sts.secondOutputEnabled)
				rbTwoOutputs.Checked = true;
			else
				rbOneOutput.Checked = true;

			cbFreq.Text = sts.freq;
			cbInputMS.Text = sts.inputMS;
			cbOutputMS.Text = sts.outputMS;

		}

		private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!sts.changed) return;
			sts.secondInputEnabled = rbTwoInputs.Checked;
			sts.secondOutputEnabled = rbTwoOutputs.Checked;

			sts.freq = cbFreq.Text;
			sts.inputMS = cbInputMS.Text;
			sts.outputMS = cbOutputMS.Text;
		}
		
		private void bApply_Click(object sender, EventArgs e)
		{
			sts.changed = true;
			Close();
		}

		private void bCansel_Click(object sender, EventArgs e)
		{
			sts.changed = false;
			Close();
		}

		private void rbOneInput_CheckedChanged(object sender, EventArgs e)
		{
			sts.changed = true;
			if (rbOneInput.Checked)
			{
				rbOneOutput.Checked = true;
				rbTwoOutputs.Enabled = false;
			}
			else rbTwoOutputs.Enabled = true;
		}
	}
}
