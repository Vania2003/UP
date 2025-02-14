namespace Karta_muzyczna
{
    partial class mainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.bChooseFile = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.labelPlaySound = new System.Windows.Forms.Label();
            this.labelWindowsMediaPlayer = new System.Windows.Forms.Label();
            this.labelWaveOutWrite = new System.Windows.Forms.Label();
            this.labelMCI = new System.Windows.Forms.Label();
            this.labelDirectSound = new System.Windows.Forms.Label();
            this.labelRecord = new System.Windows.Forms.Label();
            this.bRecord = new System.Windows.Forms.Button();
            this.bDS_stop = new System.Windows.Forms.Button();
            this.bDS_play = new System.Windows.Forms.Button();
            this.bMCI_stop = new System.Windows.Forms.Button();
            this.bMCI_pause = new System.Windows.Forms.Button();
            this.bMCI_play = new System.Windows.Forms.Button();
            this.bWOW_stop = new System.Windows.Forms.Button();
            this.bWOW_play = new System.Windows.Forms.Button();
            this.bWMP_stop = new System.Windows.Forms.Button();
            this.bWMP_pause = new System.Windows.Forms.Button();
            this.bWMP_play = new System.Windows.Forms.Button();
            this.bPS_stop = new System.Windows.Forms.Button();
            this.bPS_play = new System.Windows.Forms.Button();
            this.bWOW_pause = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bChooseFile
            // 
            this.bChooseFile.Location = new System.Drawing.Point(24, 321);
            this.bChooseFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bChooseFile.Name = "bChooseFile";
            this.bChooseFile.Size = new System.Drawing.Size(106, 39);
            this.bChooseFile.TabIndex = 0;
            this.bChooseFile.Text = "Wybierz plik";
            this.bChooseFile.UseVisualStyleBackColor = true;
            this.bChooseFile.Click += new System.EventHandler(this.bChooseFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(136, 329);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(356, 22);
            this.txtFilePath.TabIndex = 1;
            // 
            // labelPlaySound
            // 
            this.labelPlaySound.AutoSize = true;
            this.labelPlaySound.Location = new System.Drawing.Point(21, 23);
            this.labelPlaySound.Name = "labelPlaySound";
            this.labelPlaySound.Size = new System.Drawing.Size(73, 16);
            this.labelPlaySound.TabIndex = 2;
            this.labelPlaySound.Text = "PlaySound";
            // 
            // labelWindowsMediaPlayer
            // 
            this.labelWindowsMediaPlayer.AutoSize = true;
            this.labelWindowsMediaPlayer.Location = new System.Drawing.Point(21, 140);
            this.labelWindowsMediaPlayer.Name = "labelWindowsMediaPlayer";
            this.labelWindowsMediaPlayer.Size = new System.Drawing.Size(145, 16);
            this.labelWindowsMediaPlayer.TabIndex = 3;
            this.labelWindowsMediaPlayer.Text = "Windows Media Player";
            // 
            // labelWaveOutWrite
            // 
            this.labelWaveOutWrite.AutoSize = true;
            this.labelWaveOutWrite.Location = new System.Drawing.Point(206, 140);
            this.labelWaveOutWrite.Name = "labelWaveOutWrite";
            this.labelWaveOutWrite.Size = new System.Drawing.Size(94, 16);
            this.labelWaveOutWrite.TabIndex = 4;
            this.labelWaveOutWrite.Text = "WaveOutWrite";
            // 
            // labelMCI
            // 
            this.labelMCI.AutoSize = true;
            this.labelMCI.Location = new System.Drawing.Point(383, 140);
            this.labelMCI.Name = "labelMCI";
            this.labelMCI.Size = new System.Drawing.Size(33, 16);
            this.labelMCI.TabIndex = 5;
            this.labelMCI.Text = "MCI ";
            // 
            // labelDirectSound
            // 
            this.labelDirectSound.AutoSize = true;
            this.labelDirectSound.Location = new System.Drawing.Point(206, 23);
            this.labelDirectSound.Name = "labelDirectSound";
            this.labelDirectSound.Size = new System.Drawing.Size(84, 16);
            this.labelDirectSound.TabIndex = 6;
            this.labelDirectSound.Text = "Direct Sound";
            // 
            // labelRecord
            // 
            this.labelRecord.AutoSize = true;
            this.labelRecord.Location = new System.Drawing.Point(377, 23);
            this.labelRecord.Name = "labelRecord";
            this.labelRecord.Size = new System.Drawing.Size(79, 16);
            this.labelRecord.TabIndex = 7;
            this.labelRecord.Text = "Nagrywanie";
            // 
            // bRecord
            // 
            this.bRecord.Location = new System.Drawing.Point(380, 41);
            this.bRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(106, 39);
            this.bRecord.TabIndex = 20;
            this.bRecord.Text = "Record";
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // bDS_stop
            // 
            this.bDS_stop.Location = new System.Drawing.Point(209, 84);
            this.bDS_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bDS_stop.Name = "bDS_stop";
            this.bDS_stop.Size = new System.Drawing.Size(106, 39);
            this.bDS_stop.TabIndex = 19;
            this.bDS_stop.Text = "Stop";
            this.bDS_stop.UseVisualStyleBackColor = true;
            this.bDS_stop.Click += new System.EventHandler(this.bDS_stop_Click);
            // 
            // bDS_play
            // 
            this.bDS_play.Location = new System.Drawing.Point(209, 41);
            this.bDS_play.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bDS_play.Name = "bDS_play";
            this.bDS_play.Size = new System.Drawing.Size(106, 39);
            this.bDS_play.TabIndex = 18;
            this.bDS_play.Text = "Play";
            this.bDS_play.UseVisualStyleBackColor = true;
            this.bDS_play.Click += new System.EventHandler(this.bDS_play_Click);
            // 
            // bMCI_stop
            // 
            this.bMCI_stop.Location = new System.Drawing.Point(386, 244);
            this.bMCI_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bMCI_stop.Name = "bMCI_stop";
            this.bMCI_stop.Size = new System.Drawing.Size(106, 39);
            this.bMCI_stop.TabIndex = 17;
            this.bMCI_stop.Text = "Stop";
            this.bMCI_stop.UseVisualStyleBackColor = true;
            this.bMCI_stop.Click += new System.EventHandler(this.bMCI_stop_Click);
            // 
            // bMCI_pause
            // 
            this.bMCI_pause.Location = new System.Drawing.Point(386, 201);
            this.bMCI_pause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bMCI_pause.Name = "bMCI_pause";
            this.bMCI_pause.Size = new System.Drawing.Size(106, 39);
            this.bMCI_pause.TabIndex = 16;
            this.bMCI_pause.Text = "Pause";
            this.bMCI_pause.UseVisualStyleBackColor = true;
            this.bMCI_pause.Click += new System.EventHandler(this.bMCI_pause_Click);
            // 
            // bMCI_play
            // 
            this.bMCI_play.Location = new System.Drawing.Point(386, 158);
            this.bMCI_play.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bMCI_play.Name = "bMCI_play";
            this.bMCI_play.Size = new System.Drawing.Size(106, 39);
            this.bMCI_play.TabIndex = 15;
            this.bMCI_play.Text = "Play";
            this.bMCI_play.UseVisualStyleBackColor = true;
            this.bMCI_play.Click += new System.EventHandler(this.bMCI_play_Click);
            // 
            // bWOW_stop
            // 
            this.bWOW_stop.Cursor = System.Windows.Forms.Cursors.Default;
            this.bWOW_stop.Location = new System.Drawing.Point(209, 244);
            this.bWOW_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bWOW_stop.Name = "bWOW_stop";
            this.bWOW_stop.Size = new System.Drawing.Size(106, 39);
            this.bWOW_stop.TabIndex = 14;
            this.bWOW_stop.Text = "Stop";
            this.bWOW_stop.UseVisualStyleBackColor = true;
            this.bWOW_stop.Click += new System.EventHandler(this.bWOW_stop_Click);
            // 
            // bWOW_play
            // 
            this.bWOW_play.Location = new System.Drawing.Point(209, 158);
            this.bWOW_play.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bWOW_play.Name = "bWOW_play";
            this.bWOW_play.Size = new System.Drawing.Size(106, 39);
            this.bWOW_play.TabIndex = 13;
            this.bWOW_play.Text = "Play";
            this.bWOW_play.UseVisualStyleBackColor = true;
            this.bWOW_play.Click += new System.EventHandler(this.bWOW_play_Click);
            // 
            // bWMP_stop
            // 
            this.bWMP_stop.Location = new System.Drawing.Point(24, 244);
            this.bWMP_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bWMP_stop.Name = "bWMP_stop";
            this.bWMP_stop.Size = new System.Drawing.Size(106, 39);
            this.bWMP_stop.TabIndex = 12;
            this.bWMP_stop.Text = "Stop";
            this.bWMP_stop.UseVisualStyleBackColor = true;
            this.bWMP_stop.Click += new System.EventHandler(this.bWMP_stop_Click);
            // 
            // bWMP_pause
            // 
            this.bWMP_pause.Location = new System.Drawing.Point(24, 201);
            this.bWMP_pause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bWMP_pause.Name = "bWMP_pause";
            this.bWMP_pause.Size = new System.Drawing.Size(106, 39);
            this.bWMP_pause.TabIndex = 11;
            this.bWMP_pause.Text = "Pause";
            this.bWMP_pause.UseVisualStyleBackColor = true;
            this.bWMP_pause.Click += new System.EventHandler(this.bWMP_pause_Click);
            // 
            // bWMP_play
            // 
            this.bWMP_play.Location = new System.Drawing.Point(24, 158);
            this.bWMP_play.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bWMP_play.Name = "bWMP_play";
            this.bWMP_play.Size = new System.Drawing.Size(106, 39);
            this.bWMP_play.TabIndex = 10;
            this.bWMP_play.Text = "Play";
            this.bWMP_play.UseVisualStyleBackColor = true;
            this.bWMP_play.Click += new System.EventHandler(this.bWMP_play_Click);
            // 
            // bPS_stop
            // 
            this.bPS_stop.Location = new System.Drawing.Point(24, 84);
            this.bPS_stop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bPS_stop.Name = "bPS_stop";
            this.bPS_stop.Size = new System.Drawing.Size(106, 39);
            this.bPS_stop.TabIndex = 9;
            this.bPS_stop.Text = "Stop";
            this.bPS_stop.UseVisualStyleBackColor = true;
            this.bPS_stop.Click += new System.EventHandler(this.bPS_stop_Click);
            // 
            // bPS_play
            // 
            this.bPS_play.Location = new System.Drawing.Point(24, 41);
            this.bPS_play.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bPS_play.Name = "bPS_play";
            this.bPS_play.Size = new System.Drawing.Size(106, 39);
            this.bPS_play.TabIndex = 8;
            this.bPS_play.Text = "Play";
            this.bPS_play.UseVisualStyleBackColor = true;
            this.bPS_play.Click += new System.EventHandler(this.bPS_play_Click);
            // 
            // bWOW_pause
            // 
            this.bWOW_pause.Location = new System.Drawing.Point(209, 201);
            this.bWOW_pause.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bWOW_pause.Name = "bWOW_pause";
            this.bWOW_pause.Size = new System.Drawing.Size(106, 39);
            this.bWOW_pause.TabIndex = 21;
            this.bWOW_pause.Text = "Pause";
            this.bWOW_pause.UseVisualStyleBackColor = true;
            this.bWOW_pause.Click += new System.EventHandler(this.bWOW_pause_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 303);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "Wybór Pliku";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 392);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bWOW_pause);
            this.Controls.Add(this.bRecord);
            this.Controls.Add(this.bDS_stop);
            this.Controls.Add(this.bDS_play);
            this.Controls.Add(this.bMCI_stop);
            this.Controls.Add(this.bMCI_pause);
            this.Controls.Add(this.bMCI_play);
            this.Controls.Add(this.bWOW_stop);
            this.Controls.Add(this.bWOW_play);
            this.Controls.Add(this.bWMP_stop);
            this.Controls.Add(this.bWMP_pause);
            this.Controls.Add(this.bWMP_play);
            this.Controls.Add(this.bPS_stop);
            this.Controls.Add(this.bPS_play);
            this.Controls.Add(this.labelRecord);
            this.Controls.Add(this.labelDirectSound);
            this.Controls.Add(this.labelMCI);
            this.Controls.Add(this.labelWaveOutWrite);
            this.Controls.Add(this.labelWindowsMediaPlayer);
            this.Controls.Add(this.labelPlaySound);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.bChooseFile);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "mainForm";
            this.Text = "Karta muzyczna";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bChooseFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label labelPlaySound;
        private System.Windows.Forms.Label labelWindowsMediaPlayer;
        private System.Windows.Forms.Label labelWaveOutWrite;
        private System.Windows.Forms.Label labelMCI;
        private System.Windows.Forms.Label labelDirectSound;
        private System.Windows.Forms.Label labelRecord;
        private System.Windows.Forms.Button bPS_play;
        private System.Windows.Forms.Button bPS_stop;
        private System.Windows.Forms.Button bWMP_play;
        private System.Windows.Forms.Button bWMP_pause;
        private System.Windows.Forms.Button bWMP_stop;
        private System.Windows.Forms.Button bWOW_play;
        private System.Windows.Forms.Button bWOW_stop;
        private System.Windows.Forms.Button bMCI_play;
        private System.Windows.Forms.Button bMCI_pause;
        private System.Windows.Forms.Button bMCI_stop;
        private System.Windows.Forms.Button bDS_play;
        private System.Windows.Forms.Button bDS_stop;
        private System.Windows.Forms.Button bRecord;
        private System.Windows.Forms.Button bWOW_pause;
        private System.Windows.Forms.Label label1;
    }
}

