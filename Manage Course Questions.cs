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
            qcont.Text = quest.Qcontent.Trim();
            qdegree.Value = (int)quest.Degree;
            qmodel.Text = quest.Answer.Trim();

            // Check Type Of Quest To select Display Method
            if (quest.Type.ToLower().Trim() == "tf")
            {
                // case 1: TF
                // don't need ans group
               
                comboBox3.SelectedIndex = 1;
            }
            else if(quest.Type.ToLower().Trim() == "mcq")
            {
               
                comboBox3.SelectedIndex = 0;
                List<string> chList = new List<string>(4);
                ansGroup.Show();
                var choices = ent.Select_MCQ_Question(quest.QuesId).ToList();
                TextBox[] textBoxes = { ansA, ansB, ansC, ansD };
                for (int i = 0; i < choices.Count; i++)
                {
                    textBoxes[i].Text = choices[i].body;
                }
            }
            viewAnswerGroup();
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

        private bool isQuestDataValid()
        {
            if (comboBox3.SelectedItem == null ||
                qcont.Text == string.Empty ||
                qmodel.Text == string.Empty )
            {
                return false;
            }
            return true;
        }

        private bool isChoiceDataValid()
        {
            if (
                ansA.Text == string.Empty ||
                ansB.Text == string.Empty ||
                ansC.Text == string.Empty ||
                ansD.Text == string.Empty
                )
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int crsID = 0;
            if (comboBox1.SelectedItem != null)
            {
                crsID = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("Please select course id","Waring");
                return;
            }

            if (!isQuestDataValid())
            {
                MessageBox.Show("Please Enter Valid Data", "Waring");
                return;
            }

            string qbody = qcont.Text.Trim();
            string qtype = comboBox3.SelectedItem.ToString();
            int qdeg = (int)qdegree.Value;
            string modelAns = qmodel.Text.Trim();

            OnlineExam ent = new OnlineExam();
            var last =  ent.insertQuest(qtype,qdeg,qbody,modelAns,crsID).First();
            ////////////////////////////////////////////////////////////////////
            if (last.Type.ToLower() == "mcq")
            {
                insertChoicesForQuestById(last.QuesId);
            }

           
            loadCourse();
            loadQuestions(crsID);
            qcont.Text = qmodel.Text = string.Empty;
            qdegree.Value = 1;
            comboBox3.Text = string.Empty;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = comboBox3.SelectedItem.ToString();
            viewAnswerGroup();
        }

        private void insertChoicesForQuestById(int questID)
        {
            OnlineExam ent = new OnlineExam();
            if (!isChoiceDataValid())
            {
                MessageBox.Show("Please Enter All Data Rrequired", "Waring");
                return;
            }

            Dictionary<string, TextBox> choices = new Dictionary<string, TextBox>(4);
            choices.Add("a", ansA);
            choices.Add("b", ansB);
            choices.Add("c", ansC);
            choices.Add("d", ansD);
            foreach (var item in choices)
            {
                Ques_Choices ques_Choices = new Ques_Choices()
                {
                    QuesId = questID,
                    choices = item.Key,
                    body = item.Value.Text.Trim()
                };

                ent.Ques_Choices.Add(ques_Choices);
                ent.SaveChanges();
            }

            ansA.Text = ansB.Text = ansC.Text = ansD.Text = string.Empty;
        }

        private void viewAnswerGroup()
        {
            if (comboBox3.SelectedItem == null || comboBox3.SelectedIndex == 1)
            {
                ansGroup.Hide();
            }
            else if (comboBox3.SelectedIndex == 0)
            {
                ansGroup.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int questID = 0;
            int crsID = 0;
            if (comboBox2.SelectedItem != null)
            {
                questID = int.Parse(comboBox2.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("Please select quest id","Waring");
            }

            if (comboBox1.SelectedItem != null)
            {
                crsID = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("Please select course id", "Waring");
                return;
            }

            if (!isQuestDataValid())
            {
                MessageBox.Show("Please Enter Valid Data", "Waring");
                return;
            }

            string qbody = qcont.Text.Trim();
            int qdeg = (int)qdegree.Value;
            string modelAns = qmodel.Text.Trim();

            OnlineExam ent = new OnlineExam();
            var quest = (from q in ent.Questions
                         where q.QuesId == questID
                         select q).First();

            quest.Qcontent = qbody;
            quest.Answer = modelAns;
            quest.Degree = qdeg;
            
            if (quest.Type.ToLower().Trim() == "mcq")
            {
                updateChoice(questID);
            }

            ent.SaveChanges();
            loadCourse();
            loadQuestions(crsID);
            questionInfo(questID);
            qcont.Text = qmodel.Text = string.Empty;
            qdegree.Value = 1;
            comboBox3.Text = string.Empty;
        }

        private void updateChoice(int QuestID)
        {
            OnlineExam ent = new OnlineExam();
            if (!isChoiceDataValid())
            {
                MessageBox.Show("Please Enter All Data Rrequired", "Waring");
                return;
            }

            var chlist = ent.Select_MCQ_Question(QuestID).ToList();
            chlist[0].body = ansA.Text; 
            chlist[1].body = ansB.Text; 
            chlist[2].body = ansC.Text; 
            chlist[3].body = ansD.Text;
            ent.SaveChanges();
            ansA.Text = ansB.Text = ansC.Text = ansD.Text = string.Empty;
        }


        private void deleteQuestion()
        {
            int questId = 0;
            if (comboBox2.SelectedItem != null)
            {
                questId = int.Parse(comboBox2.Text.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("Please select course id", "Waring");
                return;
            }

            OnlineExam ent = new OnlineExam();
            var ques = (from q in ent.Questions
                        where q.QuesId == questId
                        select q).First();
            int courseId = (int)ques.CrsId;
            try
            {
                ent.Delete_Question(questId);
            }
            catch (Exception)
            {

               
            }
            
            
            loadCourse();
            loadQuestions(courseId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            deleteQuestion();
        }
    }
}
