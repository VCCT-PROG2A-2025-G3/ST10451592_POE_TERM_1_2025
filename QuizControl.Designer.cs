namespace CybersecurityApp
{
    partial class QuizControl
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.optA = new System.Windows.Forms.RadioButton();
            this.optB = new System.Windows.Forms.RadioButton();
            this.optC = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(13, 13);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(52, 15);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question";
            // 
            // optA
            // 
            this.optA.AutoSize = true;
            this.optA.Location = new System.Drawing.Point(13, 44);
            this.optA.Name = "optA";
            this.optA.Size = new System.Drawing.Size(39, 19);
            this.optA.TabIndex = 1;
            this.optA.TabStop = true;
            this.optA.Text = "A)";
            this.optA.UseVisualStyleBackColor = true;
            // 
            // optB
            // 
            this.optB.AutoSize = true;
            this.optB.Location = new System.Drawing.Point(13, 69);
            this.optB.Name = "optB";
            this.optB.Size = new System.Drawing.Size(39, 19);
            this.optB.TabIndex = 2;
            this.optB.TabStop = true;
            this.optB.Text = "B)";
            this.optB.UseVisualStyleBackColor = true;
            // 
            // optC
            // 
            this.optC.AutoSize = true;
            this.optC.Location = new System.Drawing.Point(13, 94);
            this.optC.Name = "optC";
            this.optC.Size = new System.Drawing.Size(39, 19);
            this.optC.TabIndex = 3;
            this.optC.TabStop = true;
            this.optC.Text = "C)";
            this.optC.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(13, 119);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // lblFeedback
            // 
            this.lblFeedback.AutoSize = true;
            this.lblFeedback.Location = new System.Drawing.Point(13, 148);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(54, 15);
            this.lblFeedback.TabIndex = 5;
            this.lblFeedback.Text = "Feedback";
            // 
            // QuizControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.optC);
            this.Controls.Add(this.optB);
            this.Controls.Add(this.optA);
            this.Controls.Add(this.lblQuestion);
            this.Name = "QuizControl";
            this.Size = new System.Drawing.Size(768, 548);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblQuestion;
        private RadioButton optA;
        private RadioButton optB;
        private RadioButton optC;
        private Button btnSubmit;
        private Label lblFeedback;
    }
}