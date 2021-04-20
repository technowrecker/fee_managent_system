using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class FeeForm : Form
    {
        public FeeForm()
        {
            InitializeComponent();
        }

        private void FeeForm_Load(object sender, EventArgs e)
        {
            loadStaff();
            setClasses();
            setGender();
            loadmonths();

            DataGridViewCheckBoxColumn cbxclm = new DataGridViewCheckBoxColumn();
            cbxclm.Name = "X";
            cbxclm.HeaderText = "";
            cbxclm.Width = 30;
            students_dgv.Columns.Insert(0, cbxclm);


            try
            {
                string month = cbxMonth.SelectedItem.ToString();
                loadUnpaidStudentsByMonth(month);
            }
            catch (Exception)
            {
                loadAllStudents();
            }

            
        }

        private void setGender()
        {
            cbxGender.SelectedIndex = 0;
        }

        private void setClasses()
        {
            comboBox1.SelectedIndex = 0;
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

                cbxInstructor.Items.Add(dr["instructor"].ToString());

            }
            try
            {
                cbxInstructor.SelectedIndex = 0;
            }
            catch (Exception) { }
            con.Close();
            resetform();
        }

        private void loadmonths()
        {
            cbxMonth.Items.Clear();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT * from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxMonth.Items.Add(dr["months"].ToString());
            }
            try
            {
                cbxMonth.SelectedIndex = 0;
            }
            catch (Exception) { }

            con.Close();

        }

        private void loadstudents()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void resetform()
        {
            txtStudentFee.Clear();
            txtAddMonth.Clear();
            loadmonths();
        }

        private int payStudentFee(int id, string month, int amount)
        {
            int studentId = id;
            string feeMonth = month;
            int feeAmount = amount;
            string feeDate = DateTime.Now.ToString("dd-MMM-yyyy");

            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "insert into fee(fee_month, fee_price, id, date) output INSERTED.fee_id values (@n, @f,  @c,  @date) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("n", feeMonth));
            cmd.Parameters.Add(new SqlParameter("f", feeAmount));
            cmd.Parameters.Add(new SqlParameter("c", studentId));
            cmd.Parameters.Add(new SqlParameter("date", feeDate));
            int feeId = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return feeId;
        }

        private bool addNewMonth(string v)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "insert into months(months) values (@n) ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("n", v));
            bool isMonthAdded = Convert.ToBoolean(cmd.ExecuteNonQuery());
            con.Close();
            if (isMonthAdded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool isPaid(int id, string month)
        {
            int studentID = id;
            string feeMonth = month;
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  [id] from fee where fee_month = @month and id = @id";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("month", feeMonth));
            cmd.Parameters.Add(new SqlParameter("id", studentID));
            SqlDataReader dr = cmd.ExecuteReader();  
            
            if (!dr.Read())
            {
                con.Close();
                return true;
            }
            else
            {
                int paidStudentId = Convert.ToInt32(dr["id"].ToString());
                dr.Close();
                con.Close();
                string constr1 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con1 = new SqlConnection(constr1);
                con1.Open();
                string query1 = "SELECT name  from student where id = @id";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.Add(new SqlParameter("id", paidStudentId));
                SqlDataReader dr1 = cmd1.ExecuteReader();
                while (dr1.Read()){
                    MessageBox.Show(dr1["name"].ToString() + " has already paid the fee", "Paid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                con1.Close();
                return false;
            }


        }

        private bool isvalidated()
        {

            if (txtStudentFee.Text == "")
            {
                MessageBox.Show("Please add student fee!", "Invalid fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStudentFee.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void FeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void loadDesiredData()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student where (name like @name or father_name like @name or caste like @name) and session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("name", "%" + search.Text.ToString() + "%"));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void loadAllStudents()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void loadUnpaidStudentsByMonth(string month)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where id not in( select id from fee where fee_month = @feeMonth ) and session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("feeMonth", month));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void search_TextChanged(object sender, EventArgs e)
        {
            loadDesiredData();
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            loadStaff();
            setClasses();
            setGender();
            loadUnpaidStudentsByMonth(cbxMonth.SelectedItem.ToString());
            loadmonths();
        }

        private void pay_button_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                string month;
                int amount = Convert.ToInt32(txtStudentFee.Text);

                // code for months
                if (txtAddMonth.Text.Trim().Length == 0)
                {
                    month = cbxMonth.SelectedItem.ToString();
                }
                else
                {
                    month = txtAddMonth.Text.Trim().ToString();
                    if (!addNewMonth(month))
                    {
                        MessageBox.Show("New month is not added");
                    }
                }


                // code for dgv rows

                foreach (DataGridViewRow dgvRow in students_dgv.Rows)
                {
                    if (dgvRow.Cells[0].Value != null && Convert.ToBoolean(dgvRow.Cells[0].Value))
                    {
                        int id = Convert.ToInt32(dgvRow.Cells[1].Value.ToString());
                        if (isPaid(Convert.ToInt32(dgvRow.Cells[1].Value), month))
                        {
                            payStudentFee(id, month, amount);
                        }
                    }
                }
            }
        }

        private void print_button_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                string month;
                int amount = Convert.ToInt32(txtStudentFee.Text);

                // code for months
                if (txtAddMonth.Text.Trim().Length == 0)
                {
                    month = cbxMonth.SelectedItem.ToString();
                }
                else
                {
                    month = txtAddMonth.Text.Trim().ToString();
                    if (!addNewMonth(month))
                    {
                        MessageBox.Show("New month is not added");
                    }
                }


                // code for dgv rows

                foreach (DataGridViewRow dgvRow in students_dgv.Rows)
                {
                    if (dgvRow.Cells[0].Value != null && Convert.ToBoolean(dgvRow.Cells[0].Value))
                    {
                        int id = Convert.ToInt32(dgvRow.Cells[1].Value.ToString());
                        if (isPaid(Convert.ToInt32(dgvRow.Cells[1].Value), month))
                        {
                            if (Convert.ToBoolean(payStudentFee(id, month, amount)))
                            {
                                PrintSlipData.feeId = id;
                                PrintSlipData.studentName = dgvRow.Cells[2].Value.ToString();
                                PrintSlipData.fatherName = dgvRow.Cells[3].Value.ToString();
                                PrintSlipData.studentClass = dgvRow.Cells[4].Value.ToString();
                                PrintSlipData.feeMonth = month;
                                PrintSlipData.amount = amount.ToString();

                                SlipForm cf = new SlipForm();
                                cf.ShowDialog();
                            }
                            else
                            {
                                MessageBox.Show("Some thing went wrong!");
                            }
                        }
                    }
                }

            }
        }

        private void txtStudentFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbxInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where instructedby = @instructedby  and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("instructedby", cbxInstructor.SelectedItem.ToString()));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxGender.SelectedIndex = 0;
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where  class = @c and gender = @g and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("c", comboBox1.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("g", cbxGender.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where  class = @c and gender = @g and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("c", comboBox1.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("g", cbxGender.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            students_dgv.DataSource = dt;
            students_dgv.Refresh();
            con.Close();
        }

        private void cbxMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUnpaidStudentsByMonth(cbxMonth.SelectedItem.ToString());
        }

        private void txtAddMonth_TextChanged(object sender, EventArgs e)
        {
            loadAllStudents();
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e)
        {
            StudentForm sf = new StudentForm();
            sf.ShowDialog();
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e)
        {
            ClassForm classForm = new ClassForm();
            classForm.ShowDialog();
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            Student_Calculator sc = new Student_Calculator();
            sc.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Replace_Staff rs = new Replace_Staff();
            rs.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            AllocateStaffToClasses allocateStaff = new AllocateStaffToClasses();
            allocateStaff.ShowDialog();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            PaidStudents paidStudents = new PaidStudents();
            paidStudents.ShowDialog();
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            Unpaid_Students unPaidStudents = new Unpaid_Students();
            unPaidStudents.ShowDialog();
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            DailyFee df = new DailyFee();
            df.ShowDialog();
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            MonthlyFeeDetail monthlyFee = new MonthlyFeeDetail();
            monthlyFee.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            IncomeForm incomeForm = new IncomeForm();
            incomeForm.ShowDialog();
        }
    }
}
