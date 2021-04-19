using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class DailyFee : Form
    {
        public DailyFee()
        {
            InitializeComponent();
        }

        private void DailyFee_Load(object sender, EventArgs e)
        {
            loaddate();
            loaddata();
            loadfee();
        }

        private void loaddate()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT distinct(date) from fee order by date desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {

                try
                {
                    string d = dr["date"].ToString();
                    string[] cq = d.Split(new string[] { " " }, StringSplitOptions.None);

                    datecomboBox.Items.Add(cq[0]);
                }
                catch (Exception){}
            }


            con.Close();
            try
            {
                datecomboBox.SelectedIndex = 0;
            }
            catch (Exception) { }
        }

        private void datecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaddata(); loadfee();
        }

        private void loadfee()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            int sum = 0;

            try
            {
                string f = "";
                if (datecomboBox.SelectedItem != null)
                {
                    f = datecomboBox.SelectedItem.ToString();
                }

                string query = "SELECT  sum(fee_price) from  fee where date = @f ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("f", f));


                sum = Convert.ToInt32(cmd.ExecuteScalar());
                dailytotal.Text = sum.ToString();
            }
            catch (Exception)
            {
                dailytotal.Text = sum.ToString();
            }

            con.Close();
        }

        private void loaddata()
        {
            string f = "";
            if (datecomboBox.SelectedItem != null)
            {
                f = datecomboBox.SelectedItem.ToString();
            }
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT s.id 'ID', name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste',fee_month 'Month', fee_price 'Fee' from student s, fee f where (s.id = f.id ) AND date = @d order by class ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("d", f));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            dataGridView.Refresh();

            con.Close();


        }
        public string studentId = "";
        public string studentFeeMonth = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                string f = datecomboBox.SelectedItem.ToString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "delete from fee where id = @i and fee_month = @f ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("i", studentId));
                cmd.Parameters.Add(new SqlParameter("f", studentFeeMonth));

                cmd.ExecuteNonQuery();

                con.Close();
                resetData();
                loaddata();
                loadfee();
            }
        }

        private void resetData()
        {
            studentFeeMonth = null;
            studentId = null;
        }

        private bool isValid()
        {
            if (studentId == null)
            {
                MessageBox.Show("Please select one record!", "Record not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (studentFeeMonth == null)
            {
                MessageBox.Show("Please select one record!", "Record not selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else return true;
        }

        private void dataGridView_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            int rowindex = e.RowIndex;

            studentId = dataGridView.Rows[rowindex].Cells["ID"].Value.ToString();
            studentFeeMonth = dataGridView.Rows[rowindex].Cells["Month"].Value.ToString();

            MessageBox.Show(studentId + studentFeeMonth);
        }
    }
}
