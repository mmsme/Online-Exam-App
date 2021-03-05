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
        public Manage_Topics()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Instructor_operations instructor = new Instructor_operations();
            this.Close();
            instructor.Show();
        }

        
    }
}
