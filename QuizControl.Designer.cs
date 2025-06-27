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
            this.questionLabel.Location = new System.Drawing.Point(3, 3);
            this.questionLabel.Name = "questionLabel";
            this.questionLabel.Size = new System.Drawing.Size(762, 50);
            this.questionLabel.TabIndex = 0;
            // 
            // option1RadioButton
            // 
            this.option1RadioButton.Location = new System.Drawing.Point(3, 56);
            this.option1RadioButton.Name = "option1RadioButton";
            this.option1RadioButton.Size = new System.Drawing.Size(200, 20);
            this.option1RadioButton.TabIndex = 1;
            // 
            // option2RadioButton
            // 
            this.option2RadioButton.Location = new System.Drawing.Point(3, 82);
            this.option2RadioButton.Name = "option2RadioButton";
            this.option2RadioButton.Size = new System.Drawing.Size(200, 20);
            this.option2RadioButton.TabIndex = 2;
            // 
            // option3RadioButton
            // 
            this.option3RadioButton.Location = new System.Drawing.Point(3, 108);
            this.option3RadioButton.Name = "option3RadioButton";
            this.option3RadioButton.Size = new System.Drawing.Size(200, 20);
            this.option3RadioButton.TabIndex = 3;
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(3, 134);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            // 
            // feedbackLabel
            // 
            this.feedbackLabel.Location = new System.Drawing.Point(3, 163);
            this.feedbackLabel.Name = "feedbackLabel";
            this.feedbackLabel.Size = new System.Drawing.Size(762, 50);
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
            this.Size = new System.Drawing.Size(768, 548);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}