namespace RedUDL
{
    partial class MainForm
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
            this.downloadButton = new System.Windows.Forms.Button();
            this.userBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.subredditBox = new System.Windows.Forms.TextBox();
            this.fileDirBox = new System.Windows.Forms.TextBox();
            this.outputButton = new System.Windows.Forms.Button();
            this.statusBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(277, 110);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(116, 23);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // userBox
            // 
            this.userBox.Location = new System.Drawing.Point(97, 33);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(152, 20);
            this.userBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Subreddit:";
            // 
            // subredditBox
            // 
            this.subredditBox.Location = new System.Drawing.Point(97, 72);
            this.subredditBox.Name = "subredditBox";
            this.subredditBox.Size = new System.Drawing.Size(152, 20);
            this.subredditBox.TabIndex = 4;
            // 
            // fileDirBox
            // 
            this.fileDirBox.Location = new System.Drawing.Point(97, 110);
            this.fileDirBox.Name = "fileDirBox";
            this.fileDirBox.Size = new System.Drawing.Size(152, 20);
            this.fileDirBox.TabIndex = 5;
            // 
            // outputButton
            // 
            this.outputButton.Location = new System.Drawing.Point(24, 110);
            this.outputButton.Name = "outputButton";
            this.outputButton.Size = new System.Drawing.Size(55, 23);
            this.outputButton.TabIndex = 6;
            this.outputButton.Text = "Output:";
            this.outputButton.UseVisualStyleBackColor = true;
            this.outputButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusBox
            // 
            this.statusBox.Enabled = false;
            this.statusBox.Location = new System.Drawing.Point(24, 153);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(381, 153);
            this.statusBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(427, 323);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.outputButton);
            this.Controls.Add(this.fileDirBox);
            this.Controls.Add(this.subredditBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.downloadButton);
            this.Name = "MainForm";
            this.Text = "Reddit User Image Downloader";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.TextBox userBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox subredditBox;
        private System.Windows.Forms.TextBox fileDirBox;
        private System.Windows.Forms.Button outputButton;
        private System.Windows.Forms.TextBox statusBox;
    }
}

