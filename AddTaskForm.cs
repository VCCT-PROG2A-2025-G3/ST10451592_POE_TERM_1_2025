using System;
using System.Windows.Forms;

namespace CybersecurityApp
{
    public partial class AddTaskForm : Form
    {
        private readonly TaskViewModel _viewModel;
        private TextBox titleTextBox;
        private TextBox descriptionTextBox;
        private DateTimePicker reminderDateTimePicker;

        public AddTaskForm(TaskViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.titleTextBox = new TextBox();
            this.descriptionTextBox = new TextBox();
            this.reminderDateTimePicker = new DateTimePicker();
            var okButton = new Button { Text = "OK", DialogResult = DialogResult.OK };
            var cancelButton = new Button { Text = "Cancel", DialogResult = DialogResult.Cancel };

            this.Controls.Add(titleTextBox);
            this.Controls.Add(descriptionTextBox);
            this.Controls.Add(reminderDateTimePicker);
            this.Controls.Add(okButton);
            this.Controls.Add(cancelButton);

            titleTextBox.Location = new System.Drawing.Point(10, 10);
            descriptionTextBox.Location = new System.Drawing.Point(10, 40);
            reminderDateTimePicker.Location = new System.Drawing.Point(10, 70);
            okButton.Location = new System.Drawing.Point(10, 100);
            cancelButton.Location = new System.Drawing.Point(90, 100);

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(200, 150);
            this.StartPosition = FormStartPosition.CenterParent;

            this.FormClosing += (s, e) =>
            {
                if (this.DialogResult == DialogResult.OK)
                {
                    _viewModel.AddTask(new Task
                    {
                        Title = titleTextBox.Text,
                        Description = descriptionTextBox.Text,
                        Reminder = reminderDateTimePicker.Value,
                        IsCompleted = false
                    });
                }
            };
        }
    }
}