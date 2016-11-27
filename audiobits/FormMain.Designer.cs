namespace audiobits
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
            this.buttonPickAudioFile = new System.Windows.Forms.Button();
            this.textBoxAudioFile = new System.Windows.Forms.TextBox();
            this.radioButtonSourceFile = new System.Windows.Forms.RadioButton();
            this.radioButtonSourceLine = new System.Windows.Forms.RadioButton();
            this.comboBoxOutputDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.comboBoxInputDevice = new System.Windows.Forms.ComboBox();
            this.buttonSetSong2 = new System.Windows.Forms.Button();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblPosition = new System.Windows.Forms.Label();
            this.trackBarBitDepth = new System.Windows.Forms.TrackBar();
            this.labelBitDepth = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBoxSource = new System.Windows.Forms.GroupBox();
            this.buttonSong3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBitDepth)).BeginInit();
            this.groupBoxSource.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPickAudioFile
            // 
            this.buttonPickAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickAudioFile.Location = new System.Drawing.Point(814, 23);
            this.buttonPickAudioFile.Name = "buttonPickAudioFile";
            this.buttonPickAudioFile.Size = new System.Drawing.Size(75, 23);
            this.buttonPickAudioFile.TabIndex = 0;
            this.buttonPickAudioFile.Text = "...";
            this.buttonPickAudioFile.UseVisualStyleBackColor = true;
            this.buttonPickAudioFile.Click += new System.EventHandler(this.buttonPickAudioFile_Click);
            // 
            // textBoxAudioFile
            // 
            this.textBoxAudioFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAudioFile.Location = new System.Drawing.Point(143, 25);
            this.textBoxAudioFile.Name = "textBoxAudioFile";
            this.textBoxAudioFile.Size = new System.Drawing.Size(665, 20);
            this.textBoxAudioFile.TabIndex = 1;
            this.textBoxAudioFile.Text = "\\\\192.168.1.251\\d\\media\\mp3\\5th Element - Opera Song.mp3";
            // 
            // radioButtonSourceFile
            // 
            this.radioButtonSourceFile.AutoSize = true;
            this.radioButtonSourceFile.Checked = true;
            this.radioButtonSourceFile.Location = new System.Drawing.Point(42, 26);
            this.radioButtonSourceFile.Name = "radioButtonSourceFile";
            this.radioButtonSourceFile.Size = new System.Drawing.Size(71, 17);
            this.radioButtonSourceFile.TabIndex = 2;
            this.radioButtonSourceFile.TabStop = true;
            this.radioButtonSourceFile.Text = "Audio File";
            this.radioButtonSourceFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonSourceLine
            // 
            this.radioButtonSourceLine.AutoSize = true;
            this.radioButtonSourceLine.Enabled = false;
            this.radioButtonSourceLine.Location = new System.Drawing.Point(42, 109);
            this.radioButtonSourceLine.Name = "radioButtonSourceLine";
            this.radioButtonSourceLine.Size = new System.Drawing.Size(79, 17);
            this.radioButtonSourceLine.TabIndex = 3;
            this.radioButtonSourceLine.Text = "Audio Input";
            this.radioButtonSourceLine.UseVisualStyleBackColor = true;
            // 
            // comboBoxOutputDevice
            // 
            this.comboBoxOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOutputDevice.FormattingEnabled = true;
            this.comboBoxOutputDevice.Location = new System.Drawing.Point(155, 188);
            this.comboBoxOutputDevice.Name = "comboBoxOutputDevice";
            this.comboBoxOutputDevice.Size = new System.Drawing.Size(360, 21);
            this.comboBoxOutputDevice.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output Device";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(19, 231);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(111, 231);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 8;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // comboBoxInputDevice
            // 
            this.comboBoxInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInputDevice.Enabled = false;
            this.comboBoxInputDevice.FormattingEnabled = true;
            this.comboBoxInputDevice.Location = new System.Drawing.Point(143, 108);
            this.comboBoxInputDevice.Name = "comboBoxInputDevice";
            this.comboBoxInputDevice.Size = new System.Drawing.Size(366, 21);
            this.comboBoxInputDevice.TabIndex = 9;
            // 
            // buttonSetSong2
            // 
            this.buttonSetSong2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSetSong2.Location = new System.Drawing.Point(814, 90);
            this.buttonSetSong2.Name = "buttonSetSong2";
            this.buttonSetSong2.Size = new System.Drawing.Size(75, 23);
            this.buttonSetSong2.TabIndex = 10;
            this.buttonSetSong2.Text = "Song 2";
            this.buttonSetSong2.UseVisualStyleBackColor = true;
            this.buttonSetSong2.Click += new System.EventHandler(this.button1_Click);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.Location = new System.Drawing.Point(143, 55);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(501, 20);
            this.trackBar1.TabIndex = 11;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            this.trackBar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseDown);
            this.trackBar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBar1_MouseUp);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblPosition
            // 
            this.lblPosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPosition.Location = new System.Drawing.Point(661, 55);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(100, 20);
            this.lblPosition.TabIndex = 12;
            // 
            // trackBarBitDepth
            // 
            this.trackBarBitDepth.LargeChange = 1;
            this.trackBarBitDepth.Location = new System.Drawing.Point(216, 231);
            this.trackBarBitDepth.Maximum = 15;
            this.trackBarBitDepth.Minimum = 1;
            this.trackBarBitDepth.Name = "trackBarBitDepth";
            this.trackBarBitDepth.Size = new System.Drawing.Size(459, 45);
            this.trackBarBitDepth.TabIndex = 14;
            this.trackBarBitDepth.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarBitDepth.Value = 15;
            this.trackBarBitDepth.ValueChanged += new System.EventHandler(this.trackBarBitDepth_ValueChanged);
            // 
            // labelBitDepth
            // 
            this.labelBitDepth.Location = new System.Drawing.Point(702, 245);
            this.labelBitDepth.Name = "labelBitDepth";
            this.labelBitDepth.Size = new System.Drawing.Size(219, 20);
            this.labelBitDepth.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 295);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(591, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Use the slider to reduce the Bit Depth - this assumes a 16bit source which equate" +
    "s to 15 bits of sample + 1 bit indicating sign\r\n";
            // 
            // groupBoxSource
            // 
            this.groupBoxSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSource.Controls.Add(this.label4);
            this.groupBoxSource.Controls.Add(this.buttonSong3);
            this.groupBoxSource.Controls.Add(this.textBoxAudioFile);
            this.groupBoxSource.Controls.Add(this.buttonPickAudioFile);
            this.groupBoxSource.Controls.Add(this.radioButtonSourceFile);
            this.groupBoxSource.Controls.Add(this.radioButtonSourceLine);
            this.groupBoxSource.Controls.Add(this.lblPosition);
            this.groupBoxSource.Controls.Add(this.comboBoxInputDevice);
            this.groupBoxSource.Controls.Add(this.trackBar1);
            this.groupBoxSource.Controls.Add(this.buttonSetSong2);
            this.groupBoxSource.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSource.Name = "groupBoxSource";
            this.groupBoxSource.Size = new System.Drawing.Size(909, 156);
            this.groupBoxSource.TabIndex = 17;
            this.groupBoxSource.TabStop = false;
            this.groupBoxSource.Text = "Source";
            // 
            // buttonSong3
            // 
            this.buttonSong3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSong3.Location = new System.Drawing.Point(814, 119);
            this.buttonSong3.Name = "buttonSong3";
            this.buttonSong3.Size = new System.Drawing.Size(75, 23);
            this.buttonSong3.TabIndex = 13;
            this.buttonSong3.Text = "Song 3";
            this.buttonSong3.UseVisualStyleBackColor = true;
            this.buttonSong3.Click += new System.EventHandler(this.buttonSong3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(390, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Uses the CsCore library to do all the actual work - https://github.com/filoe/csco" +
    "re";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(538, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Live Input Not Yet Implemented";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 404);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBoxSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelBitDepth);
            this.Controls.Add(this.trackBarBitDepth);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxOutputDevice);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Audio Bits";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBitDepth)).EndInit();
            this.groupBoxSource.ResumeLayout(false);
            this.groupBoxSource.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonPickAudioFile;
        private System.Windows.Forms.TextBox textBoxAudioFile;
        private System.Windows.Forms.RadioButton radioButtonSourceFile;
        private System.Windows.Forms.RadioButton radioButtonSourceLine;
        private System.Windows.Forms.ComboBox comboBoxOutputDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ComboBox comboBoxInputDevice;
        private System.Windows.Forms.Button buttonSetSong2;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TrackBar trackBarBitDepth;
        private System.Windows.Forms.Label labelBitDepth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxSource;
        private System.Windows.Forms.Button buttonSong3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

