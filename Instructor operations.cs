using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_Exam_App
{
    public partial class Instructor_operations : Form
    {
        public Instructor_operations()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Students students = new Manage_Students();
            this.Close();
            students.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Topics topics = new Manage_Topics();
            this.Close();
            topics.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Exam exam = new Manage_Exam();
            exam.Show();
        }
    }
}
