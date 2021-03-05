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
    public partial class Manager_Home_Form : Form
    {
        public Manager_Home_Form()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage_Coureses_Form _Coureses_Form = new Manage_Coureses_Form();
            this.Close();
            _Coureses_Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Instructor manage_Instructor = new Manage_Instructor();
            this.Close();
            manage_Instructor.Show();
        }

        private void Manager_Home_Form_Load(object sender, EventArgs e)
        {

        }
    }
}
