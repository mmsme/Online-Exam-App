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

        private int instructorID;
        public Manage_Exam(int id)
        {
            InitializeComponent();
            instructorID = id;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Instructor_operations instructor = new Instructor_operations(instructorID);
            instructor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Create_Exam exam = new Create_Exam(instructorID);
            exam.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Course_Questions questions = new Manage_Course_Questions(instructorID);
            questions.Show();
        }
    }
}
