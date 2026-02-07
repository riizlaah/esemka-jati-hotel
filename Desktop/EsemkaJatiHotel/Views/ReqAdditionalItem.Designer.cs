namespace EsemkaJatiHotel.Views
{
    partial class ReqAdditionalItem
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
            this.roomNumbers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.addItem = new System.Windows.Forms.Button();
            this.additionalItems = new System.Windows.Forms.DataGridView();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.items = new System.Windows.Forms.ComboBox();
            this.itemPrice = new System.Windows.Forms.TextBox();
            this.itemSubtotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.totalPrice = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roomNumbers);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rooms Occupied or Under Reservation";
            // 
            // roomNumbers
            // 
            this.roomNumbers.FormattingEnabled = true;
            this.roomNumbers.Location = new System.Drawing.Point(112, 30);
            this.roomNumbers.Name = "roomNumbers";
            this.roomNumbers.Size = new System.Drawing.Size(208, 24);
            this.roomNumbers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Room Number";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.addItem);
            this.groupBox4.Controls.Add(this.additionalItems);
            this.groupBox4.Controls.Add(this.quantity);
            this.groupBox4.Controls.Add(this.items);
            this.groupBox4.Controls.Add(this.itemPrice);
            this.groupBox4.Controls.Add(this.itemSubtotal);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(13, 90);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(580, 265);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Request Additional Items";
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(506, 37);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(68, 59);
            this.addItem.TabIndex = 12;
            this.addItem.Text = "Add";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.onAddReqItemClicked);
            // 
            // additionalItems
            // 
            this.additionalItems.AllowUserToAddRows = false;
            this.additionalItems.AllowUserToDeleteRows = false;
            this.additionalItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.additionalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.additionalItems.Location = new System.Drawing.Point(11, 119);
            this.additionalItems.MultiSelect = false;
            this.additionalItems.Name = "additionalItems";
            this.additionalItems.RowHeadersWidth = 51;
            this.additionalItems.RowTemplate.Height = 24;
            this.additionalItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.additionalItems.Size = new System.Drawing.Size(563, 136);
            this.additionalItems.TabIndex = 8;
            this.additionalItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onReqItemCellContenClicked);
            this.additionalItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.onReqItemRemoved);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(66, 74);
            this.quantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(176, 22);
            this.quantity.TabIndex = 7;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.onQtyChanged);
            // 
            // items
            // 
            this.items.FormattingEnabled = true;
            this.items.Location = new System.Drawing.Point(66, 34);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(176, 24);
            this.items.TabIndex = 6;
            this.items.SelectedValueChanged += new System.EventHandler(this.onItemChanged);
            // 
            // itemPrice
            // 
            this.itemPrice.Location = new System.Drawing.Point(313, 37);
            this.itemPrice.Name = "itemPrice";
            this.itemPrice.ReadOnly = true;
            this.itemPrice.Size = new System.Drawing.Size(187, 22);
            this.itemPrice.TabIndex = 5;
            // 
            // itemSubtotal
            // 
            this.itemSubtotal.Location = new System.Drawing.Point(313, 74);
            this.itemSubtotal.Name = "itemSubtotal";
            this.itemSubtotal.ReadOnly = true;
            this.itemSubtotal.Size = new System.Drawing.Size(187, 22);
            this.itemSubtotal.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(254, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Subtotal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(254, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Price";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 77);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "Quantity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "Item";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(186, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onResvReqItemsSubmitted);
            // 
            // totalPrice
            // 
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(372, 52);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(219, 39);
            this.totalPrice.TabIndex = 8;
            this.totalPrice.Text = "Total Price: Rp0";
            // 
            // ReqAdditionalItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 362);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "ReqAdditionalItem";
            this.Text = "ReqAdditionalItem";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roomNumbers;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.DataGridView additionalItems;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.ComboBox items;
        private System.Windows.Forms.TextBox itemPrice;
        private System.Windows.Forms.TextBox itemSubtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label totalPrice;
    }
}