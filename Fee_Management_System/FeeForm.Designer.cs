namespace Fee_Management_System
{
    partial class FeeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnContinue = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbxMonths = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFee = new System.Windows.Forms.TextBox();
            this.txtnewMonth = new System.Windows.Forms.TextBox();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.manageStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStaffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replaceStaffMemberToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allocateStaffToClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPaidStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUnPaidStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbxclasses = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.malefemale = new System.Windows.Forms.ComboBox();
            this.SelectInstructor = new System.Windows.Forms.ComboBox();
            this.feeDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dailyFeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyFeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyIncomeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(365, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(223, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Fee Form";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(23, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(143, 24);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dgvStudents
            // 
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Location = new System.Drawing.Point(31, 219);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(760, 215);
            this.dgvStudents.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(428, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Enter Fee";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnContinue);
            this.groupBox3.Controls.Add(this.btnRefresh);
            this.groupBox3.Controls.Add(this.cbxMonths);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtFee);
            this.groupBox3.Controls.Add(this.txtnewMonth);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(111, 441);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(759, 140);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fee Datails";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(398, 73);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnContinue
            // 
            this.btnContinue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContinue.Location = new System.Drawing.Point(619, 74);
            this.btnContinue.Name = "btnContinue";
            this.btnContinue.Size = new System.Drawing.Size(103, 38);
            this.btnContinue.TabIndex = 2;
            this.btnContinue.Text = "Print";
            this.btnContinue.UseVisualStyleBackColor = true;
            this.btnContinue.Click += new System.EventHandler(this.btnContinue_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(508, 72);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(103, 38);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Pay";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbxMonths
            // 
            this.cbxMonths.FormattingEnabled = true;
            this.cbxMonths.Location = new System.Drawing.Point(227, 35);
            this.cbxMonths.Name = "cbxMonths";
            this.cbxMonths.Size = new System.Drawing.Size(150, 26);
            this.cbxMonths.TabIndex = 1;
            this.cbxMonths.SelectedIndexChanged += new System.EventHandler(this.cbxMonths_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Select Month";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(145, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "OR add new month";
            // 
            // txtFee
            // 
            this.txtFee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFee.Location = new System.Drawing.Point(526, 29);
            this.txtFee.Name = "txtFee";
            this.txtFee.Size = new System.Drawing.Size(154, 23);
            this.txtFee.TabIndex = 1;
            this.txtFee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFee_KeyPress);
            // 
            // txtnewMonth
            // 
            this.txtnewMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnewMonth.Location = new System.Drawing.Point(227, 90);
            this.txtnewMonth.Name = "txtnewMonth";
            this.txtnewMonth.Size = new System.Drawing.Size(150, 23);
            this.txtnewMonth.TabIndex = 1;
            this.txtnewMonth.TextChanged += new System.EventHandler(this.txtnewMonth_TextChanged);
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.manageStudentsToolStripMenuItem,
            this.manageStaffToolStripMenuItem,
            this.checkDetailsToolStripMenuItem,
            this.feeDetailsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // manageStudentsToolStripMenuItem
            // 
            this.manageStudentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentsToolStripMenuItem,
            this.updateClassesToolStripMenuItem,
            this.checkStudentsToolStripMenuItem});
            this.manageStudentsToolStripMenuItem.Name = "manageStudentsToolStripMenuItem";
            this.manageStudentsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.manageStudentsToolStripMenuItem.Text = "Manage Students";
            // 
            // addStudentsToolStripMenuItem
            // 
            this.addStudentsToolStripMenuItem.Name = "addStudentsToolStripMenuItem";
            this.addStudentsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.addStudentsToolStripMenuItem.Text = "Add Students";
            this.addStudentsToolStripMenuItem.Click += new System.EventHandler(this.addStudentsToolStripMenuItem_Click);
            // 
            // updateClassesToolStripMenuItem
            // 
            this.updateClassesToolStripMenuItem.Name = "updateClassesToolStripMenuItem";
            this.updateClassesToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.updateClassesToolStripMenuItem.Text = "Update Classes";
            this.updateClassesToolStripMenuItem.Click += new System.EventHandler(this.updateClassesToolStripMenuItem_Click);
            // 
            // checkStudentsToolStripMenuItem
            // 
            this.checkStudentsToolStripMenuItem.Name = "checkStudentsToolStripMenuItem";
            this.checkStudentsToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.checkStudentsToolStripMenuItem.Text = "Check Students";
            this.checkStudentsToolStripMenuItem.Click += new System.EventHandler(this.checkStudentsToolStripMenuItem_Click);
            // 
            // manageStaffToolStripMenuItem
            // 
            this.manageStaffToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStaffToolStripMenuItem,
            this.replaceStaffMemberToolStripMenuItem,
            this.allocateStaffToClassesToolStripMenuItem});
            this.manageStaffToolStripMenuItem.Name = "manageStaffToolStripMenuItem";
            this.manageStaffToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.manageStaffToolStripMenuItem.Text = "Manage Staff";
            this.manageStaffToolStripMenuItem.Click += new System.EventHandler(this.manageStaffToolStripMenuItem_Click);
            // 
            // addStaffToolStripMenuItem
            // 
            this.addStaffToolStripMenuItem.Name = "addStaffToolStripMenuItem";
            this.addStaffToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.addStaffToolStripMenuItem.Text = "Add Staff Member";
            this.addStaffToolStripMenuItem.Click += new System.EventHandler(this.addStaffToolStripMenuItem_Click);
            // 
            // replaceStaffMemberToolStripMenuItem
            // 
            this.replaceStaffMemberToolStripMenuItem.Name = "replaceStaffMemberToolStripMenuItem";
            this.replaceStaffMemberToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.replaceStaffMemberToolStripMenuItem.Text = "Replace Staff Member";
            this.replaceStaffMemberToolStripMenuItem.Click += new System.EventHandler(this.replaceStaffMemberToolStripMenuItem_Click);
            // 
            // allocateStaffToClassesToolStripMenuItem
            // 
            this.allocateStaffToClassesToolStripMenuItem.Name = "allocateStaffToClassesToolStripMenuItem";
            this.allocateStaffToClassesToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.allocateStaffToClassesToolStripMenuItem.Text = "Allocate Staff to Classes";
            this.allocateStaffToClassesToolStripMenuItem.Click += new System.EventHandler(this.allocateStaffToClassesToolStripMenuItem_Click);
            // 
            // checkDetailsToolStripMenuItem
            // 
            this.checkDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkPaidStudentsToolStripMenuItem,
            this.checkUnPaidStudentsToolStripMenuItem});
            this.checkDetailsToolStripMenuItem.Name = "checkDetailsToolStripMenuItem";
            this.checkDetailsToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
            this.checkDetailsToolStripMenuItem.Text = "Student Details";
            // 
            // checkPaidStudentsToolStripMenuItem
            // 
            this.checkPaidStudentsToolStripMenuItem.Name = "checkPaidStudentsToolStripMenuItem";
            this.checkPaidStudentsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.checkPaidStudentsToolStripMenuItem.Text = "Paid Students";
            this.checkPaidStudentsToolStripMenuItem.Click += new System.EventHandler(this.checkPaidStudentsToolStripMenuItem_Click);
            // 
            // checkUnPaidStudentsToolStripMenuItem
            // 
            this.checkUnPaidStudentsToolStripMenuItem.Name = "checkUnPaidStudentsToolStripMenuItem";
            this.checkUnPaidStudentsToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.checkUnPaidStudentsToolStripMenuItem.Text = "UnPaid Students";
            this.checkUnPaidStudentsToolStripMenuItem.Click += new System.EventHandler(this.checkUnPaidStudentsToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.cbxclasses);
            this.groupBox4.Controls.Add(this.txtSearch);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.malefemale);
            this.groupBox4.Controls.Add(this.SelectInstructor);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(31, 110);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(608, 103);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Search Student By";
            // 
            // cbxclasses
            // 
            this.cbxclasses.FormattingEnabled = true;
            this.cbxclasses.Items.AddRange(new object[] {
            "Nursery",
            "Prep",
            "1st",
            "2nd",
            "3rd",
            "4th",
            "5th",
            "6th",
            "7th",
            "8th",
            "9th",
            "10th"});
            this.cbxclasses.Location = new System.Drawing.Point(339, 57);
            this.cbxclasses.Name = "cbxclasses";
            this.cbxclasses.Size = new System.Drawing.Size(129, 26);
            this.cbxclasses.TabIndex = 5;
            this.cbxclasses.SelectedIndexChanged += new System.EventHandler(this.cbxclasses_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(486, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 4;
            this.label9.Text = "Gender";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(336, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 17);
            this.label10.TabIndex = 4;
            this.label10.Text = "Class";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(180, 36);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 17);
            this.label11.TabIndex = 4;
            this.label11.Text = "Instructor";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(20, 36);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Typing";
            // 
            // malefemale
            // 
            this.malefemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.malefemale.FormattingEnabled = true;
            this.malefemale.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.malefemale.Location = new System.Drawing.Point(489, 59);
            this.malefemale.Name = "malefemale";
            this.malefemale.Size = new System.Drawing.Size(94, 26);
            this.malefemale.TabIndex = 3;
            this.malefemale.SelectedIndexChanged += new System.EventHandler(this.malefemale_SelectedIndexChanged);
            // 
            // SelectInstructor
            // 
            this.SelectInstructor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectInstructor.FormattingEnabled = true;
            this.SelectInstructor.Location = new System.Drawing.Point(183, 59);
            this.SelectInstructor.Name = "SelectInstructor";
            this.SelectInstructor.Size = new System.Drawing.Size(131, 24);
            this.SelectInstructor.TabIndex = 0;
            this.SelectInstructor.SelectedIndexChanged += new System.EventHandler(this.SelectInstructor_SelectedIndexChanged);
            // 
            // feeDetailsToolStripMenuItem
            // 
            this.feeDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dailyFeeToolStripMenuItem,
            this.monthlyFeeToolStripMenuItem,
            this.monthlyIncomeToolStripMenuItem});
            this.feeDetailsToolStripMenuItem.Name = "feeDetailsToolStripMenuItem";
            this.feeDetailsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.feeDetailsToolStripMenuItem.Text = "Fee Details";
            // 
            // dailyFeeToolStripMenuItem
            // 
            this.dailyFeeToolStripMenuItem.Name = "dailyFeeToolStripMenuItem";
            this.dailyFeeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.dailyFeeToolStripMenuItem.Text = "Daily Fee";
            this.dailyFeeToolStripMenuItem.Click += new System.EventHandler(this.dailyFeeToolStripMenuItem_Click);
            // 
            // monthlyFeeToolStripMenuItem
            // 
            this.monthlyFeeToolStripMenuItem.Name = "monthlyFeeToolStripMenuItem";
            this.monthlyFeeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.monthlyFeeToolStripMenuItem.Text = "Monthly Fee";
            this.monthlyFeeToolStripMenuItem.Click += new System.EventHandler(this.monthlyFeeToolStripMenuItem_Click);
            // 
            // monthlyIncomeToolStripMenuItem
            // 
            this.monthlyIncomeToolStripMenuItem.Name = "monthlyIncomeToolStripMenuItem";
            this.monthlyIncomeToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.monthlyIncomeToolStripMenuItem.Text = "Monthly Income";
            this.monthlyIncomeToolStripMenuItem.Click += new System.EventHandler(this.monthlyIncomeToolStripMenuItem_Click);
            // 
            // FeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 659);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.dgvStudents);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FeeForm";
            this.Text = "Fee Form";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FeeForm_FormClosing);
            this.Load += new System.EventHandler(this.FeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnContinue;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbxMonths;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFee;
        private System.Windows.Forms.TextBox txtnewMonth;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem manageStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStaffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkPaidStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUnPaidStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateClassesToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox malefemale;
        private System.Windows.Forms.ComboBox SelectInstructor;
        private System.Windows.Forms.ComboBox cbxclasses;
        private System.Windows.Forms.ToolStripMenuItem checkStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStaffToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replaceStaffMemberToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allocateStaffToClassesToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem feeDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dailyFeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyFeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthlyIncomeToolStripMenuItem;
    }
}