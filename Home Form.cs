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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Instructor_Strart_form instructor = new Instructor_Strart_form();
            this.Hide();
            instructor.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Student_Login_Form form = new Student_Login_Form();
            form.Show();
            
        }
    }
}
