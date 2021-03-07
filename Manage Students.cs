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
    public partial class Manage_Students : Form
    {
        OnlineExam ent = new OnlineExam();
        int instructorID;
        public Manage_Students(int insID)
        {
            InitializeComponent();
            this.instructorID = insID;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Instructor_operations instructor = new Instructor_operations(instructorID);
            this.Close();
            instructor.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex>0)
            {
                this.dataGridView1.CurrentCell.Selected = false;
            }
            else
            {
                var id = dataGridView1.SelectedCells[0].Value;
                Select_Student_Result std= ent.Select_Student((int)id).First();
                var fname = std.Student_Name.Split(' ')[0];
                var lname= std.Student_Name.Remove(0,fname.Length);
                //MessageBox.Show(fname);
                comboBox1.Text = std.Student_ID.ToString();
                textBox1.Text = lname;
                textBox2.Text = fname;
                textBox3.Text = std.Home_City;
                textBox4.Text = std.Birth_Date.ToString();
                
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Select_Instructor_Result ins = ent.Select_Instructor(instructorID).First();
            int deptID =int.Parse( ins.Department_ID.ToString());
            Student std = new Student();
            if (textBox1.Text!="" && textBox2.Text !="" && textBox3.Text != "" && textBox4.Text != "" )
            {
                std.Fname = textBox2.Text;
                std.Lname = textBox1.Text;
                std.Address = textBox3.Text;
                std.DoB = Convert.ToDateTime(textBox4.Text);
                std.DeptId = deptID;
                ent.Students.Add(std);
                MessageBox.Show("ADDED");
                ent.SaveChanges();
                loadStudentData();
            }
            else
                MessageBox.Show("PLEASE ENTER FULL DATA");

            //ent.Insert_Student()
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                int stdid = int.Parse(comboBox1.Text.ToString());
                Student mystd = ent.Students.Find(stdid);
                if (mystd!=null)
                {
                    mystd.Fname = textBox2.Text;
                    mystd.Lname = textBox1.Text;
                    mystd.Address = textBox3.Text;
                    mystd.DoB = Convert.ToDateTime(textBox4.Text);
                    ent.SaveChanges();
                    MessageBox.Show("UPDATED");
                    loadStudentData();
                }
                 else
                {
                    MessageBox.Show("STUDET NOT FOUND");
                }
                
            }
            else
            {
                MessageBox.Show("YOU MUST SELECT STUDENT");
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!="")
            {
                int stdid = int.Parse(comboBox1.Text.ToString());
                Student mystd = ent.Students.Find(stdid);
                if (mystd!=null)
                {
                    ent.Students.Remove(mystd);
                    ent.SaveChanges();
                    MessageBox.Show("DELETED");
                    comboBox1.Text = textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
                    var students = ent.Students.Select(d => d).ToList();
                    dataGridView1.DataSource = students;
                }
                else
                {
                    MessageBox.Show("STUDET NOT FOUND");
                }
                
            }
            else
            {
                MessageBox.Show("YOU MUST SELECT STUDENT");
            }
            


        }

        private void Manage_Students_Load(object sender, EventArgs e)
        {
            loadStudentData();
        }

        private void loadStudentData()
        {
            var ins = ent.Select_Instructor(instructorID).First();
          
            var students = from s in ent.Students
                           where s.DeptId == ins.Department_ID
                           select s;
            dataGridView1.DataSource = students.ToList();
        }
    }
}
