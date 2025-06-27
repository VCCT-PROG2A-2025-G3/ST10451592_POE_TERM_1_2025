namespace CybersecurityApp
{
    partial class LogControl
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // logListBox
            // 
            this.logListBox.Location = new System.Drawing.Point(10, 10);
            this.logListBox.Name = "logListBox";
            this.logListBox.Size = new System.Drawing.Size(750, 400);
            this.logListBox.TabIndex = 0;
            // 
            // LogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.logListBox);
            this.Name = "LogControl";
            this.Size = new System.Drawing.Size(770, 450);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.ListBox logListBox;
    }
}