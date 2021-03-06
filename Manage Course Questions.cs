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
    public partial class Manage_Course_Questions : Form
    {
        private int instructorID;
        public Manage_Course_Questions(int id)
        {
            InitializeComponent();
            instructorID = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Exam exam = new Manage_Exam(instructorID);
            exam.Show();
        }

        private void Manage_Course_Questions_Load(object sender, EventArgs e)
        {
            loadCourse();
        }

        private void loadCourse()
        {
            OnlineExam ent = new OnlineExam();
            var crs = ent.getInsCourses(instructorID);
            comboBox1.Items.Clear();
            foreach (var item in crs)
            {
                comboBox1.Items.Add($"{item.CrsId}, {item.CrsName}");
            }
        }

        private void loadQuestions(int crsID) 
        {
            OnlineExam ent = new OnlineExam();

            var quesList = from q in ent.Questions
                           where q.CrsId == crsID
                           select q;

            dataGridView1.DataSource = quesList.ToList();
            comboBox2.Items.Clear();
            foreach (var item in quesList)
            {
                string ques = $"{item.QuesId}, {item.Type}";
                comboBox2.Items.Add(ques);
            }
        }

        private void questionInfo(int qid)
        {
            OnlineExam ent = new OnlineExam();
            // select Question by ID
            var quest = (from q in ent.Questions
                         where q.QuesId == qid
                         select q).First();

            // Show Quest Info
            qcont.Text = quest.Qcontent;
            qdegree.Value = (int)quest.Degree;
            qmodel.Text = quest.Answer;


            // Check Type Of Quest To select Display Method
            if (quest.Type.ToLower() == "tf")
            {
                // case 1: TF
                // don't need ans group
                ansGroup.Hide();
            }
            else
            {
                // case 2: MCQ
                // show Ans GroupBox
                List<string> chList = new List<string>(4);
                ansGroup.Show();
                // Mapping
                var choices = ent.Select_MCQ_Question(quest.QuesId).ToList();
                for (int i = 0; i < chList.Count; i++)
                {
                    if (choices[i] == null)
                    {
                        chList.Add("null");
                    }
                    else
                    {
                        chList.Add(choices[i].body);
                    }
                }

                // show Choices
                ansA.Text = chList[0];
                ansB.Text = chList[1];
                ansC.Text = chList[2];
                ansD.Text = chList[3];
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int crsId = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
                loadQuestions(crsId);
            }
            catch (Exception)
            {
                MessageBox.Show("invalid Course ID entred", "Waring");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                int quesID = int.Parse(comboBox2.SelectedItem.ToString().Split(',')[0]);
                questionInfo(quesID);
            }
            else
            {
                MessageBox.Show("Please Select Questions","Waring");
            }
        }
    }
}
