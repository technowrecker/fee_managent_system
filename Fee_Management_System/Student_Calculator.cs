using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Student_Calculator : Form
    {
        public Student_Calculator()
        {
            InitializeComponent();
        }

        public string[] classes = { "Nursery", "Prep", "1st", "2nd", "3rd", "4th", "5th", "6th", "7th", "8th", "9th", "10th" };

        private void Student_Calculator_Load(object sender, EventArgs e)
        {

        }

        private void countStudents()
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();


            string gender = "Male";
            string maleStudents = "0";
            string femaleStudents = "0";



            for (int i = 0; i < classes.Length; i++)
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "select count(*) as n  from student where class = @c and gender = @g and session is null";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("c", classes[i]));
                cmd.Parameters.Add(new SqlParameter("g", gender));
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    maleStudents = dr["n"].ToString();


                }




                con.Close();
                if (gender == "Male")
                {
                    gender = "Female";
                }
                else
                {
                    gender = "Male";
                }
                string constr1 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con1 = new SqlConnection(constr);
                con1.Open();
                string query1 = "select count(*) as n  from student where class = @c and gender = @g and session is null";
                SqlCommand cmd1 = new SqlCommand(query1, con1);
                cmd1.Parameters.Add(new SqlParameter("c", classes[i]));
                cmd1.Parameters.Add(new SqlParameter("g", gender));
                SqlDataReader dr1 = cmd1.ExecuteReader();
                try
                {
                    while (dr1.Read())
                    {
                        femaleStudents = dr1["n"].ToString();

                    }
                    dr1.Close();
                }
                catch (Exception exp1)
                {
                    MessageBox.Show(exp1.ToString());

                }
                if (gender == "Male")
                {
                    gender = "Female";
                }
                else
                {
                    gender = "Male";
                }
                con1.Close();
                try
                {
                    ListViewItem lvi = new ListViewItem(classes[i]);
                    lvi.SubItems.Add(maleStudents);
                    lvi.SubItems.Add(femaleStudents);

                    listView1.Items.Add(lvi);
                }
                catch (Exception exps)
                {
                    MessageBox.Show(exps.ToString());

                }


            }
            string constr2 = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con2 = new SqlConnection(constr2);
            con2.Open();
            string query2 = "select count(*) as n  from student where session is null";
            SqlCommand cmd2 = new SqlCommand(query2, con2);

            SqlDataReader dr2 = cmd2.ExecuteReader();
            try
            {
                while (dr2.Read())
                {
                    lbltotalstudents.Text = dr2["n"].ToString();

                }

            }
            catch (Exception exp1)
            {
                MessageBox.Show(exp1.ToString());

            }



            con2.Close();


        }

        private void Student_Calculator_Load_1(object sender, EventArgs e)
        {

        }
    }

}
