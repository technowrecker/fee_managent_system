using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class ClassForm : Form
    {
        public ClassForm()
        {
            InitializeComponent();
        }
        public int[] selectedID = { 0 };
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                updateStudents();
                updateStudents2();
                loadStudents();

            }
        }

        private void updateStudents2()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query1 = "select * from MapInstructor ";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            SqlDataReader dr = cmd1.ExecuteReader();

            string constr1 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr1);
            con1.Open();
            while (dr.Read())
            {

                string q2 = "update student set instructedby = @i where class = @c and gender = @g";
                SqlCommand cmd2 = new SqlCommand(q2, con1);
                cmd2.Parameters.Add(new SqlParameter("i", dr["Instructor"].ToString()));
                cmd2.Parameters.Add(new SqlParameter("c", dr["Class"].ToString()));
                cmd2.Parameters.Add(new SqlParameter("g", dr["Gender"].ToString()));
                cmd2.ExecuteNonQuery();

            }
            con.Close();
            con1.Close();


        }

        private void updateStudents()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            int a = 0;

            string query1 = "update student set session = @f where class = '10th' and session is null ";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            cmd1.Parameters.Add(new SqlParameter("f", textBox1.Text));
            cmd1.ExecuteNonQuery();

            string[] array1 = { "9th", "8th", "7th", "6th", "5th", "4th", "3rd", "2nd", "1st", "Prep", "Nursery" };
            string[] array2 = { "10th", "9th", "8th", "7th", "6th", "5th", "4th", "3rd", "2nd", "1st", "Prep" };
            for (int i = 0; i < array2.Length; i++)
            {
                string query = "update student set class = @f where class = @u ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("f", array2[i]));
                cmd.Parameters.Add(new SqlParameter("u", array1[i]));
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception c)
                {
                    MessageBox.Show(c.ToString());

                    a = 1;
                }


            }





            con.Close();




            if (a == 0)
            {
                MessageBox.Show("Classes are updated Succesfully", "Update successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please contact to the administrator!", "Update Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private bool isvalidated()
        {
            if (textBox1.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the session for 10th class!", "Invalid Session", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ClassForm_Load(object sender, EventArgs e)
        {
            loadInstructor();
            loadStudents();
            comboBox1.SelectedIndex = 0;
        }

        private void loadInstructor()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT instructor from staff";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox2.Items.Add(dr["instructor"].ToString());
                comboBox2.SelectedIndex = 0;
            }


            con.Close();
        }

        private void loadStudents()
        {
            string constr1 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con1 = new SqlConnection(constr1);
            con1.Open();
            string query1 = "select id as ID, name as StudentName, father_name as FatherName, class as Class, caste as Caste, instructedby as Instructor, gender as Gender  from student where  session is null";
            SqlCommand cmd1 = new SqlCommand(query1, con1);
            SqlDataAdapter da = new SqlDataAdapter(cmd1);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // selectedID += listView1.GetItemAt(listView1.SelectedItems);
        }
        private void dgvStudents_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = e.RowIndex;
            var tempList = selectedID.ToList();
            int sdata = 0;
            for (int i = 0; i < selectedID.Length; i++)
            {
                if (tempList[i] == Convert.ToInt32(dgvStudents.Rows[rowindex].Cells["ID"].Value))
                {
                    sdata = 1;
                    return;
                }

            }
            if (sdata == 1)
            {
                for (int i = 0; i < selectedID.Length; i++)
                {
                    if (tempList[i] == Convert.ToInt32(dgvStudents.Rows[rowindex].Cells["ID"].Value))
                    {
                        tempList.Remove(i);
                    }

                }
            }
            else
            {
                tempList.Add(Convert.ToInt32(dgvStudents.Rows[rowindex].Cells["ID"].Value));
            }



            selectedID = tempList.ToArray();
            MessageBox.Show(selectedID.Length.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constr1 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection cn = new SqlConnection(constr1);
            cn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE student set class = @c , instructedby = @i WHERE id= @id ", cn);

            foreach (DataGridViewRow row in dgvStudents.SelectedRows)
            {

                // cmd.Parameters.AddWithValue("@RStock", row.Cells["RStock"].Value);
                cmd.Parameters.Add(new SqlParameter("c", comboBox1.SelectedItem.ToString()));
                cmd.Parameters.Add(new SqlParameter("i", comboBox2.SelectedItem.ToString()));
                cmd.Parameters.Add(new SqlParameter("id", row.Cells["ID"].Value.ToString()));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
            cn.Close();


            loadStudents();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string constr1 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection cn = new SqlConnection(constr1);
            cn.Open();
            SqlCommand cmd = new SqlCommand(" delete from student WHERE id= @id ", cn);

            foreach (DataGridViewRow row in dgvStudents.SelectedRows)
            {

                // cmd.Parameters.AddWithValue("@RStock", row.Cells["RStock"].Value);
                cmd.Parameters.Add(new SqlParameter("id", row.Cells["ID"].Value.ToString()));
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();

            }
            cn.Close();


            loadStudents();
        }
    }
}
