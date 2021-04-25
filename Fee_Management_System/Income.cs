using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fee_Management_System
{
    public partial class Income : Form
    {
        public Income()
        {
            InitializeComponent();
        }

        private ComboBox cbxMonth;
        private TextBox txtIncomeAmount;
        private TextBox txtIncomeTitle;
        private TextBox txtIncomeId;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Button btnReset;
        private Button btnDelete;
        private Button btnUpdate;
        private Button b;

        string _month = "";
        public Income(string month)
        {
            InitializeComponent();
            _month = month;
        }

        private void loadMonth()
        {
            cbxMonth.Items.Clear();
            string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string query = "SELECT months from months order by mid desc";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbxMonth.Items.Add(dr["months"].ToString());
            }
            con.Close();

            cbxMonth.SelectedIndex = 0;
        }

        private bool isValidated()
        {
            if (cbxMonth.SelectedItem.ToString() == "")
            {
                MessageBox.Show("Please provide a valid month", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtIncomeTitle.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Please provide a valid Title", "Invalid Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIncomeTitle.Focus();
                return false;
            }

            if (txtIncomeAmount.Text.ToString().Trim() == "")
            {
                MessageBox.Show("Please provide a valid Income", "Invalid Income", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIncomeAmount.Focus();
                return false;
            }

            return true;
        }


    

        private void showMessage(bool id, string v)
        {
            if (id)
            {
                MessageBox.Show("Income is " + v + " successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                reset();
            }
            else
            {
                MessageBox.Show("Something went wrong!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void reset()
        {
            try
            {
                txtIncomeId.Text = "";
                cbxMonth.SelectedIndex = 0;
                txtIncomeTitle.Text = "";
                txtIncomeAmount.Text = "";
                txtIncomeTitle.Focus();
            }
            catch (Exception) { }
        }

        private void InitializeComponent()
        {
            this.cbxMonth = new System.Windows.Forms.ComboBox();
            this.txtIncomeAmount = new System.Windows.Forms.TextBox();
            this.txtIncomeTitle = new System.Windows.Forms.TextBox();
            this.txtIncomeId = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.b = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbxMonth
            // 
            this.cbxMonth.FormattingEnabled = true;
            this.cbxMonth.Location = new System.Drawing.Point(183, 138);
            this.cbxMonth.Name = "cbxMonth";
            this.cbxMonth.Size = new System.Drawing.Size(180, 24);
            this.cbxMonth.TabIndex = 17;
            // 
            // txtIncomeAmount
            // 
            this.txtIncomeAmount.Location = new System.Drawing.Point(183, 216);
            this.txtIncomeAmount.Name = "txtIncomeAmount";
            this.txtIncomeAmount.Size = new System.Drawing.Size(180, 23);
            this.txtIncomeAmount.TabIndex = 12;
            // 
            // txtIncomeTitle
            // 
            this.txtIncomeTitle.Location = new System.Drawing.Point(183, 178);
            this.txtIncomeTitle.Name = "txtIncomeTitle";
            this.txtIncomeTitle.Size = new System.Drawing.Size(180, 23);
            this.txtIncomeTitle.TabIndex = 11;
            // 
            // txtIncomeId
            // 
            this.txtIncomeId.Location = new System.Drawing.Point(183, 97);
            this.txtIncomeId.Name = "txtIncomeId";
            this.txtIncomeId.ReadOnly = true;
            this.txtIncomeId.Size = new System.Drawing.Size(120, 23);
            this.txtIncomeId.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(65, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Income : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(65, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 22;
            this.label4.Text = "Title : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 21;
            this.label3.Text = "Month : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.TabIndex = 20;
            this.label2.Text = "Income_ID : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(141, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Manage Income";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(354, 262);
            this.btnReset.Margin = new System.Windows.Forms.Padding(4);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 28);
            this.btnReset.TabIndex = 16;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click_1);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 262);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 28);
            this.btnDelete.TabIndex = 15;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(138, 262);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // b
            // 
            this.b.Location = new System.Drawing.Point(30, 262);
            this.b.Margin = new System.Windows.Forms.Padding(4);
            this.b.Name = "b";
            this.b.Size = new System.Drawing.Size(100, 28);
            this.b.TabIndex = 13;
            this.b.Text = "Add";
            this.b.UseVisualStyleBackColor = true;
            this.b.Click += new System.EventHandler(this.b_Click_1);
            // 
            // Income
            // 
            this.ClientSize = new System.Drawing.Size(485, 323);
            this.Controls.Add(this.cbxMonth);
            this.Controls.Add(this.txtIncomeAmount);
            this.Controls.Add(this.txtIncomeTitle);
            this.Controls.Add(this.txtIncomeId);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.b);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Income";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Income_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Income_Load_1(object sender, EventArgs e)
        {
            loadMonth();
            if (IncomeClass.incomeTitle.ToString() != "")
            {
                txtIncomeId.Text = IncomeClass.incomeId.ToString();
                cbxMonth.Text = IncomeClass.incomeMonth.ToString();
                txtIncomeTitle.Text = IncomeClass.incomeTitle.ToString();
                txtIncomeAmount.Text = IncomeClass.incomeAmount.ToString();
            }

            if (_month != "")
            {
                cbxMonth.Text = _month;
            }
        }

        private void b_Click_1(object sender, EventArgs e)
        {
            if(isValidated() && txtIncomeId.Text.ToString() == "")
            {
                string date = DateTime.Now.ToShortDateString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "Insert into otherIncome( date, title, income, month ) values (  @date,  @title, @income, @month ) ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("date", date));
                cmd.Parameters.Add(new SqlParameter("title", txtIncomeTitle.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("income", txtIncomeAmount.Text.ToString()));
                cmd.Parameters.Add(new SqlParameter("month", cbxMonth.SelectedItem.ToString()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "added");
                con.Close();
            }

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            if(isValidated() && txtIncomeId.Text.ToString() != "")
            {
                string date = DateTime.Now.ToShortDateString();
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "UPDATE otherIncome set date = @date, title = @title, income = @income where id = @id ";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("date", date));
                cmd.Parameters.Add(new SqlParameter("title", txtIncomeTitle.Text.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("income", txtIncomeAmount.Text.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("month", cbxMonth.SelectedItem.ToString().Trim()));
                cmd.Parameters.Add(new SqlParameter("id", txtIncomeId.Text.ToString().Trim()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "updated");
                con.Close();
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (isValidated() && txtIncomeId.Text.ToString() != "")
            {
                string constr = ConfigurationManager.ConnectionStrings["dbpath"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                string query = "DELETE FROM otherIncome where id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add(new SqlParameter("id", txtIncomeId.Text.ToString()));
                Boolean id = Convert.ToBoolean(cmd.ExecuteNonQuery());
                showMessage(id, "deleted");
                con.Close();
            }
        }

        private void btnReset_Click_1(object sender, EventArgs e)
        {
            reset();
        }
    }
}
