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
    public partial class Student_Login_Form : Form
    {
        public Student_Login_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInputDataValid())
            {
                MessageBox.Show("Please Enter Full Info", "Lack of Info");
                return;
            }

            int studentId = int.Parse(textBox1.Text);
            string studentName = textBox2.Text;

            login(studentId, studentName);
        }

        private bool checkInputDataValid() 
        {
            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                return false;
            }

            return true;
        }

        private void login(int id, string name)
        {
            OnlineExam ent = new OnlineExam();
            try
            {
                var student = (from s in ent.Students
                               where s.Sid == id && s.Fname == name
                               select s).First();
                this.Close();
                StudentDashbord dashbord = new StudentDashbord(id);
                dashbord.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Not Authroized","Access Denaied");
            }
        }

        private void Student_Login_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
