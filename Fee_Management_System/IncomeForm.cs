using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class IncomeForm : Form
    {
        public IncomeForm()
        {
            InitializeComponent();
        }

        private void IncomeForm_Load(object sender, EventArgs e)
        {
            loadmonth();
            loaddata();
            loadMonthlyIncome();
            loadExpenses();
            loadMonthlyExpenses();
            loadRemainingIncome();
        }

        private void loadExpenses()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID', title 'Title', expense 'Expense', month 'Month', date 'Date' FROM expense where month = @month";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("month", cbxMonths.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvExpenses.DataSource = dt;
            dgvExpenses.Refresh();
            con.Close();
        }

        private void loadMonthlyExpenses()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string q = "select sum(expense) as s from expense where month = @month";
            SqlCommand c = new SqlCommand(q, con);
            c.Parameters.Add(new SqlParameter("month", cbxMonths.SelectedItem.ToString()));
            try
            {
                int a = Convert.ToInt32(c.ExecuteScalar());
                txtExpenseTotal.Text = a.ToString();
                con.Close();
            }
            catch (Exception){
                txtExpenseTotal.Text = "0";
            }
            con.Close();
        }

        private void loaddata()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT class as Class, sum(fee_price) as Total from student s, fee f where s.id = f.id and fee_month = @f group by Class ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("f", cbxMonths.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPaidStudents.DataSource = dt;
            dgvPaidStudents.Refresh();
            con.Close();

        }

        private void loadMonthlyIncome()
        {
            string f = cbxMonths.SelectedItem.ToString();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string q = "select sum(fee_price) as s from fee where fee_month = @f";
            SqlCommand c = new SqlCommand(q, con);
            c.Parameters.Add(new SqlParameter("f", f));
            try
            {
                int a = Convert.ToInt32(c.ExecuteScalar());
                txtgrandTotal.Text = a.ToString();
                con.Close();
            }
            catch (Exception) {
                txtgrandTotal.Text = "0";
            }
            con.Close();
        }

        private void loadmonth()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT * from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxMonths.Items.Add(dr["months"].ToString());
            }
            con.Close();
            try
            {
                cbxMonths.SelectedIndex = 0;
            }
            catch (Exception){}
        }

        private void cbxMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtExpenseTotal.Text = null;
            txtgrandTotal.Text = null;
            txtRemainingIncome.Text = null;
            loaddata();
            loadMonthlyIncome();
            loadExpenses();
            loadMonthlyExpenses();
            loadRemainingIncome();
        }

        private void loadRemainingIncome()
        {
            try
            {
                int income = Convert.ToInt32(txtgrandTotal.Text.ToString());
                int expense = Convert.ToInt32(txtExpenseTotal.Text.ToString());
                txtRemainingIncome.Text = Convert.ToInt32(income - expense).ToString();

            }catch(Exception e) { MessageBox.Show(e.ToString()); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            Expense.title = "";

            Expenses expenses = new Expenses();
            expenses.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadmonth();
        }

        private void dgvExpenses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            Expense.id = Convert.ToInt32(dgvExpenses.Rows[index].Cells["ID"].Value.ToString());
            Expense.month = dgvExpenses.Rows[index].Cells["Month"].Value.ToString();
            Expense.title = dgvExpenses.Rows[index].Cells["Title"].Value.ToString();
            Expense.expense = Convert.ToInt32(dgvExpenses.Rows[index].Cells["Expense"].Value.ToString());

            Expenses expenses = new Expenses();
            expenses.ShowDialog();
        }
    }
}
