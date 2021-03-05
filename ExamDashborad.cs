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
    public partial class ExamDashborad : Form
    {
        private int studentID;
        private int ExamID = -1;
       
        public ExamDashborad(int id)
        {
            InitializeComponent();
            studentID = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            StudentDashbord student = new StudentDashbord(studentID);
            student.Show();
        }

        private void LoadCoureses()
        {
            OnlineExam ent = new OnlineExam();
            var student = (from s in ent.Students
                           where s.Sid == studentID
                           select s).First();

            var Courses = ent.getCoursesByDeptID(student.DeptId);
            
            listBox1.Items.Clear();
            foreach (var item in Courses)
            {
                listBox1.Items.Add(item.CrsName);
            }
        }

        private void loadAvialbleExams(string cname)
        {
            OnlineExam ent = new OnlineExam();
            
                var course = ent.Select_Course_byName(cname).First();
                int cid = course.Course_ID;
                var exames = from ex in ent.Exams
                             where ex.CrsId == cid
                             select ex;


            if (exames.Count() == 0)
            {
                flowLayoutPanel1.Controls.Clear();
                comboBox1.Items.Clear();
                comboBox1.Text = string.Empty;
                Label nolabel = new Label();
                nolabel.Text = "There Is No Exams Available";
                nolabel.Size = new Size(350, 30);
                nolabel.ForeColor = Color.FromArgb(239, 155, 25);
                nolabel.Font = new Font("Microsoft Sans Serif", 18);
                flowLayoutPanel1.Controls.Add(nolabel);
                ExamID = -1;
                StartButtonStatus();
            }
            else 
            {
                flowLayoutPanel1.Controls.Clear();
                comboBox1.Items.Clear();
                foreach (var item in exames)
                {
                    string exam = $"{item.Enumber}, {item.Edescription}";
                    comboBox1.Items.Add(exam);
                }
            }
        }

        private void ExamDashborad_Load(object sender, EventArgs e)
        {
            LoadCoureses();
            StartButtonStatus();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string cname = listBox1.SelectedItem.ToString();
                loadAvialbleExams(cname);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Select Course To Show Avaliable Exams","Warring");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            TakeExam takeExam = new TakeExam(ExamID, studentID);
            takeExam.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
            ExamID = id;
            StartButtonStatus();
        }

        private void StartButtonStatus()
        {
            if(ExamID == -1)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
            }
        }
    }
}
