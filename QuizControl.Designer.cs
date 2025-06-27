namespace CybersecurityApp
{
    partial class QuizControl
    {
        private System.ComponentModel.IContainer components = null;

        private Label questionLabel;
        private RadioButton option1RadioButton;
        private RadioButton option2RadioButton;
        private RadioButton option3RadioButton;
        private Button submitButton;
        private Label feedbackLabel;

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
            this.questionLabel = new System.Windows.Forms.Label();
            this.option1RadioButton = new System.Windows.Forms.RadioButton();
            this.option2RadioButton = new System.Windows.Forms.RadioButton();
            this.option3RadioButton = new System.Windows.Forms.RadioButton();
            this.submitButton = new System.Windows.Forms.Button();
            this.feedbackLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // questionLabel
            // 
            this.questionLabel.Location = new System.Drawing.Point(10, 10);
            this.questionLabel.Size = new System.Drawing.Size(750, 50);
            this.questionLabel.TabIndex = 0;
            // 
            // option1RadioButton
            // 
            this.option1RadioButton.Location = new System.Drawing.Point(10, 70);
            this.option1RadioButton.Size = new System.Drawing.Size(200, 20);
            this.option1RadioButton.TabIndex = 1;
            // 
            // option2RadioButton
            // 
            this.option2RadioButton.Location = new System.Drawing.Point(10, 100);
            this.option2RadioButton.Size = new System.Drawing.Size(200, 20);
            this.option2RadioButton.TabIndex = 2;
            // 
            // option3RadioButton
            // 
            this.option3RadioButton.Location = new System.Drawing.Point(10, 130);
            this.option3RadioButton.Size = new System.Drawing.Size(200, 20);
            this.option3RadioButton.TabIndex = 3;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(10, 160);
            this.submitButton.Text = "Submit";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 4;
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.Location = new System.Drawing.Point(10, 190);
            this.feedbackLabel.Size = new System.Drawing.Size(750, 50);
            this.feedbackLabel.TabIndex = 5;
            // 
            // QuizControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.feedbackLabel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.option3RadioButton);
            this.Controls.Add(this.option2RadioButton);
            this.Controls.Add(this.option1RadioButton);
            this.Controls.Add(this.questionLabel);
            this.Name = "QuizControl";
            this.Size = new System.Drawing.Size(770, 250);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}