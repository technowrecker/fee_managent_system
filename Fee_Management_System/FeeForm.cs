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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FeeForm_Load(object sender, EventArgs e)
        {
            loadStaff();
            setClasses();
            setGender();
            loadmonths();

            try
            {
                string month = cbxMonths.SelectedItem.ToString();
                loadUnpaidStudentsByMonth(month);
            }
            catch (Exception)
            {
                loadAllStudents();
            }

            DataGridViewCheckBoxColumn cbxclm = new DataGridViewCheckBoxColumn();
            cbxclm.Name = "X";
            cbxclm.HeaderText = "";
            cbxclm.Width = 30;
            dgvStudents.Columns.Insert(0, cbxclm);

        }

        private void setGender()
        {
            malefemale.SelectedIndex = 0;
        }

        private void setClasses()
        {
            cbxclasses.SelectedIndex = 0;
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
            try
            {
                SelectInstructor.SelectedIndex = 0;
            }
            catch (Exception) { }
            con.Close();
            resetform();
        }

        private void loadmonths()
        {
            cbxMonths.Items.Clear();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT * from months order by mid desc";
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

        

        private void loadstudents()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where id not in( select id from fee where fee_month = @feeMonth ) and session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("feeMonth", cbxMonths.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();
        }

        private void resetform()
        {
            txtFee.Clear();
            txtnewMonth.Clear();
            loadmonths();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadDesiredData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                string month;
                int amount = Convert.ToInt32(txtFee.Text);

                // code for months
                if (txtnewMonth.Text.Trim().Length == 0)
                {
                    month = cbxMonths.SelectedItem.ToString();
                }
                else
                {
                    month = txtnewMonth.Text.Trim().ToString();
                    if (!addNewMonth(month))
                    {
                        MessageBox.Show("New month is not added");
                    }
                }


                // code for dgv rows

                foreach (DataGridViewRow dgvRow in dgvStudents.Rows)
                {
                    if(dgvRow.Cells[0].Value != null && Convert.ToBoolean(dgvRow.Cells[0].Value))
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

        private void btnContinue_Click(object sender, EventArgs e)
        {
            if (isvalidated())
            {
                string month;
                int amount = Convert.ToInt32(txtFee.Text);

                // code for months
                if (txtnewMonth.Text.Trim().Length == 0)
                {
                    month = cbxMonths.SelectedItem.ToString();
                }
                else
                {
                    month = txtnewMonth.Text.Trim().ToString();
                    if (!addNewMonth(month))
                    {
                        MessageBox.Show("New month is not added");
                    }
                }


                // code for dgv rows

                foreach (DataGridViewRow dgvRow in dgvStudents.Rows)
                {
                    if (dgvRow.Cells[0].Value != null && Convert.ToBoolean(dgvRow.Cells[0].Value))
                    {
                        int id = Convert.ToInt32(dgvRow.Cells[1].Value.ToString());
                        if (isPaid(Convert.ToInt32(dgvRow.Cells[1].Value), month))
                        {
                            if(Convert.ToBoolean(payStudentFee(id, month, amount))){
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

        private void printSlip()
        {
            SlipForm sdf = new SlipForm();
            sdf.ShowDialog();
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

        private void showslip()
        {
            SlipForm sf = new SlipForm();
            sf.ShowDialog();
        }

        private bool isvalidated()
        {

            if (txtFee.Text == "")
            {
                MessageBox.Show("Please add student fee!", "Invalid fee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFee.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void txtFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentForm sf = new StudentForm(); sf.ShowDialog();
        }

        private void manageStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FeeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkPaidStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PaidStudents ps = new PaidStudents(); ps.ShowDialog();
        }

        private void checkUnPaidStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Unpaid_Students us = new Unpaid_Students(); us.ShowDialog();
        }

        private void checkDailyFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyFee df = new DailyFee(); df.ShowDialog();
        }

        private void updateClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassForm cf = new ClassForm();
            cf.ShowDialog();
        }

        private void loadDesiredData()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();

            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', caste 'Caste', class 'Class', instructedby 'Instructed_By', gender 'Gender' from student where (name like @name or father_name like @name or caste like @name) and session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("name", "%" + txtSearch.Text.ToString() + "%"));

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
            string query = "SELECT  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where instructedby = @instructedby  and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("instructedby", SelectInstructor.SelectedItem.ToString()));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();

        }

        private void loaddata()
        {

            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',   name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where instructedby = @instructedby and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("instructedby", SelectInstructor.SelectedItem.ToString()));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();
        }

        private void cbxclasses_SelectedIndexChanged(object sender, EventArgs e)
        {
            malefemale.SelectedIndex = 0;
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where  class = @c and gender = @g and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("c", cbxclasses.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("g", malefemale.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();

        }

        private void malefemale_SelectedIndexChanged(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT id 'ID',  name 'Student Name' ,father_name 'Father Name', class 'Class', instructedby 'Instructed_By', gender 'Gender', caste 'Caste' from student where  class = @c and gender = @g and  session is null ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("c", cbxclasses.SelectedItem.ToString()));
            cmd.Parameters.Add(new SqlParameter("g", malefemale.SelectedItem.ToString()));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();
        }

        private void checkStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Student_Calculator sc = new Student_Calculator();
            sc.ShowDialog();
        }

        private void addStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Staff s = new Staff(); s.ShowDialog();
        }

        private void replaceStaffMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replace_Staff rs = new Replace_Staff();
            rs.ShowDialog();
        }

        private void allocateStaffToClassesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AllocateStaffToClasses ac = new AllocateStaffToClasses();
            ac.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadStaff();
            setClasses();
            setGender();
            loadstudents();
            loadmonths();
            
        }


        private void txtnewMonth_TextChanged(object sender, EventArgs e)
        {
            loadAllStudents();
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
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();
        }

        private void cbxMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            string month = cbxMonths.SelectedItem.ToString();
            loadUnpaidStudentsByMonth(month);
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
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();
            con.Close();
        }

        private void dailyFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DailyFee dailyFee = new DailyFee();
            dailyFee.ShowDialog();
        }

        private void monthlyFeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyFeeDetail mf = new MonthlyFeeDetail();
            mf.ShowDialog();
        }

        private void monthlyIncomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncomeForm i = new IncomeForm();
            i.ShowDialog();
        }
    }
}
