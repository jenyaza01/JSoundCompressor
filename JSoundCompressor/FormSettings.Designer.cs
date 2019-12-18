namespace JSoundCompressor
{
	partial class FormSettings
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cbInputMS = new System.Windows.Forms.ComboBox();
			this.rbTwoInputs = new System.Windows.Forms.RadioButton();
			this.rbOneInput = new System.Windows.Forms.RadioButton();
			this.label9 = new System.Windows.Forms.Label();
			this.cbOutputMS = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cbFreq = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.rbTwoOutputs = new System.Windows.Forms.RadioButton();
			this.bApply = new System.Windows.Forms.Button();
			this.bCansel = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.rbOneOutput = new System.Windows.Forms.RadioButton();
			this.cbPriority = new System.Windows.Forms.ComboBox();
			this.labelPriority = new System.Windows.Forms.Label();
			this.labelSampling = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cbInputMS);
			this.groupBox1.Controls.Add(this.rbTwoInputs);
			this.groupBox1.Controls.Add(this.rbOneInput);
			this.groupBox1.Location = new System.Drawing.Point(3, 31);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(240, 82);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Inputs";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(172, 23);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 12;
			this.label2.Text = "ms buffer";
			// 
			// cbInputMS
			// 
			this.cbInputMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbInputMS.FormattingEnabled = true;
			this.cbInputMS.Items.AddRange(new object[] {
            "15",
            "20",
            "30",
            "50"});
			this.cbInputMS.Location = new System.Drawing.Point(125, 18);
			this.cbInputMS.Name = "cbInputMS";
			this.cbInputMS.Size = new System.Drawing.Size(41, 21);
			this.cbInputMS.TabIndex = 11;
			// 
			// rbTwoInputs
			// 
			this.rbTwoInputs.AutoSize = true;
			this.rbTwoInputs.Location = new System.Drawing.Point(11, 45);
			this.rbTwoInputs.Name = "rbTwoInputs";
			this.rbTwoInputs.Size = new System.Drawing.Size(77, 17);
			this.rbTwoInputs.TabIndex = 1;
			this.rbTwoInputs.Text = "Two inputs";
			this.toolTip1.SetToolTip(this.rbTwoInputs, "Second - always bypass");
			this.rbTwoInputs.UseVisualStyleBackColor = true;
			// 
			// rbOneInput
			// 
			this.rbOneInput.AutoSize = true;
			this.rbOneInput.Checked = true;
			this.rbOneInput.Location = new System.Drawing.Point(12, 19);
			this.rbOneInput.Name = "rbOneInput";
			this.rbOneInput.Size = new System.Drawing.Size(71, 17);
			this.rbOneInput.TabIndex = 0;
			this.rbOneInput.TabStop = true;
			this.rbOneInput.Text = "One input";
			this.rbOneInput.UseVisualStyleBackColor = true;
			this.rbOneInput.CheckedChanged += new System.EventHandler(this.rbOneInput_CheckedChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(172, 21);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(50, 13);
			this.label9.TabIndex = 12;
			this.label9.Text = "ms buffer";
			// 
			// cbOutputMS
			// 
			this.cbOutputMS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOutputMS.FormattingEnabled = true;
			this.cbOutputMS.Items.AddRange(new object[] {
            "50",
            "60",
            "75",
            "100",
            "150",
            "200",
            "300"});
			this.cbOutputMS.Location = new System.Drawing.Point(125, 18);
			this.cbOutputMS.Name = "cbOutputMS";
			this.cbOutputMS.Size = new System.Drawing.Size(41, 21);
			this.cbOutputMS.TabIndex = 11;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(182, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(20, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Hz";
			// 
			// cbFreq
			// 
			this.cbFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFreq.FormattingEnabled = true;
			this.cbFreq.Items.AddRange(new object[] {
            "44100",
            "48000"});
			this.cbFreq.Location = new System.Drawing.Point(118, 6);
			this.cbFreq.Name = "cbFreq";
			this.cbFreq.Size = new System.Drawing.Size(58, 21);
			this.cbFreq.TabIndex = 2;
			// 
			// rbTwoOutputs
			// 
			this.rbTwoOutputs.AutoSize = true;
			this.rbTwoOutputs.Enabled = false;
			this.rbTwoOutputs.Location = new System.Drawing.Point(11, 45);
			this.rbTwoOutputs.Name = "rbTwoOutputs";
			this.rbTwoOutputs.Size = new System.Drawing.Size(84, 17);
			this.rbTwoOutputs.TabIndex = 1;
			this.rbTwoOutputs.Text = "Two outputs";
			this.toolTip1.SetToolTip(this.rbTwoOutputs, "Second - always bypass");
			this.rbTwoOutputs.UseVisualStyleBackColor = true;
			// 
			// bApply
			// 
			this.bApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bApply.Location = new System.Drawing.Point(3, 207);
			this.bApply.Name = "bApply";
			this.bApply.Size = new System.Drawing.Size(119, 28);
			this.bApply.TabIndex = 3;
			this.bApply.Text = "Apply";
			this.bApply.UseVisualStyleBackColor = true;
			this.bApply.Click += new System.EventHandler(this.bApply_Click);
			// 
			// bCansel
			// 
			this.bCansel.Location = new System.Drawing.Point(128, 207);
			this.bCansel.Name = "bCansel";
			this.bCansel.Size = new System.Drawing.Size(115, 28);
			this.bCansel.TabIndex = 4;
			this.bCansel.Text = "Cancel";
			this.bCansel.UseVisualStyleBackColor = true;
			this.bCansel.Click += new System.EventHandler(this.bCansel_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label9);
			this.groupBox2.Controls.Add(this.cbOutputMS);
			this.groupBox2.Controls.Add(this.rbTwoOutputs);
			this.groupBox2.Controls.Add(this.rbOneOutput);
			this.groupBox2.Location = new System.Drawing.Point(3, 119);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(240, 82);
			this.groupBox2.TabIndex = 14;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Outputs";
			// 
			// rbOneOutput
			// 
			this.rbOneOutput.AutoSize = true;
			this.rbOneOutput.Checked = true;
			this.rbOneOutput.Location = new System.Drawing.Point(12, 19);
			this.rbOneOutput.Name = "rbOneOutput";
			this.rbOneOutput.Size = new System.Drawing.Size(78, 17);
			this.rbOneOutput.TabIndex = 0;
			this.rbOneOutput.TabStop = true;
			this.rbOneOutput.Text = "One output";
			this.rbOneOutput.UseVisualStyleBackColor = true;
			// 
			// cbPriority
			// 
			this.cbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPriority.FormattingEnabled = true;
			this.cbPriority.Items.AddRange(new object[] {
            "High",
            "Above Normal",
            "Normal"});
			this.cbPriority.Location = new System.Drawing.Point(75, 256);
			this.cbPriority.Name = "cbPriority";
			this.cbPriority.Size = new System.Drawing.Size(111, 21);
			this.cbPriority.TabIndex = 2;
			this.cbPriority.SelectedIndexChanged += new System.EventHandler(this.cbPriority_SelectedIndexChanged);
			// 
			// labelPriority
			// 
			this.labelPriority.AutoSize = true;
			this.labelPriority.Location = new System.Drawing.Point(31, 259);
			this.labelPriority.Name = "labelPriority";
			this.labelPriority.Size = new System.Drawing.Size(38, 13);
			this.labelPriority.TabIndex = 7;
			this.labelPriority.Text = "Priority";
			// 
			// labelSampling
			// 
			this.labelSampling.AutoSize = true;
			this.labelSampling.Location = new System.Drawing.Point(41, 9);
			this.labelSampling.Name = "labelSampling";
			this.labelSampling.Size = new System.Drawing.Size(71, 13);
			this.labelSampling.TabIndex = 12;
			this.labelSampling.Text = "Sampling freq";
			// 
			// FormSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(255, 292);
			this.Controls.Add(this.labelSampling);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.bCansel);
			this.Controls.Add(this.bApply);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.labelPriority);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbPriority);
			this.Controls.Add(this.cbFreq);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormSettings";
			this.Text = "FormSettings";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ComboBox cbFreq;
		private System.Windows.Forms.RadioButton rbTwoInputs;
		private System.Windows.Forms.RadioButton rbOneInput;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbInputMS;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbOutputMS;
		private System.Windows.Forms.Button bApply;
		private System.Windows.Forms.Button bCansel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rbTwoOutputs;
		private System.Windows.Forms.RadioButton rbOneOutput;
		private System.Windows.Forms.ComboBox cbPriority;
		private System.Windows.Forms.Label labelPriority;
		private System.Windows.Forms.Label labelSampling;
	}
}