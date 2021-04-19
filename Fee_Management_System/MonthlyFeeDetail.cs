using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class MonthlyFeeDetail : Form
    {
        public MonthlyFeeDetail()
        {
            InitializeComponent();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void MonthlyFeeDetail_Load(object sender, EventArgs e)
        {
            loadMonths();
            loadData();

        }

        private void loadMonths()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT months from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxMonths.Items.Add(dr["months"].ToString());
            }


            con.Close();
            cbxMonths.SelectedIndex = 0;
        }

        private void loadData()
        {
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "Select name 'Student name', father_name 'Father name',  caste 'Caste',class 'Class', gender 'Gender',  fee_price 'Fee', date 'Date' from student s , fee f where s.id = f.id and fee_month = @fm ";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.Add(new SqlParameter("fm", cbxMonths.SelectedItem.ToString()));

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvStudents.DataSource = dt;
            dgvStudents.Refresh();


            con.Close();
        }

        private void cbxMonths_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "KPS Monthly Fee Detail";
            printer.SubTitle = cbxMonths.SelectedItem.ToString();
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Khursheed Public Higher Secondary School Dibbi Shah";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dgvStudents);

        }
    }
}
