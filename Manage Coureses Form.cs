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
    public partial class Manage_Coureses_Form : Form
    {
        private int managerID;
        OnlineExam ent = new OnlineExam();

        public Manage_Coureses_Form(int id)
        {
            InitializeComponent();
            managerID = id;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manager_Home_Form home_Form = new Manager_Home_Form(managerID);
            this.Close();
            home_Form.Show();
        }

        private void Manage_Coureses_Form_Load(object sender, EventArgs e)
        {
            var courses = ent.Courses.Select(d => new { d.CrsId, d.CrsName }).ToList();
            dataGridView1.DataSource = courses;
            var instructors = ent.Instructors.Select(d => d).ToList();
            foreach (var item in instructors)
            {
                comboBox2.Items.Add(item.InsName);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.ColumnIndex > 0)
            {
                this.dataGridView1.CurrentCell.Selected = false;
            }
            else
            {
                comboBox2.Text = "";
                int crsID = int.Parse( dataGridView1.SelectedCells[0].Value.ToString());
                var myCrs = ent.Courses.Where(d => d.CrsId == crsID).Select(d => d).First();
                var crsIns = ent.Courses.Where(c=>c.CrsId==myCrs.CrsId).Select(c => c.Instructors).ToList();
                comboBox1.Text = myCrs.CrsId.ToString();
                textBox1.Text = myCrs.CrsName;
                //comboBox2.Items.Clear();                
                foreach (var item in crsIns)
                {
                    comboBox2.Text+=item.Select(d=>d.InsName).First();
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                Course crs = new Course();
                crs.CrsName = textBox1.Text;
                var myins = ent.Instructors.Where(i => i.InsName == comboBox2.Text).Select(i => i).First();
                crs.Instructors.Add(myins);
                ent.Courses.Add(crs);
                ent.SaveChanges();
                MessageBox.Show("ADDED");
                var courses = ent.Courses.Select(d => new { d.CrsId, d.CrsName }).ToList();
                dataGridView1.DataSource = courses;
            }
            else
            {
                MessageBox.Show("PLEASE ENTER VALID DATA");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                Course myCrs = new Course();
                myCrs = ent.Courses.Find(int.Parse(comboBox1.Text.ToString()));
                var myins = ent.Instructors.Where(i => i.InsName == comboBox2.Text).Select(i => i).First();
                myCrs.CrsName = textBox1.Text;
                myCrs.Instructors.Add(myins);
                ent.SaveChanges();
                MessageBox.Show("UPDATED");
                var courses = ent.Courses.Select(d => new { d.CrsId, d.CrsName }).ToList();
                dataGridView1.DataSource = courses;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox1.Text != "")
            {
                Course crs = new Course();
                crs = ent.Courses.Find(int.Parse(comboBox1.Text.ToString()));
                crs.Instructors.Clear();
                ent.Courses.Remove(crs);
                ent.SaveChanges();
                MessageBox.Show("DELETED");
                var courses = ent.Courses.Select(d => new { d.CrsId, d.CrsName }).ToList();
                dataGridView1.DataSource = courses;

            }
        }
    }
}
