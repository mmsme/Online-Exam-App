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
            Courses_List list = new Courses_List(id);
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
            OnlineExam ent = new OnlineExam();
            var student = ent.Select_Student(id).First();

            IDValue.Text = student.Student_ID.ToString();
            NameValue.Text = student.Student_Name;
            addressValue.Text = student.Home_City;

            var deptName = (from d in ent.Departments
                            where d.DeptId == student.Department_ID
                            select d).First();
            dept.Text = deptName.DeptName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            ShowStudentGrades grades = new ShowStudentGrades(id);
            grades.Show();
        }
    }
}
