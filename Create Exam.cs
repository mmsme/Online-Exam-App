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
    public partial class Create_Exam : Form
    {

        private int instructorID;
        public Create_Exam(int id)
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

        private void Create_Exam_Load(object sender, EventArgs e)
        {
            loadCourse();
        }

        private void loadCourse()
        {
            OnlineExam ent = new OnlineExam();
            var crs = ent.getInsCourses(instructorID);
            comboBox2.Items.Clear();
            foreach (var item in crs)
            {
                comboBox2.Items.Add($"{item.CrsId}, {item.CrsName}");
            }
        }

        private void loadExams(int crsID)
        {
            OnlineExam ent = new OnlineExam();
            var exams = from ex in ent.Exams
                        where ex.CrsId == crsID
                        select ex;


            dataGridView1.DataSource = exams.ToList();
            comboBox1.Items.Clear();
            foreach (var item in exams)
            {
                string exam = $"{item.Enumber}, {item.Edescription}";
                comboBox1.Items.Add(exam);
            }
         
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int crsId = int.Parse(comboBox2.SelectedItem.ToString().Split(',')[0]);
                loadExams(crsId);
            }
            catch (Exception)
            {
                MessageBox.Show("invalid Course ID entred", "Waring");
            }
        }

        private void loadSingleExamInfo(int examId)
        {
            OnlineExam ent = new OnlineExam();
            var exam = (from e in ent.Exams
                        where e.Enumber == examId
                        select e).First();

            // desc
            textBox2.Text = exam.Edescription;
            // number of Mcq
            numericUpDown1.Value = (int)exam.NumOfMcq;
            // number of Tf
            numericUpDown2.Value = (int)exam.NumOfTF;
            // duration 
            numericUpDown3.Value = (int)exam.Eduration;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int examID = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
                loadSingleExamInfo(examID);
            }
            catch (Exception)
            {

                MessageBox.Show("invalid Exam ID entred", "Waring");
            }
        }


        private bool isDataValid()
        {
            if (
                textBox2.Text == "" ||
                numericUpDown1.Value == 0 ||
                numericUpDown2.Value == 0 ||
                numericUpDown3.Value == 0
                )
            {
                return false;
            }
            return true;
        }

        private bool isNumberOfMcqOutOfRange(int crsId, int numOfMcQ)
        {
            OnlineExam online = new OnlineExam();
            var mcqList = from mcq in online.Questions
                      where mcq.CrsId == crsId && mcq.Type == "mcq"
                      select mcq;

            if (numOfMcQ > mcqList.Count())
            {
                return true;
            }

            return false;
        }

        private bool isNumberOfTFRange(int crsId, int numOfTF)
        {
            OnlineExam online = new OnlineExam();
            var mcqList = from mcq in online.Questions
                          where mcq.CrsId == crsId && mcq.Type == "mcq"
                          select mcq;

            if (numOfTF > mcqList.Count())
            {
                return true;
            }

            return false;
        }

        // add
        private void button1_Click(object sender, EventArgs e)
        {
            OnlineExam ent = new OnlineExam();
            int crsId = 0;
            string desc = textBox2.Text;
            if (comboBox2.SelectedItem != null)
            {
                crsId = int.Parse(comboBox2.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("invalid Course ID entred", "Waring");
                return;
            }
            int nMcq = (int)numericUpDown1.Value;

            if (isNumberOfMcqOutOfRange(crsId, nMcq))
            {
                MessageBox.Show("The Number Is out of Range\nplease go and insert more Question to Continue","Waring");
                return;
            }

            int nTF = (int)numericUpDown2.Value;
            if (isNumberOfTFRange(crsId, nTF))
            {
                MessageBox.Show("The Number Is out of Range\nplease go and insert more Question to Continue","Waring");
                return;
            }

                
            int duration = (int)numericUpDown3.Value;
            Exam exam = new Exam() 
            { 
                CrsId = crsId,
                Edescription = desc,
                NumOfMcq = nMcq,
                NumOfTF = nTF,
                Eduration =  duration,
                Edate = DateTime.Now
            };

            ent.Exams.Add(exam);
            ent.SaveChanges();
            loadCourse();
            loadExams(crsId);
          
          
        }

        // update
        private void Update_Click(object sender, EventArgs e)
        {
            int examId = 0;
            int crsId = 0;
            OnlineExam ent = new OnlineExam();

            if (comboBox2.SelectedItem != null)
            {
                crsId = int.Parse(comboBox2.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("invalid Course ID entred", "Waring");
                return;
            }

            if (comboBox1.SelectedItem != null)
            {
                examId = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("There Is No Exam Selected");
                return;
            }

            if (!isDataValid())
            {
                MessageBox.Show("There is Data Is Missing", "Waring");
                return;
            }

            string desc = textBox2.Text;
            int nMcq = (int)numericUpDown1.Value;

            if (isNumberOfMcqOutOfRange(crsId, nMcq))
            {
                MessageBox.Show("The Number Is out of Range\nplease go and insert more Question to Continue", "Waring");
                return;
            }

            int nTF = (int)numericUpDown2.Value;
            if (isNumberOfTFRange(crsId, nTF))
            {
                MessageBox.Show("The Number Is out of Range\nplease go and insert more Question to Continue", "Waring");
                return;
            }


            int duration = (int)numericUpDown3.Value;
            if (duration < 10)
            {
                MessageBox.Show("Mim Duration is 10 Min");
                return;
            }

            var exam = (from ex in ent.Exams
                        where ex.Enumber == examId
                        select ex).First();

            exam.Edescription = desc;
            exam.Eduration = duration;
            exam.NumOfMcq = nMcq;
            exam.NumOfTF = nTF;

            ent.SaveChanges();
            loadCourse();
            loadExams(crsId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int examId = 0;
            if (comboBox1.SelectedItem != null)
            {
                examId = int.Parse(comboBox1.SelectedItem.ToString().Split(',')[0]);
            }
            else
            {
                MessageBox.Show("There Is No Exam Selected");
                return;
            }

            OnlineExam ent = new OnlineExam();
            var exam = (from ex in ent.Exams
                        where ex.Enumber == examId
                        select ex).First();

            int crsId = (int)exam.CrsId;
            ent.Exams.Remove(exam);
            ent.SaveChanges();
            loadCourse();
            loadExams(crsId);
        }
    }
}
