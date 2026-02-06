namespace EsemkaJatiHotel.Views
{
    partial class Reservation
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
            this.search = new System.Windows.Forms.TextBox();
            this.searchMode = new System.Windows.Forms.RadioButton();
            this.addNew = new System.Windows.Forms.RadioButton();
            this.custInfoPanel = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkoutDate = new System.Windows.Forms.DateTimePicker();
            this.checkinDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.roomTypeSearch = new System.Windows.Forms.Button();
            this.roomTypes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.totalPriceLb = new System.Windows.Forms.Label();
            this.submit = new System.Windows.Forms.Button();
            this.availableRooms = new System.Windows.Forms.DataGridView();
            this.selectedRooms = new System.Windows.Forms.DataGridView();
            this.addSelected = new System.Windows.Forms.Button();
            this.rmSelected = new System.Windows.Forms.Button();
            this.staying = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedRooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staying)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.search);
            this.groupBox1.Controls.Add(this.searchMode);
            this.groupBox1.Controls.Add(this.addNew);
            this.groupBox1.Controls.Add(this.custInfoPanel);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 287);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer\'s Infromation";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(203, 25);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(211, 22);
            this.search.TabIndex = 3;
            this.search.TextChanged += new System.EventHandler(this.onTrySearch);
            // 
            // searchMode
            // 
            this.searchMode.AutoSize = true;
            this.searchMode.Checked = true;
            this.searchMode.Location = new System.Drawing.Point(114, 26);
            this.searchMode.Name = "searchMode";
            this.searchMode.Size = new System.Drawing.Size(71, 20);
            this.searchMode.TabIndex = 2;
            this.searchMode.TabStop = true;
            this.searchMode.Text = "Search";
            this.searchMode.UseVisualStyleBackColor = true;
            this.searchMode.Click += new System.EventHandler(this.onSearchMode);
            // 
            // addNew
            // 
            this.addNew.AutoSize = true;
            this.addNew.Location = new System.Drawing.Point(11, 26);
            this.addNew.Name = "addNew";
            this.addNew.Size = new System.Drawing.Size(83, 20);
            this.addNew.TabIndex = 1;
            this.addNew.TabStop = true;
            this.addNew.Text = "Add New";
            this.addNew.UseVisualStyleBackColor = true;
            this.addNew.Click += new System.EventHandler(this.onCreateNewCustMode);
            // 
            // custInfoPanel
            // 
            this.custInfoPanel.Location = new System.Drawing.Point(7, 60);
            this.custInfoPanel.Name = "custInfoPanel";
            this.custInfoPanel.Size = new System.Drawing.Size(407, 221);
            this.custInfoPanel.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.staying);
            this.groupBox2.Controls.Add(this.checkoutDate);
            this.groupBox2.Controls.Add(this.checkinDate);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(441, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 150);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reservation\'s Infromation";
            // 
            // checkoutDate
            // 
            this.checkoutDate.Location = new System.Drawing.Point(122, 109);
            this.checkoutDate.Name = "checkoutDate";
            this.checkoutDate.Size = new System.Drawing.Size(233, 22);
            this.checkoutDate.TabIndex = 4;
            this.checkoutDate.ValueChanged += new System.EventHandler(this.onCheckOutChanged);
            // 
            // checkinDate
            // 
            this.checkinDate.Location = new System.Drawing.Point(122, 38);
            this.checkinDate.Name = "checkinDate";
            this.checkinDate.Size = new System.Drawing.Size(233, 22);
            this.checkinDate.TabIndex = 3;
            this.checkinDate.ValueChanged += new System.EventHandler(this.onCheckInChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "CheckOut Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Staying";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "CheckIn Date";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.roomTypeSearch);
            this.groupBox3.Controls.Add(this.roomTypes);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Location = new System.Drawing.Point(441, 169);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(412, 131);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Room\'s Information";
            // 
            // roomTypeSearch
            // 
            this.roomTypeSearch.Location = new System.Drawing.Point(122, 63);
            this.roomTypeSearch.Name = "roomTypeSearch";
            this.roomTypeSearch.Size = new System.Drawing.Size(102, 34);
            this.roomTypeSearch.TabIndex = 2;
            this.roomTypeSearch.Text = "Search";
            this.roomTypeSearch.UseVisualStyleBackColor = true;
            this.roomTypeSearch.Click += new System.EventHandler(this.onRoomTypeSearch);
            // 
            // roomTypes
            // 
            this.roomTypes.FormattingEnabled = true;
            this.roomTypes.Location = new System.Drawing.Point(122, 33);
            this.roomTypes.Name = "roomTypes";
            this.roomTypes.Size = new System.Drawing.Size(233, 24);
            this.roomTypes.TabIndex = 1;
            this.roomTypes.SelectedValueChanged += new System.EventHandler(this.onRoomTypesChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "Room Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "List Available Rooms";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(585, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "List Selected Rooms";
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
            this.groupBox4.Location = new System.Drawing.Point(16, 479);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(580, 265);
            this.groupBox4.TabIndex = 5;
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
            this.addItem.Click += new System.EventHandler(this.onItemAdded);
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
            this.additionalItems.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.onAdditionalItemsCellContentClicked);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(66, 74);
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(176, 22);
            this.quantity.TabIndex = 7;
            this.quantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantity.ValueChanged += new System.EventHandler(this.onItemQtyChanged);
            // 
            // items
            // 
            this.items.FormattingEnabled = true;
            this.items.Location = new System.Drawing.Point(66, 34);
            this.items.Name = "items";
            this.items.Size = new System.Drawing.Size(176, 24);
            this.items.TabIndex = 6;
            this.items.SelectedValueChanged += new System.EventHandler(this.onReqItemChanged);
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
            // totalPriceLb
            // 
            this.totalPriceLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPriceLb.Location = new System.Drawing.Point(612, 489);
            this.totalPriceLb.Name = "totalPriceLb";
            this.totalPriceLb.Size = new System.Drawing.Size(241, 64);
            this.totalPriceLb.TabIndex = 6;
            this.totalPriceLb.Text = "Total Price:";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(616, 570);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(109, 41);
            this.submit.TabIndex = 7;
            this.submit.Text = "Submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.onSubmitReservation);
            // 
            // availableRooms
            // 
            this.availableRooms.AllowUserToAddRows = false;
            this.availableRooms.AllowUserToDeleteRows = false;
            this.availableRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.availableRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.availableRooms.Location = new System.Drawing.Point(13, 323);
            this.availableRooms.MultiSelect = false;
            this.availableRooms.Name = "availableRooms";
            this.availableRooms.ReadOnly = true;
            this.availableRooms.RowHeadersWidth = 51;
            this.availableRooms.RowTemplate.Height = 24;
            this.availableRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.availableRooms.Size = new System.Drawing.Size(377, 150);
            this.availableRooms.TabIndex = 8;
            // 
            // selectedRooms
            // 
            this.selectedRooms.AllowUserToAddRows = false;
            this.selectedRooms.AllowUserToDeleteRows = false;
            this.selectedRooms.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.selectedRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectedRooms.Location = new System.Drawing.Point(453, 323);
            this.selectedRooms.MultiSelect = false;
            this.selectedRooms.Name = "selectedRooms";
            this.selectedRooms.ReadOnly = true;
            this.selectedRooms.RowHeadersWidth = 51;
            this.selectedRooms.RowTemplate.Height = 24;
            this.selectedRooms.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.selectedRooms.Size = new System.Drawing.Size(397, 150);
            this.selectedRooms.TabIndex = 9;
            // 
            // addSelected
            // 
            this.addSelected.Location = new System.Drawing.Point(397, 364);
            this.addSelected.Name = "addSelected";
            this.addSelected.Size = new System.Drawing.Size(50, 35);
            this.addSelected.TabIndex = 10;
            this.addSelected.Text = ">>";
            this.addSelected.UseVisualStyleBackColor = true;
            this.addSelected.Click += new System.EventHandler(this.onSelectRoom);
            // 
            // rmSelected
            // 
            this.rmSelected.Location = new System.Drawing.Point(397, 405);
            this.rmSelected.Name = "rmSelected";
            this.rmSelected.Size = new System.Drawing.Size(50, 37);
            this.rmSelected.TabIndex = 11;
            this.rmSelected.Text = "<<";
            this.rmSelected.UseVisualStyleBackColor = true;
            this.rmSelected.Click += new System.EventHandler(this.onUnselectRoom);
            // 
            // staying
            // 
            this.staying.Location = new System.Drawing.Point(122, 75);
            this.staying.Name = "staying";
            this.staying.ReadOnly = true;
            this.staying.Size = new System.Drawing.Size(233, 22);
            this.staying.TabIndex = 8;
            this.staying.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 751);
            this.Controls.Add(this.rmSelected);
            this.Controls.Add(this.addSelected);
            this.Controls.Add(this.selectedRooms);
            this.Controls.Add(this.availableRooms);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.totalPriceLb);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Reservation";
            this.Text = "Reservation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.additionalItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.availableRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staying)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton searchMode;
        private System.Windows.Forms.RadioButton addNew;
        private System.Windows.Forms.Panel custInfoPanel;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label totalPriceLb;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.TextBox search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker checkoutDate;
        private System.Windows.Forms.DateTimePicker checkinDate;
        private System.Windows.Forms.ComboBox roomTypes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button roomTypeSearch;
        private System.Windows.Forms.ComboBox items;
        private System.Windows.Forms.TextBox itemPrice;
        private System.Windows.Forms.TextBox itemSubtotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView availableRooms;
        private System.Windows.Forms.DataGridView selectedRooms;
        private System.Windows.Forms.Button addSelected;
        private System.Windows.Forms.Button rmSelected;
        private System.Windows.Forms.Button addItem;
        private System.Windows.Forms.DataGridView additionalItems;
        private System.Windows.Forms.NumericUpDown quantity;
        private System.Windows.Forms.NumericUpDown staying;
    }
}