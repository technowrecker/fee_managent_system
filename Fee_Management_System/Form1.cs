using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "SELECT * from user_info where username = @u and password = @p";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("u", txtUsername.Text));
                cmd.Parameters.Add(new SqlParameter("p", txtPassword.Text));

                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    this.Hide();
                    FeeForm ff = new FeeForm();
                    ff.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPassword.Clear();
                    txtPassword.Focus();
                }
                con.Close();

            }
        }

        private bool isValidate()
        {
            if (txtUsername.Text.Trim() == "")
            {
                MessageBox.Show("Usename should not be empty!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Clear();
                txtUsername.Focus();
                return false;
            }
            if (txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please provide password!", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return false;
            }
            else
            {
                return true;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
