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
    public partial class Manage_Topics : Form
    {
        OnlineExam ent = new OnlineExam();
        public Manage_Topics()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Instructor_operations instructor = new Instructor_operations(0);
            this.Close();
            instructor.Show();
        }

        private void Manage_Topics_Load(object sender, EventArgs e)
        {
            var topics = ent.Topics.Select(d => new { d.TopId, d.Topname, d.Course.CrsName }).ToList();
            dataGridView1.DataSource = topics;
            var course = ent.Courses.Select(d => d);
            foreach (var item in course)
            {
                comboBox2.Items.Add(item.CrsName);
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
                string crsName = comboBox2.Text;
                int topID = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
                var mytop = ent.Topics.Where(d => d.TopId == topID).Select(d => d).First();
                comboBox1.Text = mytop.TopId.ToString();
                textBox2.Text = mytop.Topname;
                comboBox2.Text = mytop.Course.CrsName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                var crsName = comboBox2.Text;
                var myCourse = ent.Courses.Where(d => d.CrsName == crsName).Select(d => d).First();
                Topic mytopic = new Topic();
                mytopic.CrsId = myCourse.CrsId;
                mytopic.Topname = textBox2.Text;
                ent.Topics.Add(mytopic);
                ent.SaveChanges();
                MessageBox.Show("ADDED");
                comboBox1.Text = comboBox2.Text = textBox2.Text = "";
                var topics = ent.Topics.Select(d => new { d.TopId, d.Topname, d.Course.CrsName }).ToList();
                dataGridView1.DataSource = topics;
            }
            else
            {
                MessageBox.Show("PLEASE ENTER DATA");
            }


        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                int topID = int.Parse(comboBox1.Text);
                var mytop = ent.Topics.Where(d => d.TopId == topID).Select(d => d).First();
                var crsName = comboBox2.Text;
                var myCourse = ent.Courses.Where(d => d.CrsName == crsName).Select(d => d).First();
                mytop.Topname = textBox2.Text;
                mytop.CrsId = myCourse.CrsId;
                ent.SaveChanges();
                MessageBox.Show("UPDATED");
                comboBox1.Text = comboBox2.Text = textBox2.Text = "";
                var topics = ent.Topics.Select(d => new { d.TopId, d.Topname, d.Course.CrsName }).ToList();
                dataGridView1.DataSource = topics;

            }
            else
            {
                MessageBox.Show("PLEASE SELECT TOPIC");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "" && textBox2.Text != "")
            {
                int topID = int.Parse(comboBox1.Text);
                var mytop = ent.Topics.Where(d => d.TopId == topID).Select(d => d).First();
                ent.Topics.Remove(mytop);
                ent.SaveChanges();
                MessageBox.Show("DELETED");
                comboBox1.Text = comboBox2.Text = textBox2.Text = "";
                var topics = ent.Topics.Select(d => new { d.TopId, d.Topname, d.Course.CrsName }).ToList();
                dataGridView1.DataSource = topics;

            }
            else
            {
                MessageBox.Show("PLEASE SELECT TOPIC");
                //ziad
            }
        }
    }
}
