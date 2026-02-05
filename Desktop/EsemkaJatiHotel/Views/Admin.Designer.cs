namespace EsemkaJatiHotel.Views
{
    partial class Admin
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.master = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FDItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reqAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exit = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.timeLb = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.employee = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.master});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1216, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutMenuItem,
            this.exitMenuItem});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(46, 26);
            this.file.Text = "File";
            // 
            // logoutMenuItem
            // 
            this.logoutMenuItem.Name = "logoutMenuItem";
            this.logoutMenuItem.Size = new System.Drawing.Size(145, 26);
            this.logoutMenuItem.Text = "Log Out";
            // 
            // exitMenuItem
            // 
            this.exitMenuItem.Name = "exitMenuItem";
            this.exitMenuItem.Size = new System.Drawing.Size(145, 26);
            this.exitMenuItem.Text = "Exit";
            // 
            // master
            // 
            this.master.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.employeesItem,
            this.FDItem,
            this.reqAddItem,
            this.roomTypeItem,
            this.roomItem});
            this.master.Name = "master";
            this.master.Size = new System.Drawing.Size(68, 26);
            this.master.Text = "Master";
            // 
            // employeesItem
            // 
            this.employeesItem.Name = "employeesItem";
            this.employeesItem.Size = new System.Drawing.Size(194, 26);
            this.employeesItem.Text = "Employee";
            // 
            // FDItem
            // 
            this.FDItem.Name = "FDItem";
            this.FDItem.Size = new System.Drawing.Size(194, 26);
            this.FDItem.Text = "Food and Drink";
            // 
            // reqAddItem
            // 
            this.reqAddItem.Name = "reqAddItem";
            this.reqAddItem.Size = new System.Drawing.Size(194, 26);
            this.reqAddItem.Text = "Item";
            // 
            // roomTypeItem
            // 
            this.roomTypeItem.Name = "roomTypeItem";
            this.roomTypeItem.Size = new System.Drawing.Size(194, 26);
            this.roomTypeItem.Text = "Room Type";
            // 
            // roomItem
            // 
            this.roomItem.Name = "roomItem";
            this.roomItem.Size = new System.Drawing.Size(194, 26);
            this.roomItem.Text = "Room";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 561F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 241F));
            this.tableLayoutPanel1.Controls.Add(this.exit, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.logout, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.timeLb, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.employee, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1216, 36);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exit.Location = new System.Drawing.Point(285, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(126, 30);
            this.exit.TabIndex = 11;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // logout
            // 
            this.logout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logout.Location = new System.Drawing.Point(153, 3);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(126, 30);
            this.logout.TabIndex = 10;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // timeLb
            // 
            this.timeLb.AutoSize = true;
            this.timeLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLb.Location = new System.Drawing.Point(978, 0);
            this.timeLb.Name = "timeLb";
            this.timeLb.Size = new System.Drawing.Size(235, 36);
            this.timeLb.TabIndex = 7;
            this.timeLb.Text = "4 Feb 2026, 14:39:50";
            this.timeLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(417, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 36);
            this.label1.TabIndex = 8;
            this.label1.Text = "Admin";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // employee
            // 
            this.employee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employee.Location = new System.Drawing.Point(3, 3);
            this.employee.Name = "employee";
            this.employee.Size = new System.Drawing.Size(144, 30);
            this.employee.TabIndex = 9;
            this.employee.Text = "Employee";
            this.employee.UseVisualStyleBackColor = true;
            this.employee.Click += new System.EventHandler(this.EmployeeClicked);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1216, 649);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Admin";
            this.Text = "FrontOffice";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMenuItem;
        private System.Windows.Forms.ToolStripMenuItem master;
        private System.Windows.Forms.ToolStripMenuItem employeesItem;
        private System.Windows.Forms.ToolStripMenuItem FDItem;
        private System.Windows.Forms.ToolStripMenuItem reqAddItem;
        private System.Windows.Forms.ToolStripMenuItem roomTypeItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem roomItem;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Label timeLb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button employee;
    }
}