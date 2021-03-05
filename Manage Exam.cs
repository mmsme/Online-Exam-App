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
    public partial class Manage_Exam : Form
    {
        public Manage_Exam()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Instructor_operations instructor = new Instructor_operations();
            instructor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Create_Exam exam = new Create_Exam();
            exam.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Course_Questions questions = new Manage_Course_Questions();
            questions.Show();
        }
    }
}
