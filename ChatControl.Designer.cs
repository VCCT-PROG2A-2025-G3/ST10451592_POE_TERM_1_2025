namespace CybersecurityApp
{
    partial class ChatControl
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
            this.chatDisplayTextBox = new System.Windows.Forms.TextBox();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chatDisplayTextBox
            // 
            this.chatDisplayTextBox.Location = new System.Drawing.Point(10, 10);
            this.chatDisplayTextBox.Multiline = true;
            this.chatDisplayTextBox.ReadOnly = true;
            this.chatDisplayTextBox.Size = new System.Drawing.Size(750, 400);
            this.chatDisplayTextBox.TabIndex = 0;
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(10, 420);
            this.inputTextBox.Size = new System.Drawing.Size(750, 20);
            this.inputTextBox.TabIndex = 1;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.chatDisplayTextBox);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(770, 450);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox chatDisplayTextBox;
        private System.Windows.Forms.TextBox inputTextBox;
    }
}