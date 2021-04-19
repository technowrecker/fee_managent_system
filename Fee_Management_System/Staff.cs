using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            loadStaff();
            txtStaff.Focus();
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "insert into staff(instructor) values (@n) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("n", txtStaff.Text));

                Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
                if (n)
                {
                    resetForm(); loadStaff();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }


        }

        private void loadStaff()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "SELECT id 'ID',instructor 'Instructor Name' from staff";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStaff.DataSource = dt;
                dgvStaff.Refresh();


                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }

        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                Globals.staffId = dgvStaff.Rows[rowindex].Cells["ID"].Value.ToString();
                txtStaff.Text = dgvStaff.Rows[rowindex].Cells["Instructor Name"].Value.ToString();

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "update staff set  instructor = @n where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("n", txtStaff.Text));
                cmd.Parameters.Add(new SqlParameter("id", Globals.staffId));

                Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
                if (n)
                {
                    loadStaff(); resetForm();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }


        }

        private void resetForm()
        {
            txtStaff.Text = ""; txtStaff.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "delete from staff  where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add(new SqlParameter("id", Globals.staffId));

                Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
                if (n)
                {
                    loadStaff(); resetForm();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }


        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
