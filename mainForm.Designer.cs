namespace CompressorK
{
    partial class mainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            dropPanel = new Panel();
            btnReset = new Button();
            boxProgress = new GroupBox();
            chkOpenSourceDir = new CheckBox();
            statusProgress = new Label();
            btnQuitApp = new Button();
            btnCompressVideo = new Button();
            boxFileProperties = new GroupBox();
            propertiesPanel = new Panel();
            lblTimestampFormat = new Label();
            btnFetchFileName = new Button();
            chkUseSourceDir = new CheckBox();
            btnBrowseOutputFolder = new Button();
            valueOutputFolder = new TextBox();
            lblOutputFolder = new Label();
            chkIncludeTimestamp = new CheckBox();
            valueFileName = new TextBox();
            lblFileName = new Label();
            suffixFileName = new Label();
            boxCompressionSettings = new GroupBox();
            compressionPanel = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            valueTargetFileSize = new NumericUpDown();
            suffixTargetPercentage2 = new Label();
            suffixTargetPercentage = new TextBox();
            chkUseFileSize = new CheckBox();
            valueTargetPercentage = new TrackBar();
            suffixTargetFileSize = new Label();
            lblTargetPercentage = new Label();
            lblTargetFileSize = new Label();
            currentVideoFile = new Label();
            topPanel = new Panel();
            separatorPanel1 = new Panel();
            optionsPanel = new Panel();
            btnResetWarning = new Button();
            warningNotice = new Label();
            label1 = new Label();
            formTip = new ToolTip(components);
            dropPanel.SuspendLayout();
            boxProgress.SuspendLayout();
            boxFileProperties.SuspendLayout();
            propertiesPanel.SuspendLayout();
            boxCompressionSettings.SuspendLayout();
            compressionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)valueTargetFileSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)valueTargetPercentage).BeginInit();
            topPanel.SuspendLayout();
            optionsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // dropPanel
            // 
            dropPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dropPanel.Controls.Add(btnReset);
            dropPanel.Controls.Add(boxProgress);
            dropPanel.Controls.Add(btnQuitApp);
            dropPanel.Controls.Add(btnCompressVideo);
            dropPanel.Controls.Add(boxFileProperties);
            dropPanel.Controls.Add(boxCompressionSettings);
            dropPanel.Location = new Point(12, 60);
            dropPanel.Name = "dropPanel";
            dropPanel.Size = new Size(629, 422);
            dropPanel.TabIndex = 0;
            // 
            // btnReset
            // 
            btnReset.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnReset.Cursor = Cursors.Hand;
            btnReset.Font = new Font("Segoe UI", 11F);
            btnReset.ForeColor = SystemColors.ControlText;
            btnReset.Location = new Point(423, 326);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(39, 39);
            btnReset.TabIndex = 7;
            btnReset.Text = "♻️";
            formTip.SetToolTip(btnReset, "Reset values and start over from scratch");
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // boxProgress
            // 
            boxProgress.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            boxProgress.Controls.Add(chkOpenSourceDir);
            boxProgress.Controls.Add(statusProgress);
            boxProgress.Location = new Point(3, 326);
            boxProgress.Name = "boxProgress";
            boxProgress.Size = new Size(285, 84);
            boxProgress.TabIndex = 6;
            boxProgress.TabStop = false;
            boxProgress.Text = " Settings ";
            // 
            // chkOpenSourceDir
            // 
            chkOpenSourceDir.Checked = true;
            chkOpenSourceDir.CheckState = CheckState.Checked;
            chkOpenSourceDir.Cursor = Cursors.Hand;
            chkOpenSourceDir.Location = new Point(9, 22);
            chkOpenSourceDir.Name = "chkOpenSourceDir";
            chkOpenSourceDir.Size = new Size(270, 23);
            chkOpenSourceDir.TabIndex = 7;
            chkOpenSourceDir.Text = "Open output folder on completion";
            formTip.SetToolTip(chkOpenSourceDir, "Open the output folder and select the converted video upon completion");
            chkOpenSourceDir.UseVisualStyleBackColor = true;
            // 
            // statusProgress
            // 
            statusProgress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            statusProgress.Location = new Point(6, 51);
            statusProgress.Name = "statusProgress";
            statusProgress.Size = new Size(273, 23);
            statusProgress.TabIndex = 5;
            statusProgress.TextAlign = ContentAlignment.MiddleCenter;
            statusProgress.Visible = false;
            // 
            // btnQuitApp
            // 
            btnQuitApp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnQuitApp.Cursor = Cursors.Hand;
            btnQuitApp.ForeColor = Color.IndianRed;
            btnQuitApp.Location = new Point(468, 326);
            btnQuitApp.Name = "btnQuitApp";
            btnQuitApp.Size = new Size(158, 39);
            btnQuitApp.TabIndex = 4;
            btnQuitApp.Text = "❌ Quit";
            formTip.SetToolTip(btnQuitApp, "Quit the app");
            btnQuitApp.UseVisualStyleBackColor = true;
            btnQuitApp.Click += btnQuitApp_Click;
            // 
            // btnCompressVideo
            // 
            btnCompressVideo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCompressVideo.Cursor = Cursors.Hand;
            btnCompressVideo.Font = new Font("Segoe UI", 9F);
            btnCompressVideo.Location = new Point(468, 371);
            btnCompressVideo.Name = "btnCompressVideo";
            btnCompressVideo.Size = new Size(158, 39);
            btnCompressVideo.TabIndex = 3;
            btnCompressVideo.Text = "✔️ Compress video";
            formTip.SetToolTip(btnCompressVideo, "Begin compressing the video");
            btnCompressVideo.UseVisualStyleBackColor = true;
            btnCompressVideo.Click += btnCompressVideo_Click;
            // 
            // boxFileProperties
            // 
            boxFileProperties.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            boxFileProperties.Controls.Add(propertiesPanel);
            boxFileProperties.Location = new Point(3, 150);
            boxFileProperties.Name = "boxFileProperties";
            boxFileProperties.Size = new Size(623, 155);
            boxFileProperties.TabIndex = 2;
            boxFileProperties.TabStop = false;
            boxFileProperties.Text = " File properties ";
            // 
            // propertiesPanel
            // 
            propertiesPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            propertiesPanel.Controls.Add(lblTimestampFormat);
            propertiesPanel.Controls.Add(btnFetchFileName);
            propertiesPanel.Controls.Add(chkUseSourceDir);
            propertiesPanel.Controls.Add(btnBrowseOutputFolder);
            propertiesPanel.Controls.Add(valueOutputFolder);
            propertiesPanel.Controls.Add(lblOutputFolder);
            propertiesPanel.Controls.Add(chkIncludeTimestamp);
            propertiesPanel.Controls.Add(valueFileName);
            propertiesPanel.Controls.Add(lblFileName);
            propertiesPanel.Controls.Add(suffixFileName);
            propertiesPanel.Location = new Point(6, 22);
            propertiesPanel.Name = "propertiesPanel";
            propertiesPanel.Size = new Size(611, 127);
            propertiesPanel.TabIndex = 0;
            // 
            // lblTimestampFormat
            // 
            lblTimestampFormat.Font = new Font("Segoe UI", 7F);
            lblTimestampFormat.Location = new Point(219, 93);
            lblTimestampFormat.Name = "lblTimestampFormat";
            lblTimestampFormat.Size = new Size(389, 23);
            lblTimestampFormat.TabIndex = 12;
            lblTimestampFormat.Text = "Format:";
            lblTimestampFormat.TextAlign = ContentAlignment.MiddleLeft;
            lblTimestampFormat.Visible = false;
            // 
            // btnFetchFileName
            // 
            btnFetchFileName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnFetchFileName.Cursor = Cursors.Hand;
            btnFetchFileName.Font = new Font("Segoe UI", 11F);
            btnFetchFileName.Location = new Point(566, 1);
            btnFetchFileName.Name = "btnFetchFileName";
            btnFetchFileName.Size = new Size(42, 30);
            btnFetchFileName.TabIndex = 11;
            btnFetchFileName.Text = "📥";
            formTip.SetToolTip(btnFetchFileName, "Fetch the full name of the original video and input it");
            btnFetchFileName.UseVisualStyleBackColor = true;
            btnFetchFileName.Click += btnFetchFileName_Click;
            // 
            // chkUseSourceDir
            // 
            chkUseSourceDir.AutoSize = true;
            chkUseSourceDir.Checked = true;
            chkUseSourceDir.CheckState = CheckState.Checked;
            chkUseSourceDir.Cursor = Cursors.Hand;
            chkUseSourceDir.Location = new Point(7, 65);
            chkUseSourceDir.Name = "chkUseSourceDir";
            chkUseSourceDir.Size = new Size(175, 19);
            chkUseSourceDir.TabIndex = 10;
            chkUseSourceDir.Text = "Use source file output folder";
            formTip.SetToolTip(chkUseSourceDir, "Output the converted video into the same folder as the original video");
            chkUseSourceDir.UseVisualStyleBackColor = true;
            chkUseSourceDir.CheckedChanged += chkUseSourceDir_CheckedChanged;
            // 
            // btnBrowseOutputFolder
            // 
            btnBrowseOutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBrowseOutputFolder.Cursor = Cursors.Hand;
            btnBrowseOutputFolder.Enabled = false;
            btnBrowseOutputFolder.Font = new Font("Segoe UI", 11F);
            btnBrowseOutputFolder.Location = new Point(566, 30);
            btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            btnBrowseOutputFolder.Size = new Size(42, 30);
            btnBrowseOutputFolder.TabIndex = 7;
            btnBrowseOutputFolder.Text = "📤";
            btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            btnBrowseOutputFolder.Click += btnBrowseDir_Click;
            // 
            // valueOutputFolder
            // 
            valueOutputFolder.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueOutputFolder.Enabled = false;
            valueOutputFolder.Location = new Point(163, 33);
            valueOutputFolder.Name = "valueOutputFolder";
            valueOutputFolder.PlaceholderText = "C:\\Users\\MyName\\Downloads";
            valueOutputFolder.Size = new Size(397, 23);
            valueOutputFolder.TabIndex = 9;
            // 
            // lblOutputFolder
            // 
            lblOutputFolder.Location = new Point(3, 32);
            lblOutputFolder.Name = "lblOutputFolder";
            lblOutputFolder.Size = new Size(154, 23);
            lblOutputFolder.TabIndex = 8;
            lblOutputFolder.Text = "Output folder:";
            lblOutputFolder.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // chkIncludeTimestamp
            // 
            chkIncludeTimestamp.AutoSize = true;
            chkIncludeTimestamp.Cursor = Cursors.Hand;
            chkIncludeTimestamp.Enabled = false;
            chkIncludeTimestamp.Location = new Point(7, 95);
            chkIncludeTimestamp.Name = "chkIncludeTimestamp";
            chkIncludeTimestamp.Size = new Size(190, 19);
            chkIncludeTimestamp.TabIndex = 7;
            chkIncludeTimestamp.Text = "Include timestamp in file name";
            formTip.SetToolTip(chkIncludeTimestamp, "Include the current timestamp into the name of the converted video");
            chkIncludeTimestamp.UseVisualStyleBackColor = true;
            chkIncludeTimestamp.CheckedChanged += chkIncludeTimestamp_CheckedChanged;
            // 
            // valueFileName
            // 
            valueFileName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueFileName.Location = new Point(163, 4);
            valueFileName.Name = "valueFileName";
            valueFileName.PlaceholderText = "My awesome video";
            valueFileName.Size = new Size(353, 23);
            valueFileName.TabIndex = 5;
            valueFileName.TextChanged += valueFileName_TextChanged;
            // 
            // lblFileName
            // 
            lblFileName.Location = new Point(3, 3);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(154, 23);
            lblFileName.TabIndex = 4;
            lblFileName.Text = "File name:";
            lblFileName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // suffixFileName
            // 
            suffixFileName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            suffixFileName.Location = new Point(522, 4);
            suffixFileName.Name = "suffixFileName";
            suffixFileName.Size = new Size(38, 23);
            suffixFileName.TabIndex = 6;
            suffixFileName.Text = "->";
            suffixFileName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // boxCompressionSettings
            // 
            boxCompressionSettings.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            boxCompressionSettings.Controls.Add(compressionPanel);
            boxCompressionSettings.Location = new Point(3, 3);
            boxCompressionSettings.Name = "boxCompressionSettings";
            boxCompressionSettings.Size = new Size(623, 129);
            boxCompressionSettings.TabIndex = 1;
            boxCompressionSettings.TabStop = false;
            boxCompressionSettings.Text = " Compression settings ";
            // 
            // compressionPanel
            // 
            compressionPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            compressionPanel.Controls.Add(label4);
            compressionPanel.Controls.Add(label3);
            compressionPanel.Controls.Add(label2);
            compressionPanel.Controls.Add(valueTargetFileSize);
            compressionPanel.Controls.Add(suffixTargetPercentage2);
            compressionPanel.Controls.Add(suffixTargetPercentage);
            compressionPanel.Controls.Add(chkUseFileSize);
            compressionPanel.Controls.Add(valueTargetPercentage);
            compressionPanel.Controls.Add(suffixTargetFileSize);
            compressionPanel.Controls.Add(lblTargetPercentage);
            compressionPanel.Controls.Add(lblTargetFileSize);
            compressionPanel.Location = new Point(6, 22);
            compressionPanel.Name = "compressionPanel";
            compressionPanel.Size = new Size(611, 101);
            compressionPanel.TabIndex = 0;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 7F);
            label4.ForeColor = SystemColors.GrayText;
            label4.Location = new Point(322, 83);
            label4.Name = "label4";
            label4.Padding = new Padding(0, 0, 5, 0);
            label4.Size = new Size(51, 16);
            label4.TabIndex = 11;
            label4.Text = "Medium";
            label4.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 7F);
            label3.ForeColor = SystemColors.GrayText;
            label3.Location = new Point(481, 83);
            label3.Name = "label3";
            label3.Padding = new Padding(0, 0, 5, 0);
            label3.Size = new Size(51, 16);
            label3.TabIndex = 10;
            label3.Text = "Low";
            label3.TextAlign = ContentAlignment.TopRight;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 7F);
            label2.ForeColor = SystemColors.GrayText;
            label2.Location = new Point(163, 83);
            label2.Name = "label2";
            label2.Size = new Size(51, 16);
            label2.TabIndex = 9;
            label2.Text = "High";
            // 
            // valueTargetFileSize
            // 
            valueTargetFileSize.Enabled = false;
            valueTargetFileSize.Font = new Font("Segoe UI", 10F);
            valueTargetFileSize.Location = new Point(163, 3);
            valueTargetFileSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            valueTargetFileSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            valueTargetFileSize.Name = "valueTargetFileSize";
            valueTargetFileSize.Size = new Size(103, 25);
            valueTargetFileSize.TabIndex = 8;
            valueTargetFileSize.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // suffixTargetPercentage2
            // 
            suffixTargetPercentage2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            suffixTargetPercentage2.Location = new Point(583, 64);
            suffixTargetPercentage2.Name = "suffixTargetPercentage2";
            suffixTargetPercentage2.Size = new Size(25, 23);
            suffixTargetPercentage2.TabIndex = 7;
            suffixTargetPercentage2.Text = "%";
            suffixTargetPercentage2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // suffixTargetPercentage
            // 
            suffixTargetPercentage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            suffixTargetPercentage.Location = new Point(538, 64);
            suffixTargetPercentage.Name = "suffixTargetPercentage";
            suffixTargetPercentage.Size = new Size(39, 23);
            suffixTargetPercentage.TabIndex = 4;
            suffixTargetPercentage.Text = "1";
            suffixTargetPercentage.TextAlign = HorizontalAlignment.Center;
            // 
            // chkUseFileSize
            // 
            chkUseFileSize.AutoSize = true;
            chkUseFileSize.Checked = true;
            chkUseFileSize.CheckState = CheckState.Checked;
            chkUseFileSize.Cursor = Cursors.Hand;
            chkUseFileSize.Location = new Point(7, 36);
            chkUseFileSize.Name = "chkUseFileSize";
            chkUseFileSize.Size = new Size(129, 19);
            chkUseFileSize.TabIndex = 6;
            chkUseFileSize.Text = "Use size percentage";
            formTip.SetToolTip(chkUseFileSize, "Toggle between targeting a specific file size or targeting how much compression in percent should be applied");
            chkUseFileSize.UseVisualStyleBackColor = true;
            chkUseFileSize.CheckedChanged += chkToggleOption_CheckedChanged;
            // 
            // valueTargetPercentage
            // 
            valueTargetPercentage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            valueTargetPercentage.AutoSize = false;
            valueTargetPercentage.Location = new Point(157, 66);
            valueTargetPercentage.Maximum = 99;
            valueTargetPercentage.Minimum = 1;
            valueTargetPercentage.Name = "valueTargetPercentage";
            valueTargetPercentage.Size = new Size(375, 20);
            valueTargetPercentage.TabIndex = 4;
            valueTargetPercentage.TickStyle = TickStyle.None;
            formTip.SetToolTip(valueTargetPercentage, "How much in percent of the original file should be retained?\r\n\r\nA value of 90% will retain 90% of the file, and apply 10% compression. May not be 100% accurate.");
            valueTargetPercentage.Value = 1;
            valueTargetPercentage.Scroll += valueTargetPercentage_Scroll;
            valueTargetPercentage.ValueChanged += valueTargetPercentage_ValueChanged;
            // 
            // suffixTargetFileSize
            // 
            suffixTargetFileSize.Location = new Point(272, 3);
            suffixTargetFileSize.Name = "suffixTargetFileSize";
            suffixTargetFileSize.Size = new Size(42, 23);
            suffixTargetFileSize.TabIndex = 3;
            suffixTargetFileSize.Text = "MB";
            suffixTargetFileSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTargetPercentage
            // 
            lblTargetPercentage.Location = new Point(3, 63);
            lblTargetPercentage.Name = "lblTargetPercentage";
            lblTargetPercentage.Size = new Size(154, 23);
            lblTargetPercentage.TabIndex = 1;
            lblTargetPercentage.Text = "Retain % of target file size:";
            lblTargetPercentage.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTargetFileSize
            // 
            lblTargetFileSize.Location = new Point(3, 3);
            lblTargetFileSize.Name = "lblTargetFileSize";
            lblTargetFileSize.Size = new Size(154, 23);
            lblTargetFileSize.TabIndex = 0;
            lblTargetFileSize.Text = "Target file size:";
            lblTargetFileSize.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // currentVideoFile
            // 
            currentVideoFile.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            currentVideoFile.Cursor = Cursors.Hand;
            currentVideoFile.Location = new Point(12, 6);
            currentVideoFile.Name = "currentVideoFile";
            currentVideoFile.Size = new Size(629, 16);
            currentVideoFile.TabIndex = 0;
            currentVideoFile.TextAlign = ContentAlignment.MiddleLeft;
            currentVideoFile.Click += currentVideoFile_Click;
            currentVideoFile.MouseClick += currentVideoFile_MouseClick;
            currentVideoFile.MouseEnter += currentVideoFile_MouseEnter;
            currentVideoFile.MouseLeave += currentVideoFile_MouseLeave;
            // 
            // topPanel
            // 
            topPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            topPanel.BackColor = SystemColors.ScrollBar;
            topPanel.Controls.Add(currentVideoFile);
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(653, 28);
            topPanel.TabIndex = 1;
            // 
            // separatorPanel1
            // 
            separatorPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            separatorPanel1.Location = new Point(12, 34);
            separatorPanel1.Name = "separatorPanel1";
            separatorPanel1.Size = new Size(629, 20);
            separatorPanel1.TabIndex = 2;
            // 
            // optionsPanel
            // 
            optionsPanel.AllowDrop = true;
            optionsPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            optionsPanel.Controls.Add(btnResetWarning);
            optionsPanel.Controls.Add(warningNotice);
            optionsPanel.Controls.Add(label1);
            optionsPanel.Cursor = Cursors.Hand;
            optionsPanel.Location = new Point(12, 60);
            optionsPanel.Name = "optionsPanel";
            optionsPanel.Size = new Size(629, 422);
            optionsPanel.TabIndex = 3;
            optionsPanel.Click += optionsPanel_Click;
            optionsPanel.DragDrop += optionsPanel_DragDrop;
            optionsPanel.DragEnter += optionsPanel_DragEnter;
            optionsPanel.DragLeave += optionsPanel_DragLeave;
            // 
            // btnResetWarning
            // 
            btnResetWarning.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnResetWarning.Cursor = Cursors.Hand;
            btnResetWarning.Font = new Font("Segoe UI", 11F);
            btnResetWarning.ForeColor = SystemColors.ControlText;
            btnResetWarning.Location = new Point(12, 371);
            btnResetWarning.Name = "btnResetWarning";
            btnResetWarning.Size = new Size(39, 39);
            btnResetWarning.TabIndex = 8;
            btnResetWarning.Text = "♻️";
            formTip.SetToolTip(btnResetWarning, "Reset the warning notice");
            btnResetWarning.UseVisualStyleBackColor = true;
            btnResetWarning.Click += btnResetWarning_Click;
            // 
            // warningNotice
            // 
            warningNotice.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            warningNotice.Font = new Font("Segoe UI", 9F);
            warningNotice.ForeColor = Color.IndianRed;
            warningNotice.Location = new Point(3, 326);
            warningNotice.Name = "warningNotice";
            warningNotice.Size = new Size(623, 84);
            warningNotice.TabIndex = 1;
            warningNotice.Text = "⚠️ This tool requires ffmpeg to be installed in order to work ⚠️\r\nIf you do not have it installed, click here to follow a guide\r\n\r\nThis message will only be shown once!";
            warningNotice.TextAlign = ContentAlignment.MiddleCenter;
            warningNotice.Visible = false;
            warningNotice.Click += warningNotice_Click;
            warningNotice.MouseEnter += warningNotice_MouseEnter;
            warningNotice.MouseLeave += warningNotice_MouseLeave;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.ForeColor = SystemColors.GrayText;
            label1.Location = new Point(3, 201);
            label1.Name = "label1";
            label1.Size = new Size(623, 20);
            label1.TabIndex = 0;
            label1.Text = "📤 Drag and drop a video file...";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // formTip
            // 
            formTip.ToolTipTitle = "CompressorK";
            // 
            // mainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 493);
            Controls.Add(separatorPanel1);
            Controls.Add(topPanel);
            Controls.Add(optionsPanel);
            Controls.Add(dropPanel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CompressorK";
            Load += mainForm_Load;
            dropPanel.ResumeLayout(false);
            boxProgress.ResumeLayout(false);
            boxFileProperties.ResumeLayout(false);
            propertiesPanel.ResumeLayout(false);
            propertiesPanel.PerformLayout();
            boxCompressionSettings.ResumeLayout(false);
            compressionPanel.ResumeLayout(false);
            compressionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)valueTargetFileSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)valueTargetPercentage).EndInit();
            topPanel.ResumeLayout(false);
            optionsPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel dropPanel;
        private Panel topPanel;
        private Panel separatorPanel1;
        private Panel optionsPanel;
        private Label label1;
        private Label currentVideoFile;
        private GroupBox boxCompressionSettings;
        private Panel compressionPanel;
        private Label lblTargetFileSize;
        private Label lblTargetPercentage;
        private Label suffixTargetFileSize;
        private TrackBar valueTargetPercentage;
        private CheckBox chkUseFileSize;
        private GroupBox boxFileProperties;
        private Panel propertiesPanel;
        private TextBox valueFileName;
        private Label lblFileName;
        private Label suffixFileName;
        private Button btnCompressVideo;
        private TextBox suffixTargetPercentage;
        private Label suffixTargetPercentage2;
        private Button btnQuitApp;
        private GroupBox boxProgress;
        private Label statusProgress;
        private CheckBox chkOpenSourceDir;
        private CheckBox chkIncludeTimestamp;
        private TextBox valueOutputFolder;
        private Label lblOutputFolder;
        private Button btnBrowseOutputFolder;
        private NumericUpDown valueTargetFileSize;
        private CheckBox chkUseSourceDir;
        private Button btnReset;
        private Label label2;
        private Label label3;
        private Label label4;
        private ToolTip formTip;
        private Button btnFetchFileName;
        private Label lblTimestampFormat;
        private Label warningNotice;
        private Button btnResetWarning;
    }
}
