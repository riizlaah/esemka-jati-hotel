using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EsemkaJatiHotel.Models;

namespace EsemkaJatiHotel.Views
{
    public partial class CheckOut : Form
    {
        EJHDBC DBC;
        BindingList<ReservationCheckOut> reservationRequestItems = new BindingList<ReservationCheckOut>();
        BindingList<FDCheckout> FDCheckouts = new BindingList<FDCheckout>();
        int FDCheckoutsFirstCount = 0;
        public CheckOut(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            roomNumber.DisplayMember = "RoomNumber"; roomNumber.ValueMember = "ReservationId";
            items.DisplayMember = "Name"; items.ValueMember = "Id";
            itemStatus.DisplayMember = "Name"; itemStatus.ValueMember = "Id";
            roomNumber.DataSource = DBC.ReservationRooms.Include("Room").Where(r => r.CheckOutDateTime == null && r.CheckInDateTime != null).ToList();
            items.DataSource = DBC.Items.ToList();
            itemStatus.DataSource = DBC.ItemStatuses.ToList();
            Helper.GenerateTableColumn(additionalItems,
                new string[] { "Item", "Quantity", "Compensation Fee", "Sub Total" },
                new string[] { "ItemName", "Qty", "CompensationFee", "TotalCharge" });
            var rmItemCol = new DataGridViewButtonColumn();
            rmItemCol.Name = "Remove";
            rmItemCol.HeaderText = "Options";
            rmItemCol.Text = "Remove";
            rmItemCol.UseColumnTextForButtonValue = true;
            additionalItems.Columns.Add(rmItemCol);
            additionalItems.DataSource = reservationRequestItems;
            Helper.GenerateTableColumn(foodNDrinksTable,
                new string[] { "Name", "Type", "Price", "Qty", "Sub Total" },
                new string[] { "FDName", "FDType", "FDPrice", "Qty", "TotalPrice" });
            var rmItemCol1 = new DataGridViewButtonColumn();
            rmItemCol1.Name = "Remove";
            rmItemCol1.HeaderText = "Options";
            rmItemCol1.Text = "Remove";
            rmItemCol1.UseColumnTextForButtonValue = true;
            foodNDrinksTable.Columns.Add(rmItemCol1);
            RefreshFD();
            RecalculateTotalPrice();
        }

        private void RefreshFD()
        {
            if (roomNumber.Items.Count == 0) return;
            var resvId = (roomNumber.SelectedItem as ReservationRoom).Id;
            FDCheckouts = new BindingList<FDCheckout>(DBC.FDCheckouts.Where(fd => fd.ReservationRoomId == resvId).ToList());
            FDCheckoutsFirstCount = FDCheckouts.Count;
            foodNDrinksTable.DataSource = FDCheckouts;
        } 

        private void onSubmit(object sender, EventArgs e)
        {
            if (roomNumber.SelectedItem == null)
            {
                MessageBox.Show("Kamar belum dipilih!");
                return;
            }
            foreach (var item in reservationRequestItems)
            {
                DBC.ReservationCheckOuts.Add(item);
            }
            var fdcheckouts2 = DBC.FDCheckouts.Where(fd => fd.ReservationRoomId == (int)roomNumber.SelectedValue).ToList();
            foreach(var fd in fdcheckouts2)
            {
                if(!FDCheckouts.Any(fd1 => fd1.Id == fd.Id))
                {
                    DBC.FDCheckouts.Attach(fd);
                    DBC.FDCheckouts.Remove(fd);
                }
            }
            var resvRoom = DBC.ReservationRooms.Find((roomNumber.SelectedItem as ReservationRoom).Id);
            resvRoom.CheckOutDateTime = DateTime.Now;
            DBC.SaveChanges();
            reservationRequestItems.Clear();
            FDCheckouts.Clear();
            roomNumber.DataSource = DBC.ReservationRooms.Include("Room").Where(r => r.CheckOutDateTime == null && r.CheckInDateTime != null).ToList();
        }

        private void onItemAdded(object sender, EventArgs e)
        {
            if(roomNumber.SelectedItem == null)
            {
                MessageBox.Show("Kamar belum dipilih!");
                return;
            }
            if(items.SelectedItem == null)
            {
                MessageBox.Show("Item belum dipilih!");
                return;
            }
            if(itemStatus.SelectedItem == null)
            {
                MessageBox.Show("Status item belum dipilih!");
                return;
            }
            if (reservationRequestItems.Any(r => r.ItemId == (int)items.SelectedValue))
            {
                var item = reservationRequestItems.Where(r => r.ItemId == (int)items.SelectedValue).First();
                item.Qty += (int)quantity.Value;
                item.RecalculateTotalPrice();
                additionalItems.Refresh();
            }
            else
            {
                var charge = (int)itemStatus.SelectedValue == 1 ? (items.SelectedItem as Item).RequestPrice : (items.SelectedItem as Item).CompensationFee;
                reservationRequestItems.Add(new ReservationCheckOut
                {
                    ItemId = (int)items.SelectedValue,
                    Item = (Item)items.SelectedItem,
                    ItemStatusId = (int)itemStatus.SelectedValue,
                    ItemStatus = (ItemStatus)itemStatus.SelectedItem,
                    ReservationRoomId = (int)roomNumber.SelectedValue,
                    Qty = (int)quantity.Value,
                    TotalCharge = (int)quantity.Value * charge,
                });
            }
            quantity.Value = 1;
            RecalculateItemPrice();
            RecalculateTotalPrice();
        }
        private void RecalculateItemPrice()
        {
            var item = items.SelectedItem as Item;
            if (item == null) return;
            if (itemStatus.SelectedItem == null) return;
            compFee.Text = item.CompensationFee.ToString("Rp#,##0;(Rp#,##0);Rp0");
            var charge = (int)itemStatus.SelectedValue == 1 ? item.RequestPrice : item.CompensationFee;
            itemSubtotal.Text = (((int)quantity.Value) * charge).ToString("Rp#,##0;(Rp#,##0);Rp0");
        }
        private void RecalculateTotalPrice()
        {
            int ItemsPrice = reservationRequestItems.Sum(r => r.TotalCharge);
            int FDPrice = FDCheckouts.Count == 0 ? 0 : FDCheckouts.Sum(fd => fd.TotalPrice);
            int Total = ItemsPrice + FDPrice;
            Debug.WriteLine(Total);
            totalItemsPrice.Text = "Total Price: " + ItemsPrice.ToString("Rp#,##0;(Rp#,##0);Rp0");
            fdTotalPrice.Text = "Total Price: " + FDPrice.ToString("Rp#,##0;(Rp#,##0);Rp0");
            totalPrice.Text = "Total Price: " + Total.ToString("Rp#,##0;(Rp#,##0);Rp0");
            Debug.WriteLine(totalPrice.Text);
        }

        private void onRoomNumberChanged(object sender, EventArgs e)
        {
            RefreshFD();
        }

        private void onQtyChanged(object sender, EventArgs e)
        {
            RecalculateItemPrice();
        }

        private void onItemChanged(object sender, EventArgs e)
        {
            RecalculateItemPrice();
        }

        private void onAdditionaltemsCellContentClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (additionalItems.Columns[e.ColumnIndex].Name == "Remove")
            {
                reservationRequestItems.RemoveAt(e.RowIndex);
                RecalculateTotalPrice();
            }
        }

        private void onAdditionalItemRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalculateTotalPrice();
        }

        private void onItemStatusChanged(object sender, EventArgs e)
        {
            RecalculateItemPrice();
        }
    }
}
