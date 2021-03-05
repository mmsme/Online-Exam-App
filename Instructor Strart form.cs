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
    public partial class Instructor_Strart_form : Form
    {
        public Instructor_Strart_form()
        {
            InitializeComponent();
        }

        private void Manager_Click(object sender, EventArgs e)
        {
            this.Close();
            ManagerLogin manager = new ManagerLogin();
            manager.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Instructor_Login login = new Instructor_Login();
            this.Close();
            login.Show();
        }
    }
}
