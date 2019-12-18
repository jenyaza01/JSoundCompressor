namespace JSoundCompressor
{
    partial class FormMain
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.cbInput1 = new System.Windows.Forms.ComboBox();
			this.cbOutput1 = new System.Windows.Forms.ComboBox();
			this.panel_db_original = new System.Windows.Forms.Panel();
			this.label_IN_FAST = new System.Windows.Forms.Label();
			this.grCompress = new System.Windows.Forms.GroupBox();
			this.labelRelease = new System.Windows.Forms.Label();
			this.labelReleaseVal = new System.Windows.Forms.Label();
			this.tbCompReleaseSpeed = new System.Windows.Forms.TrackBar();
			this.labelAttack = new System.Windows.Forms.Label();
			this.labelLimiterVal = new System.Windows.Forms.Label();
			this.labelLimiter = new System.Windows.Forms.Label();
			this.tbCompLimit = new System.Windows.Forms.TrackBar();
			this.labelNRatioVal = new System.Windows.Forms.Label();
			this.labelNRatio = new System.Windows.Forms.Label();
			this.tbCompNRatio = new System.Windows.Forms.TrackBar();
			this.labelPostAmpVal = new System.Windows.Forms.Label();
			this.labelPostAmp = new System.Windows.Forms.Label();
			this.tbCompPostAmp = new System.Windows.Forms.TrackBar();
			this.labelRatioVal = new System.Windows.Forms.Label();
			this.labelRatio = new System.Windows.Forms.Label();
			this.tbCompRatio = new System.Windows.Forms.TrackBar();
			this.labelTresholdVal = new System.Windows.Forms.Label();
			this.labelPreampVal = new System.Windows.Forms.Label();
			this.labelTreshold = new System.Windows.Forms.Label();
			this.labelNTresholdVal = new System.Windows.Forms.Label();
			this.labelPreamp = new System.Windows.Forms.Label();
			this.tbCompTreshold = new System.Windows.Forms.TrackBar();
			this.labelAttackVal = new System.Windows.Forms.Label();
			this.tbCompPreamp = new System.Windows.Forms.TrackBar();
			this.tbCompAttackSpeed = new System.Windows.Forms.TrackBar();
			this.tbCompNTreshold = new System.Windows.Forms.TrackBar();
			this.labelNTreshold = new System.Windows.Forms.Label();
			this.rbPeak = new System.Windows.Forms.RadioButton();
			this.rbRMS = new System.Windows.Forms.RadioButton();
			this.cbBypass = new System.Windows.Forms.CheckBox();
			this.label_OUT_FAST = new System.Windows.Forms.Label();
			this.panel_db_result = new System.Windows.Forms.Panel();
			this.labelMIX = new System.Windows.Forms.Label();
			this.panelDelta = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pWindowTitle = new System.Windows.Forms.Panel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.bHideTray = new System.Windows.Forms.Button();
			this.bMinimise = new System.Windows.Forms.Button();
			this.bClose = new System.Windows.Forms.Button();
			this.labelWindowTitle = new System.Windows.Forms.Label();
			this.labelIN_SLOW = new System.Windows.Forms.Label();
			this.labelOUT_SLOW = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.bSavePreset = new System.Windows.Forms.Button();
			this.bLoadPreset = new System.Windows.Forms.Button();
			this.cbInput2 = new System.Windows.Forms.ComboBox();
			this.labelMainInput = new System.Windows.Forms.Label();
			this.labelSecondInput = new System.Windows.Forms.Label();
			this.panelCompressor = new System.Windows.Forms.Panel();
			this.bSettings = new System.Windows.Forms.Button();
			this.bPlay = new System.Windows.Forms.Button();
			this.cbOutput2 = new System.Windows.Forms.ComboBox();
			this.labelSecondOutput = new System.Windows.Forms.Label();
			this.grCompress.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCompReleaseSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompLimit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompNRatio)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompPostAmp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompRatio)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompTreshold)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompPreamp)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompAttackSpeed)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompNTreshold)).BeginInit();
			this.pWindowTitle.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.panelCompressor.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbInput1
			// 
			this.cbInput1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbInput1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbInput1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbInput1.FormattingEnabled = true;
			this.cbInput1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbInput1.Location = new System.Drawing.Point(8, 29);
			this.cbInput1.Name = "cbInput1";
			this.cbInput1.Size = new System.Drawing.Size(221, 23);
			this.cbInput1.TabIndex = 0;
			this.cbInput1.SelectedIndexChanged += new System.EventHandler(this.cbInput1_SelectedIndexChanged);
			// 
			// cbOutput1
			// 
			this.cbOutput1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbOutput1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOutput1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbOutput1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbOutput1.FormattingEnabled = true;
			this.cbOutput1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbOutput1.Location = new System.Drawing.Point(10, 392);
			this.cbOutput1.Name = "cbOutput1";
			this.cbOutput1.Size = new System.Drawing.Size(221, 23);
			this.cbOutput1.TabIndex = 1;
			this.cbOutput1.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
			// 
			// panel_db_original
			// 
			this.panel_db_original.BackColor = System.Drawing.Color.LightGreen;
			this.panel_db_original.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_db_original.CausesValidation = false;
			this.panel_db_original.Location = new System.Drawing.Point(48, 7);
			this.panel_db_original.Name = "panel_db_original";
			this.panel_db_original.Size = new System.Drawing.Size(250, 14);
			this.panel_db_original.TabIndex = 4;
			// 
			// label_IN_FAST
			// 
			this.label_IN_FAST.AutoSize = true;
			this.label_IN_FAST.CausesValidation = false;
			this.label_IN_FAST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_IN_FAST.Location = new System.Drawing.Point(9, 5);
			this.label_IN_FAST.Name = "label_IN_FAST";
			this.label_IN_FAST.Size = new System.Drawing.Size(19, 15);
			this.label_IN_FAST.TabIndex = 7;
			this.label_IN_FAST.Text = "IN";
			// 
			// grCompress
			// 
			this.grCompress.Controls.Add(this.labelRelease);
			this.grCompress.Controls.Add(this.labelReleaseVal);
			this.grCompress.Controls.Add(this.tbCompReleaseSpeed);
			this.grCompress.Controls.Add(this.labelAttack);
			this.grCompress.Controls.Add(this.labelLimiterVal);
			this.grCompress.Controls.Add(this.labelLimiter);
			this.grCompress.Controls.Add(this.tbCompLimit);
			this.grCompress.Controls.Add(this.labelNRatioVal);
			this.grCompress.Controls.Add(this.labelNRatio);
			this.grCompress.Controls.Add(this.tbCompNRatio);
			this.grCompress.Controls.Add(this.labelPostAmpVal);
			this.grCompress.Controls.Add(this.labelPostAmp);
			this.grCompress.Controls.Add(this.tbCompPostAmp);
			this.grCompress.Controls.Add(this.labelRatioVal);
			this.grCompress.Controls.Add(this.labelRatio);
			this.grCompress.Controls.Add(this.tbCompRatio);
			this.grCompress.Controls.Add(this.labelTresholdVal);
			this.grCompress.Controls.Add(this.labelPreampVal);
			this.grCompress.Controls.Add(this.labelTreshold);
			this.grCompress.Controls.Add(this.labelNTresholdVal);
			this.grCompress.Controls.Add(this.labelPreamp);
			this.grCompress.Controls.Add(this.tbCompTreshold);
			this.grCompress.Controls.Add(this.labelAttackVal);
			this.grCompress.Controls.Add(this.tbCompPreamp);
			this.grCompress.Controls.Add(this.tbCompAttackSpeed);
			this.grCompress.Controls.Add(this.tbCompNTreshold);
			this.grCompress.Controls.Add(this.labelNTreshold);
			this.grCompress.Location = new System.Drawing.Point(3, 103);
			this.grCompress.Name = "grCompress";
			this.grCompress.Size = new System.Drawing.Size(383, 286);
			this.grCompress.TabIndex = 9;
			this.grCompress.TabStop = false;
			this.grCompress.Text = "Compressor";
			// 
			// labelRelease
			// 
			this.labelRelease.AutoSize = true;
			this.labelRelease.Location = new System.Drawing.Point(9, 85);
			this.labelRelease.Name = "labelRelease";
			this.labelRelease.Size = new System.Drawing.Size(46, 13);
			this.labelRelease.TabIndex = 21;
			this.labelRelease.Text = "Release";
			// 
			// labelReleaseVal
			// 
			this.labelReleaseVal.AutoSize = true;
			this.labelReleaseVal.Location = new System.Drawing.Point(345, 87);
			this.labelReleaseVal.Name = "labelReleaseVal";
			this.labelReleaseVal.Size = new System.Drawing.Size(32, 13);
			this.labelReleaseVal.TabIndex = 20;
			this.labelReleaseVal.Text = "75ms";
			// 
			// tbCompReleaseSpeed
			// 
			this.tbCompReleaseSpeed.AutoSize = false;
			this.tbCompReleaseSpeed.Location = new System.Drawing.Point(55, 84);
			this.tbCompReleaseSpeed.Maximum = 120;
			this.tbCompReleaseSpeed.Name = "tbCompReleaseSpeed";
			this.tbCompReleaseSpeed.Size = new System.Drawing.Size(282, 23);
			this.tbCompReleaseSpeed.TabIndex = 19;
			this.tbCompReleaseSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompReleaseSpeed.Value = 6;
			this.tbCompReleaseSpeed.ValueChanged += new System.EventHandler(this.tbCompReleaseSpeed_ValueChanged);
			this.tbCompReleaseSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompReleaseSpeed_MouseDown);
			// 
			// labelAttack
			// 
			this.labelAttack.AutoSize = true;
			this.labelAttack.Location = new System.Drawing.Point(10, 55);
			this.labelAttack.Name = "labelAttack";
			this.labelAttack.Size = new System.Drawing.Size(38, 13);
			this.labelAttack.TabIndex = 18;
			this.labelAttack.Text = "Attack";
			// 
			// labelLimiterVal
			// 
			this.labelLimiterVal.AutoSize = true;
			this.labelLimiterVal.Location = new System.Drawing.Point(339, 262);
			this.labelLimiterVal.Name = "labelLimiterVal";
			this.labelLimiterVal.Size = new System.Drawing.Size(38, 13);
			this.labelLimiterVal.TabIndex = 17;
			this.labelLimiterVal.Text = "-4,0dB";
			// 
			// labelLimiter
			// 
			this.labelLimiter.AutoSize = true;
			this.labelLimiter.Location = new System.Drawing.Point(8, 260);
			this.labelLimiter.Name = "labelLimiter";
			this.labelLimiter.Size = new System.Drawing.Size(37, 13);
			this.labelLimiter.TabIndex = 16;
			this.labelLimiter.Text = "Limiter";
			// 
			// tbCompLimit
			// 
			this.tbCompLimit.AutoSize = false;
			this.tbCompLimit.Location = new System.Drawing.Point(55, 260);
			this.tbCompLimit.Maximum = 0;
			this.tbCompLimit.Minimum = -24;
			this.tbCompLimit.Name = "tbCompLimit";
			this.tbCompLimit.Size = new System.Drawing.Size(282, 23);
			this.tbCompLimit.TabIndex = 15;
			this.tbCompLimit.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompLimit.Value = -8;
			this.tbCompLimit.ValueChanged += new System.EventHandler(this.tbCompLimit_ValueChanged);
			this.tbCompLimit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompLimit_MouseDown);
			// 
			// labelNRatioVal
			// 
			this.labelNRatioVal.AutoSize = true;
			this.labelNRatioVal.Location = new System.Drawing.Point(342, 204);
			this.labelNRatioVal.Name = "labelNRatioVal";
			this.labelNRatioVal.Size = new System.Drawing.Size(31, 13);
			this.labelNRatioVal.TabIndex = 14;
			this.labelNRatioVal.Text = "1:1,0";
			// 
			// labelNRatio
			// 
			this.labelNRatio.AutoSize = true;
			this.labelNRatio.Location = new System.Drawing.Point(7, 202);
			this.labelNRatio.Name = "labelNRatio";
			this.labelNRatio.Size = new System.Drawing.Size(40, 13);
			this.labelNRatio.TabIndex = 13;
			this.labelNRatio.Text = "NRatio";
			// 
			// tbCompNRatio
			// 
			this.tbCompNRatio.AutoSize = false;
			this.tbCompNRatio.Location = new System.Drawing.Point(55, 201);
			this.tbCompNRatio.Maximum = 20;
			this.tbCompNRatio.Minimum = 3;
			this.tbCompNRatio.Name = "tbCompNRatio";
			this.tbCompNRatio.Size = new System.Drawing.Size(282, 23);
			this.tbCompNRatio.TabIndex = 12;
			this.tbCompNRatio.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompNRatio.Value = 10;
			this.tbCompNRatio.ValueChanged += new System.EventHandler(this.tbCompNRatio_ValueChanged);
			this.tbCompNRatio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompNRatio_MouseDown);
			// 
			// labelPostAmpVal
			// 
			this.labelPostAmpVal.AutoSize = true;
			this.labelPostAmpVal.Location = new System.Drawing.Point(344, 233);
			this.labelPostAmpVal.Name = "labelPostAmpVal";
			this.labelPostAmpVal.Size = new System.Drawing.Size(26, 13);
			this.labelPostAmpVal.TabIndex = 11;
			this.labelPostAmpVal.Text = "0dB";
			// 
			// labelPostAmp
			// 
			this.labelPostAmp.AutoSize = true;
			this.labelPostAmp.Location = new System.Drawing.Point(4, 231);
			this.labelPostAmp.Name = "labelPostAmp";
			this.labelPostAmp.Size = new System.Drawing.Size(49, 13);
			this.labelPostAmp.TabIndex = 10;
			this.labelPostAmp.Text = "PostAmp";
			// 
			// tbCompPostAmp
			// 
			this.tbCompPostAmp.AutoSize = false;
			this.tbCompPostAmp.Location = new System.Drawing.Point(55, 230);
			this.tbCompPostAmp.Maximum = 30;
			this.tbCompPostAmp.Minimum = -20;
			this.tbCompPostAmp.Name = "tbCompPostAmp";
			this.tbCompPostAmp.Size = new System.Drawing.Size(282, 23);
			this.tbCompPostAmp.TabIndex = 9;
			this.tbCompPostAmp.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompPostAmp.ValueChanged += new System.EventHandler(this.tbCompPostAmp_ValueChanged);
			this.tbCompPostAmp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompPostAmp_MouseDown);
			// 
			// labelRatioVal
			// 
			this.labelRatioVal.AutoSize = true;
			this.labelRatioVal.Location = new System.Drawing.Point(341, 145);
			this.labelRatioVal.Name = "labelRatioVal";
			this.labelRatioVal.Size = new System.Drawing.Size(31, 13);
			this.labelRatioVal.TabIndex = 8;
			this.labelRatioVal.Text = "1:2,0";
			// 
			// labelRatio
			// 
			this.labelRatio.AutoSize = true;
			this.labelRatio.Location = new System.Drawing.Point(11, 143);
			this.labelRatio.Name = "labelRatio";
			this.labelRatio.Size = new System.Drawing.Size(32, 13);
			this.labelRatio.TabIndex = 7;
			this.labelRatio.Text = "Ratio";
			// 
			// tbCompRatio
			// 
			this.tbCompRatio.AutoSize = false;
			this.tbCompRatio.Location = new System.Drawing.Point(55, 142);
			this.tbCompRatio.Maximum = 120;
			this.tbCompRatio.Minimum = 4;
			this.tbCompRatio.Name = "tbCompRatio";
			this.tbCompRatio.Size = new System.Drawing.Size(282, 23);
			this.tbCompRatio.TabIndex = 6;
			this.tbCompRatio.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompRatio.Value = 20;
			this.tbCompRatio.ValueChanged += new System.EventHandler(this.tbCompRatio_ValueChanged);
			this.tbCompRatio.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompRatio_MouseDown);
			// 
			// labelTresholdVal
			// 
			this.labelTresholdVal.AutoSize = true;
			this.labelTresholdVal.Location = new System.Drawing.Point(339, 115);
			this.labelTresholdVal.Name = "labelTresholdVal";
			this.labelTresholdVal.Size = new System.Drawing.Size(35, 13);
			this.labelTresholdVal.TabIndex = 5;
			this.labelTresholdVal.Text = "-18dB";
			// 
			// labelPreampVal
			// 
			this.labelPreampVal.AutoSize = true;
			this.labelPreampVal.Location = new System.Drawing.Point(345, 29);
			this.labelPreampVal.Name = "labelPreampVal";
			this.labelPreampVal.Size = new System.Drawing.Size(26, 13);
			this.labelPreampVal.TabIndex = 2;
			this.labelPreampVal.Text = "0dB";
			// 
			// labelTreshold
			// 
			this.labelTreshold.AutoSize = true;
			this.labelTreshold.Location = new System.Drawing.Point(4, 113);
			this.labelTreshold.Name = "labelTreshold";
			this.labelTreshold.Size = new System.Drawing.Size(48, 13);
			this.labelTreshold.TabIndex = 4;
			this.labelTreshold.Text = "Treshold";
			// 
			// labelNTresholdVal
			// 
			this.labelNTresholdVal.AutoSize = true;
			this.labelNTresholdVal.Location = new System.Drawing.Point(339, 175);
			this.labelNTresholdVal.Name = "labelNTresholdVal";
			this.labelNTresholdVal.Size = new System.Drawing.Size(35, 13);
			this.labelNTresholdVal.TabIndex = 5;
			this.labelNTresholdVal.Text = "-36dB";
			// 
			// labelPreamp
			// 
			this.labelPreamp.AutoSize = true;
			this.labelPreamp.Location = new System.Drawing.Point(7, 26);
			this.labelPreamp.Name = "labelPreamp";
			this.labelPreamp.Size = new System.Drawing.Size(44, 13);
			this.labelPreamp.TabIndex = 1;
			this.labelPreamp.Text = "PreAmp";
			// 
			// tbCompTreshold
			// 
			this.tbCompTreshold.AutoSize = false;
			this.tbCompTreshold.Location = new System.Drawing.Point(55, 113);
			this.tbCompTreshold.Maximum = 0;
			this.tbCompTreshold.Minimum = -40;
			this.tbCompTreshold.Name = "tbCompTreshold";
			this.tbCompTreshold.Size = new System.Drawing.Size(282, 23);
			this.tbCompTreshold.TabIndex = 3;
			this.tbCompTreshold.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompTreshold.Value = -18;
			this.tbCompTreshold.ValueChanged += new System.EventHandler(this.tbCompTreshold_ValueChanged);
			this.tbCompTreshold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompTreshold_MouseDown);
			// 
			// labelAttackVal
			// 
			this.labelAttackVal.AutoSize = true;
			this.labelAttackVal.Location = new System.Drawing.Point(345, 58);
			this.labelAttackVal.Name = "labelAttackVal";
			this.labelAttackVal.Size = new System.Drawing.Size(32, 13);
			this.labelAttackVal.TabIndex = 2;
			this.labelAttackVal.Text = "45ms";
			// 
			// tbCompPreamp
			// 
			this.tbCompPreamp.AutoSize = false;
			this.tbCompPreamp.Location = new System.Drawing.Point(55, 26);
			this.tbCompPreamp.Maximum = 30;
			this.tbCompPreamp.Minimum = -30;
			this.tbCompPreamp.Name = "tbCompPreamp";
			this.tbCompPreamp.Size = new System.Drawing.Size(282, 23);
			this.tbCompPreamp.TabIndex = 0;
			this.tbCompPreamp.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompPreamp.ValueChanged += new System.EventHandler(this.tbCompPreamp_ValueChanged);
			this.tbCompPreamp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompPreamp_MouseDown);
			// 
			// tbCompAttackSpeed
			// 
			this.tbCompAttackSpeed.AutoSize = false;
			this.tbCompAttackSpeed.Location = new System.Drawing.Point(55, 54);
			this.tbCompAttackSpeed.Maximum = 50;
			this.tbCompAttackSpeed.Name = "tbCompAttackSpeed";
			this.tbCompAttackSpeed.Size = new System.Drawing.Size(282, 23);
			this.tbCompAttackSpeed.TabIndex = 0;
			this.tbCompAttackSpeed.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompAttackSpeed.Value = 4;
			this.tbCompAttackSpeed.ValueChanged += new System.EventHandler(this.tbCompAttackSpeed_ValueChanged);
			this.tbCompAttackSpeed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompAttackSpeed_MouseDown);
			// 
			// tbCompNTreshold
			// 
			this.tbCompNTreshold.AutoSize = false;
			this.tbCompNTreshold.Location = new System.Drawing.Point(55, 171);
			this.tbCompNTreshold.Maximum = -12;
			this.tbCompNTreshold.Minimum = -50;
			this.tbCompNTreshold.Name = "tbCompNTreshold";
			this.tbCompNTreshold.Size = new System.Drawing.Size(282, 23);
			this.tbCompNTreshold.TabIndex = 3;
			this.tbCompNTreshold.TickStyle = System.Windows.Forms.TickStyle.None;
			this.tbCompNTreshold.Value = -36;
			this.tbCompNTreshold.ValueChanged += new System.EventHandler(this.tbCompNTreshold_ValueChanged);
			this.tbCompNTreshold.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompNTreshold_MouseDown);
			// 
			// labelNTreshold
			// 
			this.labelNTreshold.AutoSize = true;
			this.labelNTreshold.Location = new System.Drawing.Point(2, 173);
			this.labelNTreshold.Name = "labelNTreshold";
			this.labelNTreshold.Size = new System.Drawing.Size(56, 13);
			this.labelNTreshold.TabIndex = 4;
			this.labelNTreshold.Text = "NTreshold";
			// 
			// rbPeak
			// 
			this.rbPeak.AutoSize = true;
			this.rbPeak.Location = new System.Drawing.Point(126, 68);
			this.rbPeak.Name = "rbPeak";
			this.rbPeak.Size = new System.Drawing.Size(50, 17);
			this.rbPeak.TabIndex = 23;
			this.rbPeak.TabStop = true;
			this.rbPeak.Text = "Peak";
			this.rbPeak.UseVisualStyleBackColor = true;
			// 
			// rbRMS
			// 
			this.rbRMS.AutoSize = true;
			this.rbRMS.Checked = true;
			this.rbRMS.Location = new System.Drawing.Point(207, 68);
			this.rbRMS.Name = "rbRMS";
			this.rbRMS.Size = new System.Drawing.Size(49, 17);
			this.rbRMS.TabIndex = 22;
			this.rbRMS.TabStop = true;
			this.rbRMS.Text = "RMS";
			this.rbRMS.UseVisualStyleBackColor = true;
			// 
			// cbBypass
			// 
			this.cbBypass.AutoSize = true;
			this.cbBypass.Location = new System.Drawing.Point(115, 103);
			this.cbBypass.Name = "cbBypass";
			this.cbBypass.Size = new System.Drawing.Size(60, 17);
			this.cbBypass.TabIndex = 0;
			this.cbBypass.Text = "Bypass";
			this.cbBypass.UseVisualStyleBackColor = true;
			this.cbBypass.CheckedChanged += new System.EventHandler(this.cbCompressBypass_CheckedChanged);
			// 
			// label_OUT_FAST
			// 
			this.label_OUT_FAST.AutoSize = true;
			this.label_OUT_FAST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label_OUT_FAST.Location = new System.Drawing.Point(8, 45);
			this.label_OUT_FAST.Name = "label_OUT_FAST";
			this.label_OUT_FAST.Size = new System.Drawing.Size(32, 15);
			this.label_OUT_FAST.TabIndex = 11;
			this.label_OUT_FAST.Text = "OUT";
			// 
			// panel_db_result
			// 
			this.panel_db_result.BackColor = System.Drawing.Color.LightGreen;
			this.panel_db_result.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel_db_result.Location = new System.Drawing.Point(48, 47);
			this.panel_db_result.Name = "panel_db_result";
			this.panel_db_result.Size = new System.Drawing.Size(250, 13);
			this.panel_db_result.TabIndex = 10;
			// 
			// labelMIX
			// 
			this.labelMIX.AutoSize = true;
			this.labelMIX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMIX.Location = new System.Drawing.Point(9, 25);
			this.labelMIX.Name = "labelMIX";
			this.labelMIX.Size = new System.Drawing.Size(29, 15);
			this.labelMIX.TabIndex = 13;
			this.labelMIX.Text = "MIX";
			// 
			// panelDelta
			// 
			this.panelDelta.BackColor = System.Drawing.Color.Orange;
			this.panelDelta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panelDelta.Location = new System.Drawing.Point(198, 27);
			this.panelDelta.Name = "panelDelta";
			this.panelDelta.Size = new System.Drawing.Size(1, 14);
			this.panelDelta.TabIndex = 12;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.panel3.Location = new System.Drawing.Point(298, 7);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(1, 14);
			this.panel3.TabIndex = 14;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.panel4.Location = new System.Drawing.Point(248, 7);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(1, 14);
			this.panel4.TabIndex = 15;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.panel5.Location = new System.Drawing.Point(198, 7);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(1, 14);
			this.panel5.TabIndex = 16;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.panel6.Location = new System.Drawing.Point(148, 7);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(1, 14);
			this.panel6.TabIndex = 16;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.panel1.Location = new System.Drawing.Point(98, 7);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1, 14);
			this.panel1.TabIndex = 17;
			// 
			// pWindowTitle
			// 
			this.pWindowTitle.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.pWindowTitle.ContextMenuStrip = this.contextMenuStrip1;
			this.pWindowTitle.Controls.Add(this.bHideTray);
			this.pWindowTitle.Controls.Add(this.bMinimise);
			this.pWindowTitle.Controls.Add(this.bClose);
			this.pWindowTitle.Controls.Add(this.labelWindowTitle);
			this.pWindowTitle.Location = new System.Drawing.Point(0, 0);
			this.pWindowTitle.Name = "pWindowTitle";
			this.pWindowTitle.Size = new System.Drawing.Size(401, 22);
			this.pWindowTitle.TabIndex = 18;
			this.pWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
			this.pWindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
			this.pWindowTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(108, 26);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
			// 
			// bHideTray
			// 
			this.bHideTray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bHideTray.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.bHideTray.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bHideTray.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bHideTray.Location = new System.Drawing.Point(291, -5);
			this.bHideTray.Name = "bHideTray";
			this.bHideTray.Size = new System.Drawing.Size(28, 32);
			this.bHideTray.TabIndex = 3;
			this.bHideTray.Text = ".";
			this.bHideTray.UseVisualStyleBackColor = false;
			this.bHideTray.Click += new System.EventHandler(this.button3_Click);
			// 
			// bMinimise
			// 
			this.bMinimise.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bMinimise.BackColor = System.Drawing.SystemColors.ButtonShadow;
			this.bMinimise.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bMinimise.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bMinimise.Location = new System.Drawing.Point(315, -8);
			this.bMinimise.Name = "bMinimise";
			this.bMinimise.Size = new System.Drawing.Size(40, 32);
			this.bMinimise.TabIndex = 2;
			this.bMinimise.Text = "__";
			this.bMinimise.UseVisualStyleBackColor = false;
			this.bMinimise.Click += new System.EventHandler(this.button2_Click_1);
			// 
			// bClose
			// 
			this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bClose.BackColor = System.Drawing.Color.Crimson;
			this.bClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bClose.Location = new System.Drawing.Point(353, -6);
			this.bClose.Name = "bClose";
			this.bClose.Size = new System.Drawing.Size(48, 33);
			this.bClose.TabIndex = 1;
			this.bClose.Text = "X";
			this.bClose.UseVisualStyleBackColor = false;
			this.bClose.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// labelWindowTitle
			// 
			this.labelWindowTitle.AutoSize = true;
			this.labelWindowTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelWindowTitle.Location = new System.Drawing.Point(6, 2);
			this.labelWindowTitle.Name = "labelWindowTitle";
			this.labelWindowTitle.Size = new System.Drawing.Size(123, 15);
			this.labelWindowTitle.TabIndex = 0;
			this.labelWindowTitle.Text = "JSoundCompressor2";
			this.labelWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseDown);
			this.labelWindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseMove);
			this.labelWindowTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.frmMain_MouseUp);
			// 
			// labelIN_SLOW
			// 
			this.labelIN_SLOW.AutoSize = true;
			this.labelIN_SLOW.CausesValidation = false;
			this.labelIN_SLOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelIN_SLOW.Location = new System.Drawing.Point(355, 5);
			this.labelIN_SLOW.Name = "labelIN_SLOW";
			this.labelIN_SLOW.Size = new System.Drawing.Size(19, 15);
			this.labelIN_SLOW.TabIndex = 7;
			this.labelIN_SLOW.Text = "IN";
			// 
			// labelOUT_SLOW
			// 
			this.labelOUT_SLOW.AutoSize = true;
			this.labelOUT_SLOW.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelOUT_SLOW.Location = new System.Drawing.Point(354, 47);
			this.labelOUT_SLOW.Name = "labelOUT_SLOW";
			this.labelOUT_SLOW.Size = new System.Drawing.Size(32, 15);
			this.labelOUT_SLOW.TabIndex = 11;
			this.labelOUT_SLOW.Text = "OUT";
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.panel2.Location = new System.Drawing.Point(348, 7);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(1, 14);
			this.panel2.TabIndex = 15;
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.Text = "notifyIcon1";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
			// 
			// bSavePreset
			// 
			this.bSavePreset.Location = new System.Drawing.Point(208, 98);
			this.bSavePreset.Name = "bSavePreset";
			this.bSavePreset.Size = new System.Drawing.Size(51, 23);
			this.bSavePreset.TabIndex = 4;
			this.bSavePreset.Text = "save";
			this.bSavePreset.UseVisualStyleBackColor = true;
			this.bSavePreset.Click += new System.EventHandler(this.button4_Click);
			// 
			// bLoadPreset
			// 
			this.bLoadPreset.Location = new System.Drawing.Point(264, 98);
			this.bLoadPreset.Name = "bLoadPreset";
			this.bLoadPreset.Size = new System.Drawing.Size(51, 23);
			this.bLoadPreset.TabIndex = 22;
			this.bLoadPreset.Text = "load";
			this.bLoadPreset.UseVisualStyleBackColor = true;
			this.bLoadPreset.Click += new System.EventHandler(this.button5_Click);
			// 
			// cbInput2
			// 
			this.cbInput2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbInput2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbInput2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbInput2.FormattingEnabled = true;
			this.cbInput2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbInput2.Location = new System.Drawing.Point(8, 60);
			this.cbInput2.Name = "cbInput2";
			this.cbInput2.Size = new System.Drawing.Size(221, 23);
			this.cbInput2.TabIndex = 25;
			this.cbInput2.SelectedIndexChanged += new System.EventHandler(this.cbInput2_SelectedIndexChanged);
			// 
			// labelMainInput
			// 
			this.labelMainInput.AutoSize = true;
			this.labelMainInput.CausesValidation = false;
			this.labelMainInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelMainInput.Location = new System.Drawing.Point(243, 32);
			this.labelMainInput.Name = "labelMainInput";
			this.labelMainInput.Size = new System.Drawing.Size(76, 15);
			this.labelMainInput.TabIndex = 26;
			this.labelMainInput.Text = "MAIN INPUT";
			// 
			// labelSecondInput
			// 
			this.labelSecondInput.AutoSize = true;
			this.labelSecondInput.CausesValidation = false;
			this.labelSecondInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSecondInput.Location = new System.Drawing.Point(241, 63);
			this.labelSecondInput.Name = "labelSecondInput";
			this.labelSecondInput.Size = new System.Drawing.Size(120, 15);
			this.labelSecondInput.TabIndex = 27;
			this.labelSecondInput.Text = "SECONDARY INPUT";
			// 
			// panelCompressor
			// 
			this.panelCompressor.Controls.Add(this.panel_db_original);
			this.panelCompressor.Controls.Add(this.label_IN_FAST);
			this.panelCompressor.Controls.Add(this.panel_db_result);
			this.panelCompressor.Controls.Add(this.label_OUT_FAST);
			this.panelCompressor.Controls.Add(this.bSettings);
			this.panelCompressor.Controls.Add(this.panelDelta);
			this.panelCompressor.Controls.Add(this.bLoadPreset);
			this.panelCompressor.Controls.Add(this.labelMIX);
			this.panelCompressor.Controls.Add(this.bSavePreset);
			this.panelCompressor.Controls.Add(this.cbBypass);
			this.panelCompressor.Controls.Add(this.labelOUT_SLOW);
			this.panelCompressor.Controls.Add(this.bPlay);
			this.panelCompressor.Controls.Add(this.panel3);
			this.panelCompressor.Controls.Add(this.cbOutput1);
			this.panelCompressor.Controls.Add(this.labelIN_SLOW);
			this.panelCompressor.Controls.Add(this.panel4);
			this.panelCompressor.Controls.Add(this.rbPeak);
			this.panelCompressor.Controls.Add(this.panel2);
			this.panelCompressor.Controls.Add(this.rbRMS);
			this.panelCompressor.Controls.Add(this.panel5);
			this.panelCompressor.Controls.Add(this.panel6);
			this.panelCompressor.Controls.Add(this.panel1);
			this.panelCompressor.Controls.Add(this.grCompress);
			this.panelCompressor.Location = new System.Drawing.Point(-1, 85);
			this.panelCompressor.Name = "panelCompressor";
			this.panelCompressor.Size = new System.Drawing.Size(401, 423);
			this.panelCompressor.TabIndex = 29;
			// 
			// bSettings
			// 
			this.bSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bSettings.Location = new System.Drawing.Point(329, 392);
			this.bSettings.Name = "bSettings";
			this.bSettings.Size = new System.Drawing.Size(62, 25);
			this.bSettings.TabIndex = 28;
			this.bSettings.Text = "Options";
			this.bSettings.UseVisualStyleBackColor = true;
			this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
			// 
			// bPlay
			// 
			this.bPlay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.bPlay.Location = new System.Drawing.Point(237, 392);
			this.bPlay.Name = "bPlay";
			this.bPlay.Size = new System.Drawing.Size(88, 25);
			this.bPlay.TabIndex = 3;
			this.bPlay.Text = "Play";
			this.bPlay.UseVisualStyleBackColor = true;
			this.bPlay.Click += new System.EventHandler(this.bPlayStop_Click);
			// 
			// cbOutput2
			// 
			this.cbOutput2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.cbOutput2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOutput2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbOutput2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.cbOutput2.FormattingEnabled = true;
			this.cbOutput2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.cbOutput2.Location = new System.Drawing.Point(8, 514);
			this.cbOutput2.Name = "cbOutput2";
			this.cbOutput2.Size = new System.Drawing.Size(221, 23);
			this.cbOutput2.TabIndex = 30;
			this.cbOutput2.SelectedIndexChanged += new System.EventHandler(this.cbOutput2_SelectedIndexChanged);
			// 
			// labelSecondOutput
			// 
			this.labelSecondOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelSecondOutput.AutoSize = true;
			this.labelSecondOutput.CausesValidation = false;
			this.labelSecondOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelSecondOutput.Location = new System.Drawing.Point(245, 517);
			this.labelSecondOutput.Name = "labelSecondOutput";
			this.labelSecondOutput.Size = new System.Drawing.Size(133, 15);
			this.labelSecondOutput.TabIndex = 31;
			this.labelSecondOutput.Text = "SECONDARY OUTPUT";
			// 
			// FormMain
			// 
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
			this.ClientSize = new System.Drawing.Size(401, 542);
			this.Controls.Add(this.panelCompressor);
			this.Controls.Add(this.cbOutput2);
			this.Controls.Add(this.labelSecondInput);
			this.Controls.Add(this.labelMainInput);
			this.Controls.Add(this.cbInput2);
			this.Controls.Add(this.pWindowTitle);
			this.Controls.Add(this.cbInput1);
			this.Controls.Add(this.labelSecondOutput);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "FormMain";
			this.Text = "JSoundCompressor";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.grCompress.ResumeLayout(false);
			this.grCompress.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbCompReleaseSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompLimit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompNRatio)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompPostAmp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompRatio)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompTreshold)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompPreamp)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompAttackSpeed)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tbCompNTreshold)).EndInit();
			this.pWindowTitle.ResumeLayout(false);
			this.pWindowTitle.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.panelCompressor.ResumeLayout(false);
			this.panelCompressor.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbInput1;
        private System.Windows.Forms.ComboBox cbOutput1;
        private System.Windows.Forms.Panel panel_db_original;
        private System.Windows.Forms.Label label_IN_FAST;
        private System.Windows.Forms.GroupBox grCompress;
        private System.Windows.Forms.CheckBox cbBypass;
        private System.Windows.Forms.TrackBar tbCompPreamp;
        private System.Windows.Forms.Label labelPostAmpVal;
        private System.Windows.Forms.Label labelPostAmp;
        private System.Windows.Forms.TrackBar tbCompPostAmp;
        private System.Windows.Forms.Label labelRatioVal;
        private System.Windows.Forms.Label labelRatio;
        private System.Windows.Forms.TrackBar tbCompRatio;
        private System.Windows.Forms.Label labelTresholdVal;
        private System.Windows.Forms.Label labelTreshold;
        private System.Windows.Forms.TrackBar tbCompTreshold;
        private System.Windows.Forms.Label labelPreampVal;
        private System.Windows.Forms.Label labelPreamp;
        private System.Windows.Forms.Label label_OUT_FAST;
        private System.Windows.Forms.Panel panel_db_result;
        private System.Windows.Forms.Label labelMIX;
        private System.Windows.Forms.Panel panelDelta;
        private System.Windows.Forms.Label labelNRatioVal;
        private System.Windows.Forms.Label labelNRatio;
        private System.Windows.Forms.TrackBar tbCompNRatio;
        private System.Windows.Forms.Label labelLimiterVal;
        private System.Windows.Forms.Label labelLimiter;
        private System.Windows.Forms.TrackBar tbCompLimit;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pWindowTitle;
        private System.Windows.Forms.Label labelWindowTitle;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bMinimise;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbPeak;
        private System.Windows.Forms.RadioButton rbRMS;
        private System.Windows.Forms.Label labelAttack;
        private System.Windows.Forms.Label labelAttackVal;
        private System.Windows.Forms.TrackBar tbCompAttackSpeed;
        private System.Windows.Forms.Label labelNTresholdVal;
        private System.Windows.Forms.Label labelNTreshold;
        private System.Windows.Forms.TrackBar tbCompNTreshold;
        private System.Windows.Forms.Label labelIN_SLOW;
        private System.Windows.Forms.Label labelOUT_SLOW;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelRelease;
        private System.Windows.Forms.Label labelReleaseVal;
        private System.Windows.Forms.TrackBar tbCompReleaseSpeed;
        private System.Windows.Forms.Button bHideTray;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button bSavePreset;
        private System.Windows.Forms.Button bLoadPreset;
		private System.Windows.Forms.ComboBox cbInput2;
		private System.Windows.Forms.Label labelMainInput;
		private System.Windows.Forms.Label labelSecondInput;
		private System.Windows.Forms.Panel panelCompressor;
		private System.Windows.Forms.Button bSettings;
		private System.Windows.Forms.Button bPlay;
		private System.Windows.Forms.ComboBox cbOutput2;
		private System.Windows.Forms.Label labelSecondOutput;
	}
}

