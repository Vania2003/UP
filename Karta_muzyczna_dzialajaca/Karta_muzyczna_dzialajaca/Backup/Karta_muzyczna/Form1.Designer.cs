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
            this.SuspendLayout();
            // 
            // bChooseFile
            // 
            this.bChooseFile.Location = new System.Drawing.Point(196, 382);
            this.bChooseFile.Name = "bChooseFile";
            this.bChooseFile.Size = new System.Drawing.Size(113, 36);
            this.bChooseFile.TabIndex = 0;
            this.bChooseFile.Text = "Wybierz plik";
            this.bChooseFile.UseVisualStyleBackColor = true;
            this.bChooseFile.Click += new System.EventHandler(this.bChooseFile_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(315, 387);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ReadOnly = true;
            this.txtFilePath.Size = new System.Drawing.Size(308, 26);
            this.txtFilePath.TabIndex = 1;
            // 
            // Other Labels ...
            // 

            // bRecord
            this.bRecord.Location = new System.Drawing.Point(632, 232);
            this.bRecord.Name = "bRecord";
            this.bRecord.Size = new System.Drawing.Size(49, 49);
            this.bRecord.TabIndex = 20;
            this.bRecord.Text = "Rec";
            this.bRecord.UseVisualStyleBackColor = true;
            this.bRecord.Click += new System.EventHandler(this.bRecord_Click);
            // 
            // bDS_stop
            this.bDS_stop.Location = new System.Drawing.Point(427, 232);
            this.bDS_stop.Name = "bDS_stop";
            this.bDS_stop.Size = new System.Drawing.Size(49, 49);
            this.bDS_stop.TabIndex = 19;
            this.bDS_stop.Text = "Stop";
            this.bDS_stop.UseVisualStyleBackColor = true;
            this.bDS_stop.Click += new System.EventHandler(this.bDS_stop_Click);
            // 
            // bDS_play
            this.bDS_play.Location = new System.Drawing.Point(361, 232);
            this.bDS_play.Name = "bDS_play";
            this.bDS_play.Size = new System.Drawing.Size(51, 49);
            this.bDS_play.TabIndex = 18;
            this.bDS_play.Text = "Play";
            this.bDS_play.UseVisualStyleBackColor = true;
            this.bDS_play.Click += new System.EventHandler(this.bDS_play_Click);
            // 
            // bMCI_stop
            this.bMCI_stop.Location = new System.Drawing.Point(194, 232);
            this.bMCI_stop.Name = "bMCI_stop";
            this.bMCI_stop.Size = new System.Drawing.Size(51, 49);
            this.bMCI_stop.TabIndex = 17;
            this.bMCI_stop.Text = "Stop";
            this.bMCI_stop.UseVisualStyleBackColor = true;
            this.bMCI_stop.Click += new System.EventHandler(this.bMCI_stop_Click);
            // 
            // bMCI_pause
            this.bMCI_pause.Location = new System.Drawing.Point(128, 232);
            this.bMCI_pause.Name = "bMCI_pause";
            this.bMCI_pause.Size = new System.Drawing.Size(51, 49);
            this.bMCI_pause.TabIndex = 16;
            this.bMCI_pause.Text = "Pause";
            this.bMCI_pause.UseVisualStyleBackColor = true;
            this.bMCI_pause.Click += new System.EventHandler(this.bMCI_pause_Click);
            // 
            // bMCI_play
            this.bMCI_play.Location = new System.Drawing.Point(65, 232);
            this.bMCI_play.Name = "bMCI_play";
            this.bMCI_play.Size = new System.Drawing.Size(51, 49);
            this.bMCI_play.TabIndex = 15;
            this.bMCI_play.Text = "Play";
            this.bMCI_play.UseVisualStyleBackColor = true;
            this.bMCI_play.Click += new System.EventHandler(this.bMCI_play_Click);
            // 
            // bWOW_stop
            this.bWOW_stop.Location = new System.Drawing.Point(708, 90);
            this.bWOW_stop.Name = "bWOW_stop";
            this.bWOW_stop.Size = new System.Drawing.Size(51, 49);
            this.bWOW_stop.TabIndex = 14;
            this.bWOW_stop.Text = "Stop";
            this.bWOW_stop.UseVisualStyleBackColor = true;
            this.bWOW_stop.Click += new System.EventHandler(this.bWOW_stop_Click);
            // 
            // bWOW_play
            this.bWOW_play.Location = new System.Drawing.Point(577, 90);
            this.bWOW_play.Name = "bWOW_play";
            this.bWOW_play.Size = new System.Drawing.Size(51, 49);
            this.bWOW_play.TabIndex = 13;
            this.bWOW_play.Text = "Play";
            this.bWOW_play.UseVisualStyleBackColor = true;
            this.bWOW_play.Click += new System.EventHandler(this.bWOW_play_Click);
            // 
            // bWOW_pause
            this.bWOW_pause.Location = new System.Drawing.Point(643, 90);
            this.bWOW_pause.Name = "bWOW_pause";
            this.bWOW_pause.Size = new System.Drawing.Size(49, 49);
            this.bWOW_pause.TabIndex = 21;
            this.bWOW_pause.Text = "Pause";
            this.bWOW_pause.UseVisualStyleBackColor = true;
            this.bWOW_pause.Click += new System.EventHandler(this.bWOW_pause_Click);
            // 
            // mainForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "mainForm";
            this.Text = "Karta muzyczna";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}