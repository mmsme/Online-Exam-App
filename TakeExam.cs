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
    public partial class TakeExam : Form
    {

        private int examID;
        private int studentID;
        List<generateExam_Result> examBody;
        int currentIndex = 0;
        public Dictionary<int, string> StudentAnswersSheet;

        public TakeExam(int _examID, int _studentID)
        {
            InitializeComponent();
            this.examID = _examID;
            this.studentID = _studentID;
        }

        private void TakeExam_Load(object sender, EventArgs e)
        {
            loadExam();
            loadQuestion(currentIndex);
        }

        private void next_Click(object sender, EventArgs e)
        {
            currentIndex++;
            loadQuestion(currentIndex);
            
        }

        private void prev_Click(object sender, EventArgs e)
        {
            currentIndex--;
            loadQuestion(currentIndex);
        }

        private void loadExam()
        {
            OnlineExam ent = new OnlineExam();
            /// Generate Exam  Quesstions
            var examQuestions = ent.generateExam(examID);
            examBody = examQuestions.ToList();
            StudentAnswersSheet = new Dictionary<int, string>(examBody.Count);

            // show Exam Info 
            var exam = (from e in ent.Exams
                        where e.Enumber == examID
                        select e).First();

            examNameValue.Text = exam.Edescription.Trim();
            timerValue.Text = exam.Eduration.ToString() + 'M';
        }

        private void loadQuestion(int index)
        {
            currentIndex = index;
            ButtonsStates();
            generateExam_Result q = examBody[index];
            quesBody.ForeColor = Color.FromArgb(239, 155, 20);
            quesBody.Text = $"{index + 1}) {q.Qcontent}";
            // check Type 
            if (q.Type.ToLower() == "tf")
            {
                loadTFChoices();
            }
            else
            {
                loadMcqChoices(q.QuesId);
            }
        }

        private void ButtonsStates()
        {

            if (currentIndex == 0)
            {
                prev.Enabled = false;
            }
            else if (currentIndex == examBody.Count - 1)
            {
                next.Enabled = false;
            }
            else
            {
                prev.Enabled = true;
                next.Enabled = true;
            }
        }

        private void loadTFChoices()
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;

            RadioButton radio = new RadioButton();
            string answer = "T) True";
            radio.Text = answer;
            radio.Size = new Size(200, 20);
            flowLayoutPanel2.Controls.Add(radio);

            RadioButton radio2 = new RadioButton();
            string answer2 = "F) False";
            radio2.Text = answer2;
            radio2.Size = new Size(200, 20);
            flowLayoutPanel2.Controls.Add(radio2);
        }


        private void loadMcqChoices(int questionID)
        {
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            OnlineExam onlineExam = new OnlineExam();
            var ques_Choices = from c in onlineExam.Ques_Choices
                          where c.QuesId == questionID
                          select c;
            foreach (var item in ques_Choices)
            {
                RadioButton radio = new RadioButton();
                string answer = item.choices + ") " + item.body;
                radio.Text = answer;
                radio.Size = new Size(200, 20);
                flowLayoutPanel2.Controls.Add(radio);
            }
        }
    }
}
