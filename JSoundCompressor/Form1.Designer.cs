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
            this.pMixIn = new System.Windows.Forms.Panel();
            this.label_IN_FAST = new System.Windows.Forms.Label();
            this.grCompress = new System.Windows.Forms.GroupBox();
            this.labelFLimitVal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelRelease = new System.Windows.Forms.Label();
            this.labelReleaseVal = new System.Windows.Forms.Label();
            this.tbCompReleaseSpeed = new System.Windows.Forms.TrackBar();
            this.labelAttack = new System.Windows.Forms.Label();
            this.tbCompLimitF = new System.Windows.Forms.TrackBar();
            this.labelLimiterVal = new System.Windows.Forms.Label();
            this.labelLimiter = new System.Windows.Forms.Label();
            this.tbCompLimitS = new System.Windows.Forms.TrackBar();
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
            this.cbBypass = new System.Windows.Forms.CheckBox();
            this.labelMIX = new System.Windows.Forms.Label();
            this.panelDelta = new System.Windows.Forms.Panel();
            this.pWindowTitle = new System.Windows.Forms.Panel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysOnTopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bHideTray = new System.Windows.Forms.Button();
            this.bMinimise = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.labelWindowTitle = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.bSavePreset = new System.Windows.Forms.Button();
            this.bLoadPreset = new System.Windows.Forms.Button();
            this.cbInput2 = new System.Windows.Forms.ComboBox();
            this.labelMainInput = new System.Windows.Forms.Label();
            this.labelSecondInput = new System.Windows.Forms.Label();
            this.panelCompressor = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.pMix = new System.Windows.Forms.Panel();
            this.pMixOut = new System.Windows.Forms.Panel();
            this.pMainOut = new System.Windows.Forms.Panel();
            this.pMainIn = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bSettings = new System.Windows.Forms.Button();
            this.bPlay = new System.Windows.Forms.Button();
            this.cbOutput2 = new System.Windows.Forms.ComboBox();
            this.labelSecondOutput = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.grCompress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompReleaseSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompLimitF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompLimitS)).BeginInit();
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
            this.panel9.SuspendLayout();
            this.pMix.SuspendLayout();
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
            this.cbOutput1.Location = new System.Drawing.Point(10, 391);
            this.cbOutput1.Name = "cbOutput1";
            this.cbOutput1.Size = new System.Drawing.Size(221, 23);
            this.cbOutput1.TabIndex = 1;
            this.cbOutput1.SelectedIndexChanged += new System.EventHandler(this.cbOutput_SelectedIndexChanged);
            // 
            // pMixIn
            // 
            this.pMixIn.BackColor = System.Drawing.Color.LightGreen;
            this.pMixIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMixIn.CausesValidation = false;
            this.pMixIn.Location = new System.Drawing.Point(41, 12);
            this.pMixIn.Name = "pMixIn";
            this.pMixIn.Size = new System.Drawing.Size(250, 7);
            this.pMixIn.TabIndex = 4;
            // 
            // label_IN_FAST
            // 
            this.label_IN_FAST.AutoSize = true;
            this.label_IN_FAST.CausesValidation = false;
            this.label_IN_FAST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_IN_FAST.Location = new System.Drawing.Point(18, 6);
            this.label_IN_FAST.Name = "label_IN_FAST";
            this.label_IN_FAST.Size = new System.Drawing.Size(19, 15);
            this.label_IN_FAST.TabIndex = 7;
            this.label_IN_FAST.Text = "IN";
            // 
            // grCompress
            // 
            this.grCompress.Controls.Add(this.labelFLimitVal);
            this.grCompress.Controls.Add(this.label2);
            this.grCompress.Controls.Add(this.labelRelease);
            this.grCompress.Controls.Add(this.labelReleaseVal);
            this.grCompress.Controls.Add(this.tbCompReleaseSpeed);
            this.grCompress.Controls.Add(this.labelAttack);
            this.grCompress.Controls.Add(this.tbCompLimitF);
            this.grCompress.Controls.Add(this.labelLimiterVal);
            this.grCompress.Controls.Add(this.labelLimiter);
            this.grCompress.Controls.Add(this.tbCompLimitS);
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
            this.grCompress.Location = new System.Drawing.Point(9, 66);
            this.grCompress.Name = "grCompress";
            this.grCompress.Size = new System.Drawing.Size(383, 312);
            this.grCompress.TabIndex = 9;
            this.grCompress.TabStop = false;
            this.grCompress.Text = "Compressor";
            // 
            // labelFLimitVal
            // 
            this.labelFLimitVal.AutoSize = true;
            this.labelFLimitVal.Location = new System.Drawing.Point(339, 289);
            this.labelFLimitVal.Name = "labelFLimitVal";
            this.labelFLimitVal.Size = new System.Drawing.Size(38, 13);
            this.labelFLimitVal.TabIndex = 24;
            this.labelFLimitVal.Text = "-4,0dB";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "FLimit";
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
            // tbCompLimitF
            // 
            this.tbCompLimitF.AutoSize = false;
            this.tbCompLimitF.Location = new System.Drawing.Point(55, 288);
            this.tbCompLimitF.Maximum = 0;
            this.tbCompLimitF.Minimum = -48;
            this.tbCompLimitF.Name = "tbCompLimitF";
            this.tbCompLimitF.Size = new System.Drawing.Size(282, 23);
            this.tbCompLimitF.TabIndex = 22;
            this.tbCompLimitF.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCompLimitF.Value = -8;
            this.tbCompLimitF.ValueChanged += new System.EventHandler(this.tbLimitF_ValueChanged);
            this.tbCompLimitF.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompLimitF_MouseDown);
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
            this.labelLimiter.Size = new System.Drawing.Size(35, 13);
            this.labelLimiter.TabIndex = 16;
            this.labelLimiter.Text = "SLimit";
            // 
            // tbCompLimitS
            // 
            this.tbCompLimitS.AutoSize = false;
            this.tbCompLimitS.Location = new System.Drawing.Point(55, 260);
            this.tbCompLimitS.Maximum = 0;
            this.tbCompLimitS.Minimum = -60;
            this.tbCompLimitS.Name = "tbCompLimitS";
            this.tbCompLimitS.Size = new System.Drawing.Size(282, 23);
            this.tbCompLimitS.TabIndex = 15;
            this.tbCompLimitS.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tbCompLimitS.Value = -8;
            this.tbCompLimitS.ValueChanged += new System.EventHandler(this.tbCompLimitS_ValueChanged);
            this.tbCompLimitS.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tbCompLimitS_MouseDown);
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
            this.tbCompNRatio.Maximum = 25;
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
            this.tbCompPostAmp.Minimum = -25;
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
            this.tbCompRatio.Maximum = 100;
            this.tbCompRatio.Minimum = 5;
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
            this.tbCompPreamp.Maximum = 40;
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
            this.tbCompAttackSpeed.Maximum = 40;
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
            this.tbCompNTreshold.Maximum = -6;
            this.tbCompNTreshold.Minimum = -60;
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
            // cbBypass
            // 
            this.cbBypass.AutoSize = true;
            this.cbBypass.Location = new System.Drawing.Point(9, 8);
            this.cbBypass.Name = "cbBypass";
            this.cbBypass.Size = new System.Drawing.Size(60, 17);
            this.cbBypass.TabIndex = 0;
            this.cbBypass.Text = "Bypass";
            this.cbBypass.UseVisualStyleBackColor = true;
            this.cbBypass.CheckedChanged += new System.EventHandler(this.cbCompressBypass_CheckedChanged);
            // 
            // labelMIX
            // 
            this.labelMIX.AutoSize = true;
            this.labelMIX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMIX.Location = new System.Drawing.Point(9, 30);
            this.labelMIX.Name = "labelMIX";
            this.labelMIX.Size = new System.Drawing.Size(29, 15);
            this.labelMIX.TabIndex = 13;
            this.labelMIX.Text = "MIX";
            // 
            // panelDelta
            // 
            this.panelDelta.BackColor = System.Drawing.Color.Orange;
            this.panelDelta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDelta.Location = new System.Drawing.Point(191, 22);
            this.panelDelta.Name = "panelDelta";
            this.panelDelta.Size = new System.Drawing.Size(1, 8);
            this.panelDelta.TabIndex = 12;
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
            this.pWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.pWindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.pWindowTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.alwaysOnTopToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(150, 48);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // alwaysOnTopToolStripMenuItem
            // 
            this.alwaysOnTopToolStripMenuItem.Name = "alwaysOnTopToolStripMenuItem";
            this.alwaysOnTopToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.alwaysOnTopToolStripMenuItem.Text = "Always on top";
            this.alwaysOnTopToolStripMenuItem.Click += new System.EventHandler(this.alwaysOnTopToolStripMenuItem_Click);
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
            this.bMinimise.Click += new System.EventHandler(this.bMinimise_Click);
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
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
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
            this.labelWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.title_MouseDown);
            this.labelWindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.title_MouseMove);
            this.labelWindowTitle.MouseUp += new System.Windows.Forms.MouseEventHandler(this.title_MouseUp);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "JSound Compressor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // bSavePreset
            // 
            this.bSavePreset.Location = new System.Drawing.Point(96, 4);
            this.bSavePreset.Name = "bSavePreset";
            this.bSavePreset.Size = new System.Drawing.Size(51, 23);
            this.bSavePreset.TabIndex = 4;
            this.bSavePreset.Text = "save";
            this.bSavePreset.UseVisualStyleBackColor = true;
            this.bSavePreset.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoadPreset
            // 
            this.bLoadPreset.Location = new System.Drawing.Point(152, 4);
            this.bLoadPreset.Name = "bLoadPreset";
            this.bLoadPreset.Size = new System.Drawing.Size(51, 23);
            this.bLoadPreset.TabIndex = 22;
            this.bLoadPreset.Text = "load";
            this.bLoadPreset.UseVisualStyleBackColor = true;
            this.bLoadPreset.Click += new System.EventHandler(this.bLoad_Click);
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
            this.panelCompressor.Controls.Add(this.panel9);
            this.panelCompressor.Controls.Add(this.pMix);
            this.panelCompressor.Controls.Add(this.bSettings);
            this.panelCompressor.Controls.Add(this.bPlay);
            this.panelCompressor.Controls.Add(this.cbOutput1);
            this.panelCompressor.Controls.Add(this.grCompress);
            this.panelCompressor.Location = new System.Drawing.Point(-1, 86);
            this.panelCompressor.Name = "panelCompressor";
            this.panelCompressor.Size = new System.Drawing.Size(401, 422);
            this.panelCompressor.TabIndex = 29;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.cbBypass);
            this.panel9.Controls.Add(this.bLoadPreset);
            this.panel9.Controls.Add(this.bSavePreset);
            this.panel9.Location = new System.Drawing.Point(109, 58);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(215, 31);
            this.panel9.TabIndex = 32;
            // 
            // pMix
            // 
            this.pMix.Controls.Add(this.pMixIn);
            this.pMix.Controls.Add(this.pMixOut);
            this.pMix.Controls.Add(this.pMainOut);
            this.pMix.Controls.Add(this.label_IN_FAST);
            this.pMix.Controls.Add(this.pMainIn);
            this.pMix.Controls.Add(this.panel1);
            this.pMix.Controls.Add(this.panel6);
            this.pMix.Controls.Add(this.panel5);
            this.pMix.Controls.Add(this.panel2);
            this.pMix.Controls.Add(this.panelDelta);
            this.pMix.Controls.Add(this.panel4);
            this.pMix.Controls.Add(this.labelMIX);
            this.pMix.Controls.Add(this.panel3);
            this.pMix.Location = new System.Drawing.Point(8, 4);
            this.pMix.Name = "pMix";
            this.pMix.Size = new System.Drawing.Size(354, 56);
            this.pMix.TabIndex = 32;
            // 
            // pMixOut
            // 
            this.pMixOut.BackColor = System.Drawing.Color.LightGreen;
            this.pMixOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMixOut.CausesValidation = false;
            this.pMixOut.Location = new System.Drawing.Point(41, 32);
            this.pMixOut.Name = "pMixOut";
            this.pMixOut.Size = new System.Drawing.Size(190, 7);
            this.pMixOut.TabIndex = 7;
            // 
            // pMainOut
            // 
            this.pMainOut.BackColor = System.Drawing.Color.PaleGreen;
            this.pMainOut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMainOut.CausesValidation = false;
            this.pMainOut.Location = new System.Drawing.Point(41, 41);
            this.pMainOut.Name = "pMainOut";
            this.pMainOut.Size = new System.Drawing.Size(225, 7);
            this.pMainOut.TabIndex = 6;
            // 
            // pMainIn
            // 
            this.pMainIn.BackColor = System.Drawing.Color.PaleGreen;
            this.pMainIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pMainIn.CausesValidation = false;
            this.pMainIn.Location = new System.Drawing.Point(41, 3);
            this.pMainIn.Name = "pMainIn";
            this.pMainIn.Size = new System.Drawing.Size(198, 7);
            this.pMainIn.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel1.Location = new System.Drawing.Point(91, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 10);
            this.panel1.TabIndex = 17;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel6.Location = new System.Drawing.Point(141, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1, 10);
            this.panel6.TabIndex = 16;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel5.Location = new System.Drawing.Point(191, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1, 10);
            this.panel5.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel2.Location = new System.Drawing.Point(341, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 10);
            this.panel2.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel4.Location = new System.Drawing.Point(241, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 10);
            this.panel4.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.panel3.Location = new System.Drawing.Point(291, 6);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 10);
            this.panel3.TabIndex = 14;
            // 
            // bSettings
            // 
            this.bSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSettings.Location = new System.Drawing.Point(329, 391);
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
            this.bPlay.Location = new System.Drawing.Point(237, 391);
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
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.LightGreen;
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.CausesValidation = false;
            this.panel8.Location = new System.Drawing.Point(14, 64);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(198, 15);
            this.panel8.TabIndex = 6;
            this.panel8.Visible = false;
            // 
            // FormMain
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(401, 542);
            this.Controls.Add(this.panel8);
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
            ((System.ComponentModel.ISupportInitialize)(this.tbCompLimitF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbCompLimitS)).EndInit();
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
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.pMix.ResumeLayout(false);
            this.pMix.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbInput1;
        private System.Windows.Forms.ComboBox cbOutput1;
        private System.Windows.Forms.Panel pMixIn;
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
        private System.Windows.Forms.Label labelMIX;
        private System.Windows.Forms.Panel panelDelta;
        private System.Windows.Forms.Label labelNRatioVal;
        private System.Windows.Forms.Label labelNRatio;
        private System.Windows.Forms.TrackBar tbCompNRatio;
        private System.Windows.Forms.Label labelLimiterVal;
        private System.Windows.Forms.Label labelLimiter;
        private System.Windows.Forms.TrackBar tbCompLimitS;
        private System.Windows.Forms.Panel pWindowTitle;
        private System.Windows.Forms.Label labelWindowTitle;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bMinimise;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label labelAttack;
        private System.Windows.Forms.Label labelAttackVal;
        private System.Windows.Forms.TrackBar tbCompAttackSpeed;
        private System.Windows.Forms.Label labelNTresholdVal;
        private System.Windows.Forms.Label labelNTreshold;
        private System.Windows.Forms.TrackBar tbCompNTreshold;
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
		private System.Windows.Forms.Panel pMainIn;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel pMix;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel pMainOut;
		private System.Windows.Forms.Label labelFLimitVal;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TrackBar tbCompLimitF;
		private System.Windows.Forms.Panel pMixOut;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.ToolStripMenuItem alwaysOnTopToolStripMenuItem;
	}
}

