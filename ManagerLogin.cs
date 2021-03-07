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
    public partial class ManagerLogin : Form
    {
        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager_Home_Form manager_Home = new Manager_Home_Form();
            this.Close();
            manager_Home.Show();
        }

        private void ManagerLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
