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
        public Manage_Coureses_Form()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manager_Home_Form home_Form = new Manager_Home_Form();
            this.Close();
            home_Form.Show();
        }
    }
}
