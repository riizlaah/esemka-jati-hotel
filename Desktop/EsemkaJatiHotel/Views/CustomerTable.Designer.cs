namespace EsemkaJatiHotel.Views
{
    partial class CustomerTable
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.table0 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.table0)).BeginInit();
            this.SuspendLayout();
            // 
            // table0
            // 
            this.table0.AllowUserToAddRows = false;
            this.table0.AllowUserToDeleteRows = false;
            this.table0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.table0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table0.Location = new System.Drawing.Point(4, 4);
            this.table0.MultiSelect = false;
            this.table0.Name = "table0";
            this.table0.RowHeadersWidth = 51;
            this.table0.RowTemplate.Height = 24;
            this.table0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table0.Size = new System.Drawing.Size(399, 213);
            this.table0.TabIndex = 0;
            // 
            // CustomerTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.table0);
            this.Name = "CustomerTable";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(407, 221);
            ((System.ComponentModel.ISupportInitialize)(this.table0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView table0;
    }
}
