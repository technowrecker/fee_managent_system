namespace Fee_Management_System
{
    partial class DashboardForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateClassesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageFeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addStudentFeeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkPaidStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkUnPaidStudentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incomeDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.manageStudentsToolStripMenuItem,
            this.manageFeeToolStripMenuItem,
            this.checkDetailsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(513, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.homeToolStripMenuItem.Text = "Home";
            // 
            // manageStudentsToolStripMenuItem
            // 
            this.manageStudentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentsToolStripMenuItem,
            this.updateClassesToolStripMenuItem});
            this.manageStudentsToolStripMenuItem.Name = "manageStudentsToolStripMenuItem";
            this.manageStudentsToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.manageStudentsToolStripMenuItem.Text = "Manage Students";
            // 
            // addStudentsToolStripMenuItem
            // 
            this.addStudentsToolStripMenuItem.Name = "addStudentsToolStripMenuItem";
            this.addStudentsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.addStudentsToolStripMenuItem.Text = "Add Students";
            this.addStudentsToolStripMenuItem.Click += new System.EventHandler(this.addStudentsToolStripMenuItem_Click);
            // 
            // updateClassesToolStripMenuItem
            // 
            this.updateClassesToolStripMenuItem.Name = "updateClassesToolStripMenuItem";
            this.updateClassesToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.updateClassesToolStripMenuItem.Text = "Update Classes";
            this.updateClassesToolStripMenuItem.Click += new System.EventHandler(this.updateClassesToolStripMenuItem_Click);
            // 
            // manageFeeToolStripMenuItem
            // 
            this.manageFeeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addStudentFeeToolStripMenuItem});
            this.manageFeeToolStripMenuItem.Name = "manageFeeToolStripMenuItem";
            this.manageFeeToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.manageFeeToolStripMenuItem.Text = "Manage Fee";
            // 
            // addStudentFeeToolStripMenuItem
            // 
            this.addStudentFeeToolStripMenuItem.Name = "addStudentFeeToolStripMenuItem";
            this.addStudentFeeToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addStudentFeeToolStripMenuItem.Text = "Add Student Fee";
            this.addStudentFeeToolStripMenuItem.Click += new System.EventHandler(this.addStudentFeeToolStripMenuItem_Click);
            // 
            // checkDetailsToolStripMenuItem
            // 
            this.checkDetailsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkPaidStudentsToolStripMenuItem,
            this.checkUnPaidStudentsToolStripMenuItem,
            this.incomeDetailsToolStripMenuItem});
            this.checkDetailsToolStripMenuItem.Name = "checkDetailsToolStripMenuItem";
            this.checkDetailsToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.checkDetailsToolStripMenuItem.Text = "Check Details";
            // 
            // checkPaidStudentsToolStripMenuItem
            // 
            this.checkPaidStudentsToolStripMenuItem.Name = "checkPaidStudentsToolStripMenuItem";
            this.checkPaidStudentsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.checkPaidStudentsToolStripMenuItem.Text = "Check Paid Students";
            this.checkPaidStudentsToolStripMenuItem.Click += new System.EventHandler(this.checkPaidStudentsToolStripMenuItem_Click);
            // 
            // checkUnPaidStudentsToolStripMenuItem
            // 
            this.checkUnPaidStudentsToolStripMenuItem.Name = "checkUnPaidStudentsToolStripMenuItem";
            this.checkUnPaidStudentsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.checkUnPaidStudentsToolStripMenuItem.Text = "Check UnPaid Students";
            this.checkUnPaidStudentsToolStripMenuItem.Click += new System.EventHandler(this.checkUnPaidStudentsToolStripMenuItem_Click);
            // 
            // incomeDetailsToolStripMenuItem
            // 
            this.incomeDetailsToolStripMenuItem.Name = "incomeDetailsToolStripMenuItem";
            this.incomeDetailsToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.incomeDetailsToolStripMenuItem.Text = "Income Details";
            this.incomeDetailsToolStripMenuItem.Click += new System.EventHandler(this.incomeDetailsToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 280);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DashboardForm_FormClosing);
            this.Load += new System.EventHandler(this.DashboardForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateClassesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageFeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStudentFeeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkPaidStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkUnPaidStudentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem incomeDetailsToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}