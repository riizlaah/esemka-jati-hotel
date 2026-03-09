namespace EsemkaJatiHotel.Views
{
    partial class CheckOut
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
            this.label1 = new System.Windows.Forms.Label();
            this.roomNumber = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.totalItemsPrice = new System.Windows.Forms.Label();
            this.itemStatus = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addItem = new System.Windows.Forms.Button();
            this.additionalItems = new System.Windows.Forms.DataGridView();
            this.quantity = new System.Windows.Forms.NumericUpDown();
            this.items = new System.Windows.Forms.ComboBox();
            this.compFee = new System.Windows.Forms.TextBox();
            this.itemSubtotal = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.fdTotalPrice = new System.Windows.Forms.Label();
            this.foodNDrinksTable = new System.Windows.Forms.DataGridView();
            this.totalPrice = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.foodNDrinksTable)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.roomNumber);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 70);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rooms Occupied";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Room Number";
            // 
            // roomNumber
            // 
            this.roomNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roomNumber.FormattingEnabled = true;
            this.roomNumber.Location = new System.Drawing.Point(123, 26);
            this.roomNumber.Name = "roomNumber";
            this.roomNumber.Size = new System.Drawing.Size(234, 24);
            this.roomNumber.TabIndex = 0;
            this.roomNumber.SelectedValueChanged += new System.EventHandler(this.onRoomNumberChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.totalItemsPrice);
            this.groupBox4.Controls.Add(this.itemStatus);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.addItem);
            this.groupBox4.Controls.Add(this.additionalItems);
            this.groupBox4.Controls.Add(this.quantity);
            this.groupBox4.Controls.Add(this.items);
            this.groupBox4.Controls.Add(this.compFee);
            this.groupBox4.Controls.Add(this.itemSubtotal);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(13, 89);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(620, 334);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Item Detail";
            // 
            // totalItemsPrice
            // 
            this.totalItemsPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalItemsPrice.Location = new System.Drawing.Point(343, 306);
            this.totalItemsPrice.Name = "totalItemsPrice";
            this.totalItemsPrice.Size = new System.Drawing.Size(266, 16);
            this.totalItemsPrice.TabIndex = 15;
            this.totalItemsPrice.Text = "Total Price: Rp0";
            // 
            // itemStatus
            // 
            this.itemStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.itemStatus.FormattingEnabled = true;
            this.itemStatus.Location = new System.Drawing.Point(340, 72);
            this.itemStatus.Name = "itemStatus";
            this.itemStatus.Size = new System.Drawing.Size(248, 24);
            this.itemStatus.TabIndex = 14;
            this.itemStatus.SelectedIndexChanged += new System.EventHandler(this.onItemStatusChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Item Status";
            // 
            // addItem
            // 
            this.addItem.Location = new System.Drawing.Point(480, 105);
            this.addItem.Name = "addItem";
            this.addItem.Size = new System.Drawing.Size(108, 33);
            this.addItem.TabIndex = 12;
            this.addItem.Text = "Add";
            this.addItem.UseVisualStyleBackColor = true;
            this.addItem.Click += new System.EventHandler(this.onItemAdded);
            // 
            // additionalItems
            // 
            this.additionalItems.AllowUserToAddRows = false;
            this.additionalItems.AllowUserToDeleteRows = false;
            this.additionalItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.additionalItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.additionalItems.Location = new System.Drawing.Point(6, 155);
            this.additionalItems.MultiSelect = false;
            this.additionalItems.Name = "additionalItems";
            this.additionalItems.RowHeadersWidth = 51;
            this.additionalItems.RowTemplate.Height = 24;
            this.additionalItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.additionalItems.Size = new System.Drawing.Size(603, 136);
            this.additionalItems.TabIndex = 8;
            this.additionalItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onAdditionaltemsCellContentClicked);
            this.additionalItems.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.onAdditionalItemRemoved);
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
            this.items.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.items.FormattingEnabled = true;
            this.items.Location = new System.Drawing.Point(66, 34);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(176, 24);
            this.items.TabIndex = 6;
            this.items.SelectedValueChanged += new System.EventHandler(this.onItemChanged);
            // 
            // compFee
            // 
            this.compFee.Location = new System.Drawing.Point(134, 116);
            this.compFee.Name = "compFee";
            this.compFee.ReadOnly = true;
            this.compFee.Size = new System.Drawing.Size(206, 22);
            this.compFee.TabIndex = 5;
            // 
            // itemSubtotal
            // 
            this.itemSubtotal.Location = new System.Drawing.Point(340, 34);
            this.itemSubtotal.Name = "itemSubtotal";
            this.itemSubtotal.ReadOnly = true;
            this.itemSubtotal.Size = new System.Drawing.Size(248, 22);
            this.itemSubtotal.TabIndex = 4;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(254, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 3;
            this.label11.Text = "Subtotal";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 16);
            this.label10.TabIndex = 2;
            this.label10.Text = "Compensation Fee";
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.fdTotalPrice);
            this.groupBox2.Controls.Add(this.foodNDrinksTable);
            this.groupBox2.Location = new System.Drawing.Point(13, 430);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(620, 203);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Food and Drinks Detail";
            // 
            // fdTotalPrice
            // 
            this.fdTotalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdTotalPrice.Location = new System.Drawing.Point(340, 176);
            this.fdTotalPrice.Name = "fdTotalPrice";
            this.fdTotalPrice.Size = new System.Drawing.Size(274, 16);
            this.fdTotalPrice.TabIndex = 16;
            this.fdTotalPrice.Text = "Total Price: Rp0";
            // 
            // foodNDrinksTable
            // 
            this.foodNDrinksTable.AllowUserToAddRows = false;
            this.foodNDrinksTable.AllowUserToDeleteRows = false;
            this.foodNDrinksTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.foodNDrinksTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.foodNDrinksTable.Location = new System.Drawing.Point(9, 27);
            this.foodNDrinksTable.MultiSelect = false;
            this.foodNDrinksTable.Name = "foodNDrinksTable";
            this.foodNDrinksTable.RowHeadersWidth = 51;
            this.foodNDrinksTable.RowTemplate.Height = 24;
            this.foodNDrinksTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.foodNDrinksTable.Size = new System.Drawing.Size(603, 136);
            this.foodNDrinksTable.TabIndex = 9;
            this.foodNDrinksTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onFDCellContentClicked);
            // 
            // totalPrice
            // 
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.Location = new System.Drawing.Point(310, 647);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(323, 28);
            this.totalPrice.TabIndex = 17;
            this.totalPrice.Text = "Total Price: Rp0";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 640);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 35);
            this.button1.TabIndex = 18;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.onSubmit);
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 684);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.totalPrice);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckOut";
            this.Text = "CheckOut";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.foodNDrinksTable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox roomNumber;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox itemStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.DataGridView additionalItems;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.ComboBox items;
        private System.Windows.Forms.TextBox compFee;
        private System.Windows.Forms.TextBox itemSubtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label totalItemsPrice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label fdTotalPrice;
        private System.Windows.Forms.DataGridView foodNDrinksTable;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.Button button1;
    }
}