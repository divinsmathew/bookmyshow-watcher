namespace BMSWatcher
{
    partial class BMSWatcher
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
            this.CountLabel = new System.Windows.Forms.Label();
            this.LastCheckedLabel = new System.Windows.Forms.Label();
            this.AttemptsLabel = new System.Windows.Forms.Label();
            this.MovieID = new System.Windows.Forms.TextBox();
            this.WatchButton = new System.Windows.Forms.Button();
            this.WatchLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(12, 47);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(99, 13);
            this.CountLabel.TabIndex = 0;
            this.CountLabel.Text = "Theatre Count : NA";
            // 
            // LastCheckedLabel
            // 
            this.LastCheckedLabel.AutoSize = true;
            this.LastCheckedLabel.Location = new System.Drawing.Point(12, 70);
            this.LastCheckedLabel.Name = "LastCheckedLabel";
            this.LastCheckedLabel.Size = new System.Drawing.Size(111, 13);
            this.LastCheckedLabel.TabIndex = 2;
            this.LastCheckedLabel.Text = "Last Checked : Never";
            // 
            // AttemptsLabel
            // 
            this.AttemptsLabel.AutoSize = true;
            this.AttemptsLabel.Location = new System.Drawing.Point(12, 95);
            this.AttemptsLabel.Name = "AttemptsLabel";
            this.AttemptsLabel.Size = new System.Drawing.Size(63, 13);
            this.AttemptsLabel.TabIndex = 3;
            this.AttemptsLabel.Text = "Attempts : 0";
            // 
            // MovieID
            // 
            this.MovieID.Location = new System.Drawing.Point(13, 13);
            this.MovieID.Name = "MovieID";
            this.MovieID.Size = new System.Drawing.Size(187, 20);
            this.MovieID.TabIndex = 4;
            // 
            // WatchButton
            // 
            this.WatchButton.Location = new System.Drawing.Point(207, 11);
            this.WatchButton.Name = "WatchButton";
            this.WatchButton.Size = new System.Drawing.Size(66, 23);
            this.WatchButton.TabIndex = 5;
            this.WatchButton.Text = "Watch";
            this.WatchButton.UseVisualStyleBackColor = true;
            this.WatchButton.Click += new System.EventHandler(this.WatchButton_Click);
            // 
            // WatchLabel
            // 
            this.WatchLabel.Location = new System.Drawing.Point(3, 4);
            this.WatchLabel.Name = "WatchLabel";
            this.WatchLabel.Size = new System.Drawing.Size(277, 42);
            this.WatchLabel.TabIndex = 6;
            this.WatchLabel.Text = "Watching : ";
            this.WatchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WatchLabel.Visible = false;
            // 
            // BMSWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 121);
            this.Controls.Add(this.WatchButton);
            this.Controls.Add(this.MovieID);
            this.Controls.Add(this.AttemptsLabel);
            this.Controls.Add(this.LastCheckedLabel);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.WatchLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "BMSWatcher";
            this.ShowIcon = false;
            this.Text = "BMS Watcher";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.Label LastCheckedLabel;
        private System.Windows.Forms.Label AttemptsLabel;
        private System.Windows.Forms.TextBox MovieID;
        private System.Windows.Forms.Button WatchButton;
        private System.Windows.Forms.Label WatchLabel;
    }
}

