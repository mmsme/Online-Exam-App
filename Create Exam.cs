﻿using System;
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
    public partial class Create_Exam : Form
    {
        public Create_Exam()
        {
            InitializeComponent();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Manage_Exam exam = new Manage_Exam();
            exam.Show();
        }
    }
}