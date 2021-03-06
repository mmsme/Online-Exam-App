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

        }
    }
}
