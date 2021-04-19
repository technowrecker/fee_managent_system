namespace Fee_Management_System
{
    partial class IncomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxMonths = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPaidStudents = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtgrandTotal = new System.Windows.Forms.TextBox();
            this.dgvExpenses = new System.Windows.Forms.DataGridView();
            this.btnAddExpense = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtExpenseTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemainingIncome = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cbxMonths);
            this.groupBox1.Location = new System.Drawing.Point(69, 107);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(321, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Month";
            // 
            // cbxMonths
            // 
            this.cbxMonths.FormattingEnabled = true;
            this.cbxMonths.Location = new System.Drawing.Point(34, 24);
            this.cbxMonths.Name = "cbxMonths";
            this.cbxMonths.Size = new System.Drawing.Size(249, 21);
            this.cbxMonths.TabIndex = 0;
            this.cbxMonths.SelectedIndexChanged += new System.EventHandler(this.cbxMonths_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(351, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Income Details ";
            // 
            // dgvPaidStudents
            // 
            this.dgvPaidStudents.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPaidStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaidStudents.Location = new System.Drawing.Point(69, 187);
            this.dgvPaidStudents.Name = "dgvPaidStudents";
            this.dgvPaidStudents.ReadOnly = true;
            this.dgvPaidStudents.Size = new System.Drawing.Size(250, 170);
            this.dgvPaidStudents.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(110, 370);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total";
            // 
            // txtgrandTotal
            // 
            this.txtgrandTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtgrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgrandTotal.Location = new System.Drawing.Point(161, 367);
            this.txtgrandTotal.Name = "txtgrandTotal";
            this.txtgrandTotal.ReadOnly = true;
            this.txtgrandTotal.Size = new System.Drawing.Size(122, 23);
            this.txtgrandTotal.TabIndex = 11;
            this.txtgrandTotal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.Location = new System.Drawing.Point(325, 187);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(485, 170);
            this.dgvExpenses.TabIndex = 12;
            this.dgvExpenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellClick);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExpense.Location = new System.Drawing.Point(671, 363);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(139, 31);
            this.btnAddExpense.TabIndex = 13;
            this.btnAddExpense.Text = "Add Expenses";
            this.btnAddExpense.UseVisualStyleBackColor = true;
            this.btnAddExpense.Click += new System.EventHandler(this.btnAddExpense_Click);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(424, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total";
            // 
            // txtExpenseTotal
            // 
            this.txtExpenseTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExpenseTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseTotal.Location = new System.Drawing.Point(475, 367);
            this.txtExpenseTotal.Name = "txtExpenseTotal";
            this.txtExpenseTotal.ReadOnly = true;
            this.txtExpenseTotal.Size = new System.Drawing.Size(122, 23);
            this.txtExpenseTotal.TabIndex = 11;
            this.txtExpenseTotal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(178, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(494, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "---------------------------------------------------------------------------------" +
    "";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(542, 482);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remaining Budget";
            // 
            // txtRemainingIncome
            // 
            this.txtRemainingIncome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRemainingIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingIncome.Location = new System.Drawing.Point(688, 479);
            this.txtRemainingIncome.Name = "txtRemainingIncome";
            this.txtRemainingIncome.ReadOnly = true;
            this.txtRemainingIncome.Size = new System.Drawing.Size(122, 23);
            this.txtRemainingIncome.TabIndex = 11;
            this.txtRemainingIncome.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // IncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 545);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.dgvExpenses);
            this.Controls.Add(this.txtExpenseTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemainingIncome);
            this.Controls.Add(this.txtgrandTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPaidStudents);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IncomeForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.IncomeForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxMonths;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPaidStudents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtgrandTotal;
        private System.Windows.Forms.DataGridView dgvExpenses;
        private System.Windows.Forms.Button btnAddExpense;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtExpenseTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemainingIncome;
    }
}