
namespace Online_Exam_App
{
    partial class TakeExam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.timerValue = new System.Windows.Forms.Label();
            this.Timer = new System.Windows.Forms.Label();
            this.examNameValue = new System.Windows.Forms.Label();
            this.examName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.finish = new System.Windows.Forms.Button();
            this.prev = new System.Windows.Forms.Button();
            this.next = new System.Windows.Forms.Button();
            this.question = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.timerValue);
            this.panel1.Controls.Add(this.Timer);
            this.panel1.Controls.Add(this.examNameValue);
            this.panel1.Controls.Add(this.examName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1177, 100);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(503, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 32);
            this.label1.TabIndex = 8;
            this.label1.Text = "label1";
            // 
            // timerValue
            // 
            this.timerValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.timerValue.AutoSize = true;
            this.timerValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timerValue.Location = new System.Drawing.Point(1063, 34);
            this.timerValue.Name = "timerValue";
            this.timerValue.Size = new System.Drawing.Size(87, 32);
            this.timerValue.TabIndex = 7;
            this.timerValue.Text = "00:00";
            // 
            // Timer
            // 
            this.Timer.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Timer.AutoSize = true;
            this.Timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F);
            this.Timer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(155)))), ((int)(((byte)(20)))));
            this.Timer.Location = new System.Drawing.Point(962, 34);
            this.Timer.Name = "Timer";
            this.Timer.Size = new System.Drawing.Size(95, 32);
            this.Timer.TabIndex = 6;
            this.Timer.Text = "Timer:";
            // 
            // examNameValue
            // 
            this.examNameValue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.examNameValue.AutoSize = true;
            this.examNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examNameValue.Location = new System.Drawing.Point(125, 34);
            this.examNameValue.Name = "examNameValue";
            this.examNameValue.Size = new System.Drawing.Size(66, 32);
            this.examNameValue.TabIndex = 5;
            this.examNameValue.Text = "Php";
            // 
            // examName
            // 
            this.examName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.examName.AutoSize = true;
            this.examName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.examName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(155)))), ((int)(((byte)(20)))));
            this.examName.Location = new System.Drawing.Point(27, 34);
            this.examName.Name = "examName";
            this.examName.Size = new System.Drawing.Size(102, 32);
            this.examName.TabIndex = 4;
            this.examName.Text = "Exam: ";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.finish);
            this.panel2.Controls.Add(this.prev);
            this.panel2.Controls.Add(this.next);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 649);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1177, 113);
            this.panel2.TabIndex = 13;
            // 
            // finish
            // 
            this.finish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.finish.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(38)))));
            this.finish.Cursor = System.Windows.Forms.Cursors.Hand;
            this.finish.FlatAppearance.BorderSize = 0;
            this.finish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.finish.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finish.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.finish.Location = new System.Drawing.Point(488, 31);
            this.finish.Name = "finish";
            this.finish.Size = new System.Drawing.Size(196, 48);
            this.finish.TabIndex = 8;
            this.finish.Text = "Finish";
            this.finish.UseVisualStyleBackColor = false;
            this.finish.Click += new System.EventHandler(this.finish_Click);
            // 
            // prev
            // 
            this.prev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(38)))));
            this.prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prev.FlatAppearance.BorderSize = 0;
            this.prev.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.prev.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prev.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.prev.Location = new System.Drawing.Point(44, 31);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(196, 48);
            this.prev.TabIndex = 7;
            this.prev.Text = "Prev";
            this.prev.UseVisualStyleBackColor = false;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            // 
            // next
            // 
            this.next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(168)))), ((int)(((byte)(38)))));
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.FlatAppearance.BorderSize = 0;
            this.next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.next.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(22)))), ((int)(((byte)(30)))));
            this.next.Location = new System.Drawing.Point(932, 31);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(196, 48);
            this.next.TabIndex = 6;
            this.next.Text = "Next";
            this.next.UseVisualStyleBackColor = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            // 
            // question
            // 
            this.question.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.question.AutoSize = true;
            this.question.Font = new System.Drawing.Font("MS Reference Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(155)))), ((int)(((byte)(20)))));
            this.question.Location = new System.Drawing.Point(85, 132);
            this.question.Name = "question";
            this.question.Size = new System.Drawing.Size(117, 40);
            this.question.TabIndex = 12;
            this.question.Text = "label1";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanel2.Location = new System.Drawing.Point(92, 212);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1010, 431);
            this.flowLayoutPanel2.TabIndex = 14;
            // 
            // TakeExam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(31)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1177, 762);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.question);
            this.Controls.Add(this.flowLayoutPanel2);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "TakeExam";
            this.Text = "TakeExam";
            this.Load += new System.EventHandler(this.TakeExam_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel choices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label timerValue;
        private System.Windows.Forms.Label Timer;
        private System.Windows.Forms.Label examNameValue;
        private System.Windows.Forms.Label examName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button prev;
        private System.Windows.Forms.Button next;
        private System.Windows.Forms.Label question;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button finish;
    }
}