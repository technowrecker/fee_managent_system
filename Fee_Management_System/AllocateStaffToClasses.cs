using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class AllocateStaffToClasses : Form
    {
        public AllocateStaffToClasses()
        {
            InitializeComponent();
        }

        private void AllocateStaffToClasses_Load(object sender, EventArgs e)
        {
            loadStaff();
            loadStaffData();
        }

        private void loadStaff()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT instructor from staff order by instructor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                SelectInstructor.Items.Add(dr["instructor"].ToString());

            }
            SelectInstructor.SelectedIndex = 0;

            con.Close();
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "insert into MapInstructor(Instructor, Class, Gender) values (@i, @c, @gender) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("i", SelectInstructor.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("c", cbxclasses.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("gender", malefemale.SelectedItem.ToString()));
            Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (n)
            {
                loadStaffData();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadStaffData()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  * from MapInstructor";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStaff.DataSource = dt;
            dgvStaff.Refresh();
            con.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                UpdateData();
                loadStaffData();
            }

        }

        private void UpdateData()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "update MapInstructor set Class = @c , Gender = @gender, Instructor = @i where ID = @id ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("i", SelectInstructor.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("c", cbxclasses.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("gender", malefemale.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("id", Globals.MapInstructorId));

            Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (n)
            {
                loadStaffData();
                Globals.MapInstructorId = 0;
            }
            else
            {
                MessageBox.Show("Something Went Wrong!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool isValid()
        {
            if (Globals.MapInstructorId == 0)
            {
                MessageBox.Show("Please select the record first!", "Record not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                deleteStaff();
            }

        }

        private void deleteStaff()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "DELETE from MapInstructor where ID = @i ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("i", Globals.MapInstructorId));
            Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (n)
            {
                loadStaffData();
                loadStaff();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvStaff_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            Globals.MapInstructorId = Convert.ToInt32(dgvStaff.Rows[rowindex].Cells["ID"].Value.ToString());
            SelectInstructor.Text = dgvStaff.Rows[rowindex].Cells["Instructor"].Value.ToString();
            cbxclasses.Text = dgvStaff.Rows[rowindex].Cells["Class"].Value.ToString();
            malefemale.Text = dgvStaff.Rows[rowindex].Cells["Gender"].Value.ToString();
        }

        private void AllocateStaffToClasses_Load_1(object sender, EventArgs e)
        {
            loadStaff();
            loadStaffData();
        }
    }
}
