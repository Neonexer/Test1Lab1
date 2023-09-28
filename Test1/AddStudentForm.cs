using System;
using System.Drawing;
using System.Windows.Forms;

namespace Test1
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();

            this.nameBox.AutoSize = false;
            this.nameBox.Size = new Size(this.nameBox.Width, 55);

            this.specialityBox.AutoSize = false;
            this.specialityBox.Size = new Size(this.specialityBox.Width, 55);

            this.groupBox.AutoSize = false;
            this.groupBox.Size = new Size(this.groupBox.Width, 55);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            View view = new View();
            view.Show();
        }

        private void closeButton_MouseEnter(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.Black;
        }

        private void closeButton_MouseLeave(object sender, EventArgs e)
        {
            this.closeButton.ForeColor = Color.White;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameBox.Text) || 
                string.IsNullOrEmpty(specialityBox.Text) || 
                string.IsNullOrEmpty(groupBox.Text))
            {
                return;
            } else
            {
                BusinessLogic.Logic logic = new BusinessLogic.Logic();
                logic.AddStudent(nameBox.Text, specialityBox.Text, groupBox.Text);
                this.Hide();
                View view = new View();
                view.Show();
            }
        }
    }
}
