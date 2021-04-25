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
    public partial class Expenses : Form
    {
        public Expenses()
        {
            InitializeComponent();
        }

        string _month = "";

        public Expenses(string month)
        {
            InitializeComponent();
            _month = month;
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            reset();
            loadMonths();
            if(Expense.title.ToString() != "")
            {
                txtId.Text = Expense.id.ToString();
                cbxMonths.Text = Expense.month;
                txtTitle.Text = Expense.title;
                txtExpense.Text = Expense.expense.ToString();
            }

            if(_month != "")
            {
                cbxMonths.Text = _month;
            }
        }

        private void loadMonths()
        {
            cbxMonths.Items.Clear();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT months from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxMonths.Items.Add(dr["months"].ToString());
            }
            try
            {
                cbxMonths.SelectedIndex = 0;
            }
            catch (Exception) { }

            con.Close();
        }

        private void btnAddExpense_Click(object sender, EventArgs e)
        {
            if (validated())
            {
                addNewExpense();
            }
        }

        private void addNewExpense()
        {
            if(txtId.Text.ToString() == "")
            {
                string date = DateTime.Now.ToShortDateString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert into expense( date, title, expense, month ) values (  @date,  @title, @expense, @month ) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("date", date));
                cmd.Parameters.Add(new SqlParameter("title", txtTitle.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("expense", txtExpense.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("month", cbxMonths.SelectedItem.ToString()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "added");
                con.Close();
            }else
            {
                MessageBox.Show("This record is already added","Already added",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showMessage(bool id, string v)
        {
            if (id)
            {
                MessageBox.Show("Expense is " + v +  " successfully","Successful",  MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Failed",  MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool validated()
        {
            if(cbxMonths.SelectedItem.ToString() == "")
            {
                MessageBox.Show( "Please provide a valid month", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTitle.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Please provide a valid Title", "Invalid Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitle.Focus();
                return false;
            }

            if (txtExpense.Text.ToString().Trim() == "")
            {
                MessageBox.Show( "Please provide a valid Expense", "Invalid Expense", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExpense.Focus();
                return false;
            }

            return true;
        }

        private void btnUpdateExpense_Click(object sender, EventArgs e)
        {
            if (validated())
            {
                updateExpense();
            }
        }

        private void updateExpense()
        {
            if(txtId.Text.ToString() != "")
            {
                string date = DateTime.Now.ToShortDateString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE expense set date = @date, title = @title, expense = @expense where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("date", date));
                cmd.Parameters.Add(new SqlParameter("title", txtTitle.Text.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("expense", txtExpense.Text.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("month", cbxMonths.SelectedItem.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("id", txtId.Text.ToString().Trim()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "updated");
                con.Close();
            }
        }

        private void btnDeleteExpense_Click(object sender, EventArgs e)
        {
            if (validated())
            {
                deleteExpense();
            }
        }

        private void deleteExpense()
        {
            if(txtId.Text.ToString() != "")
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "DELETE FROM expense where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("id", txtId.Text.ToString()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "deleted");
                con.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void reset()
        {
            try
            {
                txtId.Text = "";
                cbxMonths.SelectedIndex = 0;
                txtTitle.Text = "";
                txtExpense.Text = "";

            }
            catch (Exception) { }
        }

        private void Expenses_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
