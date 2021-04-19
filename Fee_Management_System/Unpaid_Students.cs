using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Unpaid_Students : Form
    {
        public Unpaid_Students()
        {
            InitializeComponent();
        }

        private void Unpaid_Students_Load(object sender, EventArgs e)
        {
            loadmonths(); classes.SelectedIndex = 0; malefemale.SelectedIndex = 0;
            loadunpaidstudents();
        }

        private void loadunpaidstudents()
        {
            string f = cbxMonths.SelectedItem.ToString();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By' from student where id not in ( select id from fee where fee_month = @f) and session is null";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("f", f));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPaidStudents.DataSource = dt;
            dgvPaidStudents.Refresh();


            con.Close();
        }

        private void loaddata()
        {
            string f = cbxMonths.SelectedItem.ToString(); string Selectedclass = classes.Text; string Selectedgender = malefemale.Text;
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By' from student  where id not in ( select id from fee where fee_month = @f) and class = @class and gender = @gender and session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("f", f)); cmd.Parameters.Add(new SqlParameter("class", Selectedclass)); cmd.Parameters.Add(new SqlParameter("gender", Selectedgender));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPaidStudents.DataSource = dt;
            dgvPaidStudents.Refresh();
            con.Close();
        }

        private void loadmonths()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT * from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                while (dr.Read())
                {
                    cbxMonths.Items.Add(dr["months"].ToString());
                }
            }
            catch (Exception) { }



            con.Close();
            try
            {
                cbxMonths.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void cbxMonths_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            loaddata();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                loaddata();
            }
            else
            {
                string abc = textBox1.Text.Trim();
                string f = cbxMonths.SelectedItem.ToString(); string Selectedclass = classes.SelectedItem.ToString(); string Selectedgender = malefemale.SelectedItem.ToString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "SELECT name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By' from student where  ( name LIKE @n OR father_name LIKE @n OR  caste LIKE @n) AND  student.id not in ( select id from fee where fee_month = @f)and class = @class and gender = @gender and session is null ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("f", f)); cmd.Parameters.Add(new SqlParameter("class", Selectedclass)); cmd.Parameters.Add(new SqlParameter("gender", Selectedgender));
                cmd.Parameters.Add(new SqlParameter("n", "%" + abc + "%"));
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvPaidStudents.DataSource = dt;
                dgvPaidStudents.Refresh();
                con.Close();
            }
        }
    }
}
