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
    public partial class Instructor_Login : Form
    {
        public Instructor_Login()
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

            try
            {
                int studentId = int.Parse(textBox1.Text);

                string studentName = textBox2.Text;

                login(studentId, studentName);

            }
            catch (Exception)
            {

                MessageBox.Show("Invalid ID", "Error");
            }
           
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
                
                var inst = (from s in ent.Instructors
                               where s.InsId == id && s.InsName == name
                               select s).First();
                this.Close();
                Instructor_operations instructor = new Instructor_operations(inst.InsId);
                this.Close();
                instructor.Show();
               
            }
            catch (Exception)
            {
                MessageBox.Show("Not Authroized", "Access Denaied");
            }
        }
    }
}
