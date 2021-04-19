using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Replace_Staff : Form
    {
        public Replace_Staff()
        {
            InitializeComponent();
        }

        private void Replace_Staff_Load(object sender, EventArgs e)
        {
            loadStaff();

        }

        private void loadStaff()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT instructor from staff";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                SelectInstructor.Items.Add(dr["instructor"].ToString());

            }
            SelectInstructor.SelectedIndex = 0;

            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateStudents();
            updateStaff();
            UpdateMapStaff();

        }

        private void UpdateMapStaff()
        {

            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "update MapInstructor set Instructor = @n where Instructor = @i ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("i", SelectInstructor.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("n", textBox1.Text.ToString()));
            int n = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (n > 0)
            {
                //  loadStaffData();
            }
            else
            {
                MessageBox.Show("Staff Allocation is not updated, you have to update manually!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateStaff()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "update staff set  instructor = @n where instructor = @id ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("n", textBox1.Text.Trim()));
            cmd.Parameters.Add(new SqlParameter("id", SelectInstructor.SelectedItem.ToString()));

            Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (n)
            {
                loadStaff();
            }
            else
            {
                MessageBox.Show("Staff is not updated, you have to update manually!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void resetForm()
        {

        }

        private void updateStudents()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "update student set instructedby = @instructedby where instructedby = @currentinstructor";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("instructedby", textBox1.Text.Trim()));
            cmd.Parameters.Add(new SqlParameter("currentinstructor", SelectInstructor.SelectedItem.ToString()));
            int x = Convert.ToInt32(cmd.ExecuteNonQuery());
            if (x > 0)
            {
                MessageBox.Show("Instructor is replaced successfully!", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something Went Wrong!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
