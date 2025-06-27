namespace CybersecurityApp
{
    partial class LogControl
    {
        private System.ComponentModel.IContainer components = null;

        private ListBox logListBox;
        private Button showMoreButton;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.logListBox = new System.Windows.Forms.ListBox();
            this.showMoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logListBox
            // 
            this.logListBox.Location = new System.Drawing.Point(10, 10);
            this.logListBox.Size = new System.Drawing.Size(750, 400);
            this.logListBox.TabIndex = 0;
            // 
            // showMoreButton
            // 
            this.showMoreButton.Location = new System.Drawing.Point(10, 420);
            this.showMoreButton.Text = "Show More";
            this.showMoreButton.Size = new System.Drawing.Size(75, 23);
            this.showMoreButton.TabIndex = 1;
            // 
            // LogControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.showMoreButton);
            this.Controls.Add(this.logListBox);
            this.Name = "LogControl";
            this.Size = new System.Drawing.Size(770, 450);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}