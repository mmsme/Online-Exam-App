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
        private int instructorID;
        public Instructor_operations(int istID)
        {
            InitializeComponent();
            instructorID = istID;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_Students students = new Manage_Students(instructorID);
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
            Manage_Exam exam = new Manage_Exam(instructorID);
            exam.Show();
        }

        private void Instructor_operations_Load(object sender, EventArgs e)
        {
            OnlineExam ent = new OnlineExam();
            var inst = ent.Select_Instructor(instructorID).First();
            var dept = (from d in ent.Departments
                        where d.DeptId == inst.Department_ID
                        select d).First();

            label2.Text = inst.Instructor_ID.ToString();
            label4.Text = inst.Instructor_name;
            label6.Text = dept.DeptName;
        }
    }
}
