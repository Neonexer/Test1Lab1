using BusinessLogic;
using Model;
using System;
using System.Windows.Forms;


namespace Test1
{
    public partial class View : Form
    {
        public Logic logic = new Logic();

        public View()
        {
            InitializeComponent();

            logic.ReadFile();
            
            foreach (Student student in logic.students)
            {
                ListViewItem item = new ListViewItem(student.Name);
                item.SubItems.Add(student.Speciality);
                item.SubItems.Add(student.Group);
                listView1.Items.Add(item);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddStudentForm addStudent = new AddStudentForm();
            addStudent.Show();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count > 0)
            {
                logic.DeleteStudent(listView1.SelectedItems[0].Index);
                listView1.Items.Remove(listView1.SelectedItems[0]);
            }
        }
    }
}
