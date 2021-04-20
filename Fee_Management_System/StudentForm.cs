using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class StudentForm : Form
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {


            loadstaff();
            loadStudents();
            resetForm();
        }

        private void loadstaff()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT instructor from staff";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxInstructor.Items.Add(dr["instructor"].ToString());
                SelectInstructor.Items.Add(dr["instructor"].ToString());

            }


            con.Close();
        }

        private void loadStudents()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();
        }

        private void resetForm()
        {
            txtName.Clear();
            txtFatherName.Clear();
            txtCaste.Clear();
            if (Globals.selectedClass == "")
            {
                cbxClass.SelectedIndex = 0;
            }
            else
            {
                cbxClass.SelectedIndex = Convert.ToInt32(Globals.selectedClass);
            }
            if (Globals.selectedInstructor == "")
            {
                cbxInstructor.SelectedIndex = 0;
            }
            else
            {
                cbxInstructor.SelectedIndex = Convert.ToInt32(Globals.selectedInstructor);
            }

            cbxGender.SelectedIndex = 0;
            txtName.Focus();
            SelectInstructor.SelectedIndex = 0;
            malefemale.SelectedIndex = 0;
            classes.SelectedIndex = 0;
            txtName.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            loadDesiredData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            resetForm();
            loadStudents();
        }

        private void txtAdd_Click(object sender, EventArgs e)
        {
            if (isvalidate())
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                    SqlConnection con = new SqlConnection(constr);
                    con.Open();
                    string query = "insert into student(name, father_name, class,instructedby, gender, caste) values (@n, @f,  @c,@ins,  @gender,  @caste) ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.Add(new SqlParameter("n", txtName.Text));
                    cmd.Parameters.Add(new SqlParameter("f", txtFatherName.Text));
                    cmd.Parameters.Add(new SqlParameter("c", cbxClass.SelectedItem)); cmd.Parameters.Add(new SqlParameter("ins", cbxInstructor.SelectedItem)); cmd.Parameters.Add(new SqlParameter("gender", cbxGender.SelectedItem));
                    cmd.Parameters.Add(new SqlParameter("caste", txtCaste.Text));
                    Globals.selectedClass = cbxClass.SelectedIndex.ToString();
                    Globals.selectedInstructor = cbxInstructor.SelectedIndex.ToString();
                    Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
                    if (n)
                    {
                        loadStudents();
                        resetForm();
                    }
                    else
                    {
                        MessageBox.Show("Something Went Wrong!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception)
                {

                }

            }
        }

        private bool isvalidate()
        { 
            if(txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please provide Name of the student!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }
            if(txtFatherName.Text.Trim() == "")
            {
                MessageBox.Show("Please provide Father Name!", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFatherName.Focus();
                return false;
            }
            if (txtCaste.Text.Trim() == "")
            {
                MessageBox.Show("Please provide Caste of the student!", "Invalid Caste", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCaste.Focus();
                return false;
            }
            else
            {
                return true;
            }

        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalidate())
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "update student set name =@n, father_name =  @f, class =  @c, instructedby =  @ins, gender =  @gender, caste = @caste where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("n", txtName.Text));
                cmd.Parameters.Add(new SqlParameter("f", txtFatherName.Text));
                cmd.Parameters.Add(new SqlParameter("c", cbxClass.SelectedItem)); cmd.Parameters.Add(new SqlParameter("ins", cbxInstructor.SelectedItem)); cmd.Parameters.Add(new SqlParameter("gender", cbxGender.SelectedItem));
                cmd.Parameters.Add(new SqlParameter("caste", txtCaste.Text)); cmd.Parameters.Add(new SqlParameter("id", Globals.sid));
                Boolean n = false;
                try
                {
                    n = Convert.ToBoolean(cmd.ExecuteNonQuery());

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Something went wrong! \n" + exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (n)
                {
                    loadStudents();
                    resetForm();
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;

            txtName.Text = dgvStudents.Rows[rowindex].Cells["Student Name"].Value.ToString();
            txtFatherName.Text = dgvStudents.Rows[rowindex].Cells["Father Name"].Value.ToString();
            cbxClass.SelectedItem = dgvStudents.Rows[rowindex].Cells["Class"].Value.ToString(); cbxInstructor.SelectedItem = dgvStudents.Rows[rowindex].Cells["Instructed_By"].Value.ToString(); cbxGender.SelectedItem = dgvStudents.Rows[rowindex].Cells["Gender"].Value.ToString();
            txtCaste.Text = dgvStudents.Rows[rowindex].Cells["Caste"].Value.ToString(); loadid();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  [id] FROM [FeeManager].[dbo].[student] where [name] = @n and[father_name] = @fname and[class] = @Class and[caste] = @Caste and[instructedby] = @Instructed_By and gender = @Gender;";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("n", dgvStudents.Rows[rowindex].Cells["Student Name"].Value.ToString()));
            cmd.Parameters.Add(new SqlParameter("fname", txtFatherName.Text)); cmd.Parameters.Add(new SqlParameter("Class", cbxClass.SelectedItem)); cmd.Parameters.Add(new SqlParameter("Instructed_By", cbxInstructor.SelectedItem)); cmd.Parameters.Add(new SqlParameter("Gender", cbxGender.SelectedItem)); cmd.Parameters.Add(new SqlParameter("Caste", txtCaste.Text));
            SqlDataAdapter d = new SqlDataAdapter(cmd); SqlDataReader dr = cmd.ExecuteReader(); while (dr.Read()) { Globals.sid = dr["id"].ToString(); }
            // try { Globals.sid = cmd.ExecuteScalar().ToString(); } catch (Exception a) {  }

            con.Close();
        }

        private void loadid()
        {

        }

        private void manageStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff s = new Staff();
            s.ShowDialog();
        }

        private void del_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "delete from  student where id = @id ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("id", Globals.sid));
            Boolean n = Convert.ToBoolean(cmd.ExecuteNonQuery());
            if (n)
            {
                loadStudents();
                resetForm();
            }
            else
            {
                MessageBox.Show("Something Went Wrong!", "Invalid Credentials", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            loadid();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void checkPaidStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaidStudents ps = new PaidStudents(); ps.ShowDialog();
        }

        private void checkUnPaidStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unpaid_Students us = new Unpaid_Students(); us.ShowDialog();
        }



        private void loadDesiredData()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student where (name like @n OR father_name like @n or caste like @n ) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("n", "%" + txtSearch.Text.ToString() + "%"));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();


            con.Close();
        }

        private void SelectInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student where instructedby = @instructedby ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("instructedby", SelectInstructor.SelectedItem.ToString()));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();


            con.Close();
        }

        private void classes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "SELECT  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student where class = @c and gender = @g ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("c", classes.SelectedItem.ToString()));
                cmd.Parameters.Add(new SqlParameter("g", malefemale.SelectedItem.ToString()));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
                dgvStudents.Refresh();


                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
        }

        private void malefemale_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "SELECT  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student where class = @c and gender = @g ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("c", classes.SelectedItem.ToString()));
                cmd.Parameters.Add(new SqlParameter("g", malefemale.SelectedItem.ToString()));

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvStudents.DataSource = dt;
                dgvStudents.Refresh();


                con.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}


