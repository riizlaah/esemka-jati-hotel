namespace EsemkaJatiHotel.Views
{
    partial class FrontOffice
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
            this.logoutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transaction = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reqAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.report = new System.Windows.Forms.ToolStripMenuItem();
            this.checkInReportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guestsReportItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.exit = new System.Windows.Forms.Button();
            this.logout = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeLb = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file,
            this.transaction,
            this.report});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1210, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file
            // 
            this.file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoutItem,
            this.exitItem});
            this.file.Name = "file";
            this.file.Size = new System.Drawing.Size(46, 24);
            this.file.Text = "File";
            // 
            // logoutItem
            // 
            this.logoutItem.Name = "logoutItem";
            this.logoutItem.Size = new System.Drawing.Size(145, 26);
            this.logoutItem.Text = "Log Out";
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(145, 26);
            this.exitItem.Text = "Exit";
            // 
            // transaction
            // 
            this.transaction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservationItem,
            this.checkInItem,
            this.reqAddItem,
            this.checkOutItem});
            this.transaction.Name = "transaction";
            this.transaction.Size = new System.Drawing.Size(98, 24);
            this.transaction.Text = "Transaction";
            // 
            // reservationItem
            // 
            this.reservationItem.Name = "reservationItem";
            this.reservationItem.Size = new System.Drawing.Size(253, 26);
            this.reservationItem.Text = "Reservation";
            // 
            // checkInItem
            // 
            this.checkInItem.Name = "checkInItem";
            this.checkInItem.Size = new System.Drawing.Size(253, 26);
            this.checkInItem.Text = "Check In";
            // 
            // reqAddItem
            // 
            this.reqAddItem.Name = "reqAddItem";
            this.reqAddItem.Size = new System.Drawing.Size(253, 26);
            this.reqAddItem.Text = "Request Additional Item";
            // 
            // checkOutItem
            // 
            this.checkOutItem.Name = "checkOutItem";
            this.checkOutItem.Size = new System.Drawing.Size(253, 26);
            this.checkOutItem.Text = "Check Out";
            // 
            // report
            // 
            this.report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkInReportItem,
            this.guestsReportItem});
            this.report.Name = "report";
            this.report.Size = new System.Drawing.Size(68, 24);
            this.report.Text = "Report";
            // 
            // checkInReportItem
            // 
            this.checkInReportItem.Name = "checkInReportItem";
            this.checkInReportItem.Size = new System.Drawing.Size(147, 26);
            this.checkInReportItem.Text = "Check In";
            // 
            // guestsReportItem
            // 
            this.guestsReportItem.Name = "guestsReportItem";
            this.guestsReportItem.Size = new System.Drawing.Size(147, 26);
            this.guestsReportItem.Text = "Guests";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 223F));
            this.tableLayoutPanel1.Controls.Add(this.exit, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.logout, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.timeLb, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1210, 36);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // exit
            // 
            this.exit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exit.Location = new System.Drawing.Point(459, 3);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(111, 30);
            this.exit.TabIndex = 4;
            this.exit.Text = "Exit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // logout
            // 
            this.logout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logout.Location = new System.Drawing.Point(353, 3);
            this.logout.Name = "logout";
            this.logout.Size = new System.Drawing.Size(100, 30);
            this.logout.TabIndex = 3;
            this.logout.Text = "Log Out";
            this.logout.UseVisualStyleBackColor = true;
            this.logout.Click += new System.EventHandler(this.logout_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(243, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "Check Out";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(123, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(114, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reservation";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.onReservationClicked);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "Check In";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onCheckIn);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(576, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(408, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "Front Office";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLb
            // 
            this.timeLb.AutoSize = true;
            this.timeLb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeLb.Location = new System.Drawing.Point(990, 0);
            this.timeLb.Name = "timeLb";
            this.timeLb.Size = new System.Drawing.Size(217, 36);
            this.timeLb.TabIndex = 6;
            this.timeLb.Text = "4 Feb 2026, 14:39:50";
            this.timeLb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrontOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 723);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrontOffice";
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
        private System.Windows.Forms.ToolStripMenuItem logoutItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem transaction;
        private System.Windows.Forms.ToolStripMenuItem reservationItem;
        private System.Windows.Forms.ToolStripMenuItem checkInItem;
        private System.Windows.Forms.ToolStripMenuItem reqAddItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutItem;
        private System.Windows.Forms.ToolStripMenuItem report;
        private System.Windows.Forms.ToolStripMenuItem checkInReportItem;
        private System.Windows.Forms.ToolStripMenuItem guestsReportItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button logout;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeLb;
    }
}