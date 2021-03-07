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
        private int managerID;
        public Manager_Home_Form(int mngID)
        {
            InitializeComponent();
            managerID = mngID;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage_Coureses_Form _Coureses_Form = new Manage_Coureses_Form(managerID);
            this.Close();
            _Coureses_Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Instructor manage_Instructor = new Manage_Instructor(managerID);
            this.Close();
            manage_Instructor.Show();
        }

        private void Manager_Home_Form_Load(object sender, EventArgs e)
        {
            OnlineExam ent = new OnlineExam();
            var inst = (from n in ent.Instructors where n.InsId == managerID select n).First();
            

            label2.Text = inst.InsId.ToString();
            label4.Text = inst.InsName;
        }
    }
}
