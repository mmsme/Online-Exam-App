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
            showFinishButton();
            
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
            question.Text = $"{index + 1}) {q.Qcontent}";
            label1.Text = $"{index+1} / {examBody.Count} of Questions";
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
            radio.Size = new Size(200, 40);
            radio.Font = new Font("Microsoft Sans Serif", 16);
            radio.CheckedChanged += new System.EventHandler(getAnswer);
            flowLayoutPanel2.Controls.Add(radio);

            RadioButton radio2 = new RadioButton();
            string answer2 = "F) False";
            radio2.Text = answer2;
            radio2.Size = new Size(200, 40);
            radio2.Font = new Font("Microsoft Sans Serif", 16);
            radio2.CheckedChanged += new System.EventHandler(getAnswer);
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
                string answer = $"{item.choices}) {item.body}";
                radio.Text = answer;
                radio.Size = new Size(200, 40);
                radio.Font = new Font("Microsoft Sans Serif", 16);
                radio.CheckedChanged += new System.EventHandler(getAnswer);
                flowLayoutPanel2.Controls.Add(radio);
            }
        }

        private void getAnswer(object sender, EventArgs e)
        {
            // 1 - get Values Of Answer
            string answ = (sender as RadioButton).Text.Split(')')[0];
            // 2 - Get Question ID
            int QuestID = examBody[currentIndex].QuesId;
            if (existInAnswerSheet(QuestID))
            {
                StudentAnswersSheet[QuestID] = answ;
                return;
            }

            StudentAnswersSheet.Add(QuestID, answ);
            showFinishButton();
        }

        private bool existInAnswerSheet(int id)
        {
            foreach (var item in StudentAnswersSheet)
            {
                if (item.Key == id)
                    return true;
            }

            return false;
        }

        private void showFinishButton()
        {
            if (StudentAnswersSheet.Count == examBody.Count)
            {
                
                finish.Enabled = true;
                finish.Show();
               
            }
            else
            {
                finish.Enabled = false;
                finish.Hide();
            }
        }

        private void finish_Click(object sender, EventArgs e)
        {

            OnlineExam exam = new OnlineExam();
            checkIfNotFirstExam();

            foreach (var item in StudentAnswersSheet)
            {
                exam.Insert_Std_Answer(studentID, examID, item.Key, item.Value);
            }

            var res = exam.Calc_Student_Exam_Grade(studentID,examID).First();

            deletePrevGradeIfExist();

            exam.saveStudentGrade(studentID,examID,res.grade);

            MessageBox.Show($"Your Grade {res.grade}, and Degree {res.student_answer_degrees}","Your Resault");
            StudentDashbord dashbord = new StudentDashbord(studentID);

            this.Close();
            dashbord.Show();
        }

        private void checkIfNotFirstExam()
        {
            try
            {
                OnlineExam exam = new OnlineExam();
                var msg = exam.deleteStudentExam(studentID, examID);
            }
            catch (Exception)
            {

                return;
            }
        }

        private void deletePrevGradeIfExist()
        {
            OnlineExam exam = new OnlineExam();
            var msg = exam.deletePrevGrade(studentID, examID);
            exam.SaveChanges();
        }
    }
}
