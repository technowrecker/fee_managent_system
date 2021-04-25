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
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemainingIncome = new System.Windows.Forms.TextBox();
            this.dgvOtherIncome = new System.Windows.Forms.DataGridView();
            this.btnAddOtherIncome = new System.Windows.Forms.Button();
            this.txtOtherIncomeTotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPrintOtherIncome = new System.Windows.Forms.Button();
            this.btnPrintExpenses = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaidStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpenses)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherIncome)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cbxMonths);
            this.groupBox1.Location = new System.Drawing.Point(13, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(239, 62);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Month";
            // 
            // cbxMonths
            // 
            this.cbxMonths.FormattingEnabled = true;
            this.cbxMonths.Location = new System.Drawing.Point(8, 24);
            this.cbxMonths.Margin = new System.Windows.Forms.Padding(4);
            this.cbxMonths.Name = "cbxMonths";
            this.cbxMonths.Size = new System.Drawing.Size(207, 24);
            this.cbxMonths.TabIndex = 0;
            this.cbxMonths.SelectedIndexChanged += new System.EventHandler(this.cbxMonths_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(365, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 29);
            this.label1.TabIndex = 7;
            this.label1.Text = "Income Details ";
            // 
            // dgvPaidStudents
            // 
            this.dgvPaidStudents.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvPaidStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaidStudents.Location = new System.Drawing.Point(13, 166);
            this.dgvPaidStudents.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPaidStudents.Name = "dgvPaidStudents";
            this.dgvPaidStudents.ReadOnly = true;
            this.dgvPaidStudents.Size = new System.Drawing.Size(333, 209);
            this.dgvPaidStudents.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 386);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Total : ";
            // 
            // txtgrandTotal
            // 
            this.txtgrandTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtgrandTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgrandTotal.Location = new System.Drawing.Point(82, 383);
            this.txtgrandTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtgrandTotal.Name = "txtgrandTotal";
            this.txtgrandTotal.ReadOnly = true;
            this.txtgrandTotal.Size = new System.Drawing.Size(161, 23);
            this.txtgrandTotal.TabIndex = 11;
            this.txtgrandTotal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvExpenses
            // 
            this.dgvExpenses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvExpenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpenses.Location = new System.Drawing.Point(13, 437);
            this.dgvExpenses.Margin = new System.Windows.Forms.Padding(4);
            this.dgvExpenses.Name = "dgvExpenses";
            this.dgvExpenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvExpenses.Size = new System.Drawing.Size(647, 209);
            this.dgvExpenses.TabIndex = 12;
            this.dgvExpenses.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpenses_CellClick);
            // 
            // btnAddExpense
            // 
            this.btnAddExpense.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddExpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddExpense.Location = new System.Drawing.Point(416, 654);
            this.btnAddExpense.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddExpense.Name = "btnAddExpense";
            this.btnAddExpense.Size = new System.Drawing.Size(125, 28);
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
            this.label3.Location = new System.Drawing.Point(179, 660);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total : ";
            // 
            // txtExpenseTotal
            // 
            this.txtExpenseTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtExpenseTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpenseTotal.Location = new System.Drawing.Point(247, 657);
            this.txtExpenseTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtExpenseTotal.Name = "txtExpenseTotal";
            this.txtExpenseTotal.ReadOnly = true;
            this.txtExpenseTotal.Size = new System.Drawing.Size(161, 23);
            this.txtExpenseTotal.TabIndex = 11;
            this.txtExpenseTotal.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(256, 109);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remaining Budget";
            // 
            // txtRemainingIncome
            // 
            this.txtRemainingIncome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtRemainingIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemainingIncome.Location = new System.Drawing.Point(259, 133);
            this.txtRemainingIncome.Margin = new System.Windows.Forms.Padding(4);
            this.txtRemainingIncome.Name = "txtRemainingIncome";
            this.txtRemainingIncome.ReadOnly = true;
            this.txtRemainingIncome.Size = new System.Drawing.Size(185, 23);
            this.txtRemainingIncome.TabIndex = 11;
            this.txtRemainingIncome.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvOtherIncome
            // 
            this.dgvOtherIncome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvOtherIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOtherIncome.Location = new System.Drawing.Point(354, 166);
            this.dgvOtherIncome.Margin = new System.Windows.Forms.Padding(4);
            this.dgvOtherIncome.Name = "dgvOtherIncome";
            this.dgvOtherIncome.ReadOnly = true;
            this.dgvOtherIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOtherIncome.Size = new System.Drawing.Size(647, 209);
            this.dgvOtherIncome.TabIndex = 14;
            this.dgvOtherIncome.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOtherIncome_CellClick);
            // 
            // btnAddOtherIncome
            // 
            this.btnAddOtherIncome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddOtherIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddOtherIncome.Location = new System.Drawing.Point(767, 380);
            this.btnAddOtherIncome.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOtherIncome.Name = "btnAddOtherIncome";
            this.btnAddOtherIncome.Size = new System.Drawing.Size(125, 28);
            this.btnAddOtherIncome.TabIndex = 17;
            this.btnAddOtherIncome.Text = "Add Income";
            this.btnAddOtherIncome.UseVisualStyleBackColor = true;
            this.btnAddOtherIncome.Click += new System.EventHandler(this.btnAddOtherIncome_Click);
            // 
            // txtOtherIncomeTotal
            // 
            this.txtOtherIncomeTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOtherIncomeTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherIncomeTotal.Location = new System.Drawing.Point(598, 383);
            this.txtOtherIncomeTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtOtherIncomeTotal.Name = "txtOtherIncomeTotal";
            this.txtOtherIncomeTotal.ReadOnly = true;
            this.txtOtherIncomeTotal.Size = new System.Drawing.Size(161, 23);
            this.txtOtherIncomeTotal.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(530, 386);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Total : ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(452, 129);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 28);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // btnPrintOtherIncome
            // 
            this.btnPrintOtherIncome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintOtherIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintOtherIncome.Location = new System.Drawing.Point(900, 380);
            this.btnPrintOtherIncome.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintOtherIncome.Name = "btnPrintOtherIncome";
            this.btnPrintOtherIncome.Size = new System.Drawing.Size(101, 28);
            this.btnPrintOtherIncome.TabIndex = 19;
            this.btnPrintOtherIncome.Text = "Print";
            this.btnPrintOtherIncome.UseVisualStyleBackColor = true;
            this.btnPrintOtherIncome.Click += new System.EventHandler(this.btnPrintOtherIncome_Click_1);
            // 
            // btnPrintExpenses
            // 
            this.btnPrintExpenses.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPrintExpenses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintExpenses.Location = new System.Drawing.Point(549, 654);
            this.btnPrintExpenses.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrintExpenses.Name = "btnPrintExpenses";
            this.btnPrintExpenses.Size = new System.Drawing.Size(111, 28);
            this.btnPrintExpenses.TabIndex = 20;
            this.btnPrintExpenses.Text = "Print";
            this.btnPrintExpenses.UseVisualStyleBackColor = true;
            this.btnPrintExpenses.Click += new System.EventHandler(this.btnPrintExpenses_Click);
            // 
            // IncomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 749);
            this.Controls.Add(this.btnPrintExpenses);
            this.Controls.Add(this.btnPrintOtherIncome);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddOtherIncome);
            this.Controls.Add(this.txtOtherIncomeTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvOtherIncome);
            this.Controls.Add(this.btnAddExpense);
            this.Controls.Add(this.dgvExpenses);
            this.Controls.Add(this.txtExpenseTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemainingIncome);
            this.Controls.Add(this.txtgrandTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPaidStudents);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvOtherIncome)).EndInit();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRemainingIncome;
        private System.Windows.Forms.DataGridView dgvOtherIncome;
        private System.Windows.Forms.Button btnAddOtherIncome;
        private System.Windows.Forms.TextBox txtOtherIncomeTotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPrintOtherIncome;
        private System.Windows.Forms.Button btnPrintExpenses;
    }
}