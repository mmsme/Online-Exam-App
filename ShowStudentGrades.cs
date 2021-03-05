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
    public partial class ShowStudentGrades : Form
    {
        private int studentID;
        public ShowStudentGrades(int id)
        {
            InitializeComponent();
            this.studentID = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentDashbord dashbord = new StudentDashbord(studentID);
            dashbord.Show();
        }

        private void ShowStudentGrades_Load(object sender, EventArgs e)
        {
            OnlineExam exam = new OnlineExam();
            var grades = exam.getStudnetGrades(studentID);
            dataGridView1.DataSource = grades.ToList();
        }
    }
}
