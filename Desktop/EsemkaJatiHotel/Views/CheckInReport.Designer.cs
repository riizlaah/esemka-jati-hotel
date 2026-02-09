namespace EsemkaJatiHotel.Views
{
    partial class CheckInReport
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
            this.checkInFrom = new System.Windows.Forms.RadioButton();
            this.checkInToday = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.to = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.from = new System.Windows.Forms.DateTimePicker();
            this.checkInTodayText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkInFrom);
            this.groupBox1.Controls.Add(this.checkInToday);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.to);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.from);
            this.groupBox1.Controls.Add(this.checkInTodayText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(8);
            this.groupBox1.Size = new System.Drawing.Size(440, 135);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose One Option to Print Preview";
            // 
            // checkInFrom
            // 
            this.checkInFrom.AutoSize = true;
            this.checkInFrom.Location = new System.Drawing.Point(22, 69);
            this.checkInFrom.Name = "checkInFrom";
            this.checkInFrom.Size = new System.Drawing.Size(113, 20);
            this.checkInFrom.TabIndex = 8;
            this.checkInFrom.TabStop = true;
            this.checkInFrom.Text = "Check In From";
            this.checkInFrom.UseVisualStyleBackColor = true;
            // 
            // checkInToday
            // 
            this.checkInToday.AutoSize = true;
            this.checkInToday.Checked = true;
            this.checkInToday.Location = new System.Drawing.Point(22, 36);
            this.checkInToday.Name = "checkInToday";
            this.checkInToday.Size = new System.Drawing.Size(122, 20);
            this.checkInToday.TabIndex = 7;
            this.checkInToday.TabStop = true;
            this.checkInToday.Text = "Check In Today";
            this.checkInToday.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 101);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 24);
            this.button1.TabIndex = 6;
            this.button1.Text = "Preview";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onPreviewClicked);
            // 
            // to
            // 
            this.to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.to.Location = new System.Drawing.Point(312, 64);
            this.to.Name = "to";
            this.to.Size = new System.Drawing.Size(110, 22);
            this.to.TabIndex = 5;
            this.to.ValueChanged += new System.EventHandler(this.onToDateChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(282, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "To";
            // 
            // from
            // 
            this.from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.from.Location = new System.Drawing.Point(163, 64);
            this.from.Name = "from";
            this.from.Size = new System.Drawing.Size(113, 22);
            this.from.TabIndex = 3;
            this.from.ValueChanged += new System.EventHandler(this.onFromDateChanged);
            // 
            // checkInTodayText
            // 
            this.checkInTodayText.Location = new System.Drawing.Point(163, 36);
            this.checkInTodayText.Name = "checkInTodayText";
            this.checkInTodayText.ReadOnly = true;
            this.checkInTodayText.Size = new System.Drawing.Size(259, 22);
            this.checkInTodayText.TabIndex = 2;
            // 
            // CheckInReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 135);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckInReport";
            this.Text = "CheckInReport";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton checkInFrom;
        private System.Windows.Forms.RadioButton checkInToday;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker to;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker from;
        private System.Windows.Forms.TextBox checkInTodayText;
    }
}