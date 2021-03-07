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
        private int managerID;
        public ManagerLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkInputDataValid())
            {
                MessageBox.Show("Please Enter Full Info", "Lack of Info");
                return;
            }

            try
            {
                int ins = int.Parse(textBox1.Text);
                login(ins);
            }
            catch (Exception)
            {

                MessageBox.Show("Invalid ID", "Error");
            }
            
        }

        private void ManagerLogin_Load(object sender, EventArgs e)
        {

        }

        private bool checkInputDataValid()
        {
            if (textBox1.Text == string.Empty )
            {
                return false;
            }

            return true;
        }

        private void login(int id)
        {
            OnlineExam ent = new OnlineExam();
            try
            {

                var dept = (from d in ent.Departments select d).ToList();

                bool isManager = false;

                foreach (var item in dept)
                {
                    if (id == item.MangerId)
                    {
                        isManager = true;
                    }
                }

                if (!isManager)
                {
                    MessageBox.Show("Access Denaied","Error");
                    return;
                }

                Manager_Home_Form manager_Home = new Manager_Home_Form(id);
                this.Close();
                manager_Home.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Not Authroized", "Access Denaied");
            }
        }
    }
}
