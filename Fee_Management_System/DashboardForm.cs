using System;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm sf = new StudentForm();
            sf.ShowDialog();
        }

        private void DashboardForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void addStudentFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeeForm ff = new FeeForm();
            ff.ShowDialog();
        }

        private void checkPaidStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaidStudents ps = new PaidStudents();
            ps.ShowDialog();
        }

        private void checkUnPaidStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unpaid_Students us = new Unpaid_Students();
            us.ShowDialog();
        }

        private void incomeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncomeForm i = new IncomeForm();
            i.ShowDialog();
        }

        private void updateClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForm df = new ClassForm();
            df.ShowDialog();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }
    }
}
