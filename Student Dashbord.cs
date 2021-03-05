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
    public partial class StudentDashbord : Form
    {


        private int id;
        
        public StudentDashbord(int id)
        {
            InitializeComponent();
            this.id = id;
            OnlineExam ent = new OnlineExam();
            var student = ent.Select_Student(id).First();
            IDValue.Text = student.Student_ID.ToString();
            NameValue.Text = student.Student_Name;
            addressValue.Text = student.Home_City;
        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Courses_List list = new Courses_List();
            list.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            ExamDashborad exam = new ExamDashborad(id);
            exam.Show();
        }

        private void StudentDashbord_Load(object sender, EventArgs e)
        {

        }
    }
}
