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
    public partial class Manage_Instructor : Form
    {
        OnlineExam ent = new OnlineExam();
        public Manage_Instructor()
        {
            InitializeComponent();
            var instructors = ent.Instructors.Select(d =>new { d.InsId,d.InsName,d.DeptId}).ToList() ;
            dataGridView1.DataSource = instructors;
            var deps = ent.Departments.Select(d => d);
            foreach (var item in deps)
            {
                comboBox1.Items.Add(item.DeptName);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manager_Home_Form home_Form = new Manager_Home_Form();
            this.Close();
            home_Form.Show();
        }

        private void Manage_Instructor_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex > 0)
            {
                this.dataGridView1.CurrentCell.Selected = false;
            }
            else
            {
                int insID =int.Parse( dataGridView1.SelectedCells[0].Value.ToString());
                Select_Instructor_Result myins= ent.Select_Instructor(insID).First();
                var myInsDept = ent.Departments.Find(myins.Department_ID);
                comboBox1.Text = myInsDept.DeptName;
                comboBox2.Text = myins.Instructor_ID.ToString();
                textBox2.Text = myins.Instructor_name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text!=""&&comboBox2.Text!=""&&textBox2.Text!="")
            {
                var deptName = comboBox1.SelectedItem.ToString();
                var mydept = ent.Departments.Where(d => d.DeptName == deptName).Select(d => d).First();
                int insid = int.Parse(comboBox2.Text.ToString());
                string insname = textBox2.Text;
                Instructor myins = new Instructor();
                myins.InsId = insid;
                myins.InsName = insname;
                myins.DeptId = mydept.DeptId;
                ent.Instructors.Add(myins);
                ent.SaveChanges();
                MessageBox.Show("ADDED");
                var instructors = ent.Instructors.Select(d => new { d.InsId, d.InsName, d.DeptId }).ToList();
                dataGridView1.DataSource = instructors;
            }
            else
            {
                MessageBox.Show("PLEASE ENTER THE FULL DATA");
            }
            
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                var deptName = comboBox1.SelectedItem.ToString();
                var mydept = ent.Departments.Where(d => d.DeptName == deptName).Select(d => d).First();
                var myins = ent.Instructors.Find(int.Parse(comboBox2.Text.ToString()));
                myins.InsName = textBox2.Text;
                myins.DeptId = mydept.DeptId;
                ent.SaveChanges();
                MessageBox.Show("UPDATED");
                var instructors = ent.Instructors.Select(d => new { d.InsId, d.InsName, d.DeptId }).ToList();
                dataGridView1.DataSource = instructors;
            }
            else
            {
                MessageBox.Show("PLEASE ENTER DATA");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox2.Text!="")
            {
                var myins = ent.Instructors.Find(int.Parse(comboBox2.Text.ToString()));
                ent.Instructors.Remove(myins);
                ent.SaveChanges();
                MessageBox.Show("DELETED");
                comboBox1.Text = comboBox2.Text = textBox2.Text = "";
                var instructors = ent.Instructors.Select(d => new { d.InsId, d.InsName, d.DeptId }).ToList();
                dataGridView1.DataSource = instructors;
            }
            else
            {
                MessageBox.Show("PLEASE SELECT INSTRUCTOR");
            }
        }
    }
}
