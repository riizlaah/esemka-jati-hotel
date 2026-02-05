namespace EsemkaJatiHotel.Views
{
    partial class MasterFD
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.table1 = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.save = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            this.picture1 = new System.Windows.Forms.PictureBox();
            this.openFile = new System.Windows.Forms.Button();
            this.price = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.filePicker = new System.Windows.Forms.OpenFileDialog();
            this.types = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.table1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.table1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 219);
            this.panel1.TabIndex = 0;
            // 
            // table1
            // 
            this.table1.AllowUserToAddRows = false;
            this.table1.AllowUserToDeleteRows = false;
            this.table1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.table1.Location = new System.Drawing.Point(0, 0);
            this.table1.MultiSelect = false;
            this.table1.Name = "table1";
            this.table1.ReadOnly = true;
            this.table1.RowHeadersWidth = 51;
            this.table1.RowTemplate.Height = 24;
            this.table1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.table1.Size = new System.Drawing.Size(794, 219);
            this.table1.TabIndex = 0;
            this.table1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onTableCellClicked);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.types);
            this.panel2.Controls.Add(this.save);
            this.panel2.Controls.Add(this.cancel);
            this.panel2.Controls.Add(this.delete);
            this.panel2.Controls.Add(this.update);
            this.panel2.Controls.Add(this.insert);
            this.panel2.Controls.Add(this.picture1);
            this.panel2.Controls.Add(this.openFile);
            this.panel2.Controls.Add(this.price);
            this.panel2.Controls.Add(this.name);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 219);
            this.panel2.TabIndex = 1;
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(633, 158);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(152, 23);
            this.save.TabIndex = 17;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.onSave);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(633, 187);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(152, 23);
            this.cancel.TabIndex = 16;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.onCancel);
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(633, 71);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(152, 23);
            this.delete.TabIndex = 15;
            this.delete.Text = "Delete";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.onDelete);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(633, 42);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(152, 23);
            this.update.TabIndex = 14;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.onUpdate);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(633, 13);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(152, 23);
            this.insert.TabIndex = 13;
            this.insert.Text = "Insert";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.onCreate);
            // 
            // picture1
            // 
            this.picture1.Location = new System.Drawing.Point(361, 16);
            this.picture1.Name = "picture1";
            this.picture1.Size = new System.Drawing.Size(249, 194);
            this.picture1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picture1.TabIndex = 12;
            this.picture1.TabStop = false;
            // 
            // openFile
            // 
            this.openFile.Location = new System.Drawing.Point(104, 134);
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(239, 23);
            this.openFile.TabIndex = 10;
            this.openFile.Text = "Open File";
            this.openFile.UseVisualStyleBackColor = true;
            this.openFile.Click += new System.EventHandler(this.onFilePickClicked);
            // 
            // price
            // 
            this.price.Location = new System.Drawing.Point(104, 97);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(239, 22);
            this.price.TabIndex = 9;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(104, 16);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(239, 22);
            this.name.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Photo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Price";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Name";
            // 
            // filePicker
            // 
            this.filePicker.InitialDirectory = "C:\\";
            // 
            // types
            // 
            this.types.FormattingEnabled = true;
            this.types.Location = new System.Drawing.Point(104, 55);
            this.types.Name = "types";
            this.types.Size = new System.Drawing.Size(239, 24);
            this.types.TabIndex = 18;
            // 
            // MasterFD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MasterFD";
            this.Text = "Master Food & Drinks";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.table1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView table1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button insert;
        private System.Windows.Forms.PictureBox picture1;
        private System.Windows.Forms.Button openFile;
        private System.Windows.Forms.OpenFileDialog filePicker;
        private System.Windows.Forms.ComboBox types;
    }
}