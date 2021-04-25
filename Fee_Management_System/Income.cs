using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }
        string _month = "";
        public Income(string month)
        {
            InitializeComponent();
            _month = month;
        }
        private void Income_Load(object sender, EventArgs e)
        {
            loadMonth();
            if(IncomeClass.incomeTitle.ToString() != "")
            {
                txtIncomeId.Text = IncomeClass.incomeId.ToString();
                cbxMonth.Text = IncomeClass.incomeMonth.ToString();
                txtIncomeTitle.Text = IncomeClass.incomeTitle.ToString();
                txtIncomeAmount.Text = IncomeClass.incomeAmount.ToString();
            }

            if(_month != "")
            {
                cbxMonth.Text = _month;
            }
        }


        private void loadMonth()
        {
            cbxMonth.Items.Clear();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT months from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxMonth.Items.Add(dr["months"].ToString());
            }
            con.Close();

            cbxMonth.SelectedIndex = 0;
        }

        private void b_Click(object sender, EventArgs e)
        {
            if(isValidated() && txtIncomeId.Text.ToString() == "")
            {
                string date = DateTime.Now.ToShortDateString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert into otherIncome( date, title, income, month ) values (  @date,  @title, @income, @month ) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("date", date));
                cmd.Parameters.Add(new SqlParameter("title", txtIncomeTitle.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("income", txtIncomeAmount.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("month", cbxMonth.SelectedItem.ToString()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "added");
                con.Close();
            }
        }

        private bool isValidated()
        {
            if (cbxMonth.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please provide a valid month", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtIncomeTitle.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Please provide a valid Title", "Invalid Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIncomeTitle.Focus();
                return false;
            }

            if (txtIncomeAmount.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Please provide a valid Income", "Invalid Income", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIncomeAmount.Focus();
                return false;
            }

            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (isValidated() && txtIncomeId.Text.ToString() != "")
            {
                string date = DateTime.Now.ToShortDateString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE otherIncome set date = @date, title = @title, income = @income where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("date", date));
                cmd.Parameters.Add(new SqlParameter("title", txtIncomeTitle.Text.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("income", txtIncomeAmount.Text.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("month", cbxMonth.SelectedItem.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("id", txtIncomeId.Text.ToString().Trim()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "updated");
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtIncomeId.Text.ToString() != "")
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "DELETE FROM otherIncome where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("id", txtIncomeId.Text.ToString()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "deleted");
                con.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void showMessage(bool id, string v)
        {
            if (id)
            {
                MessageBox.Show("Income is " + v + " successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reset()
        {
            try
            {
                txtIncomeId.Text = "";
                cbxMonth.SelectedIndex = 0;
                txtIncomeTitle.Text = "";
                txtIncomeAmount.Text = "";
                txtIncomeTitle.Focus();
            }
            catch (Exception) { }
        }
    }
}
