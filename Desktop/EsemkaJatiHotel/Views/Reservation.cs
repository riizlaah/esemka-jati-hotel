using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaJatiHotel.Views
{
    public partial class Reservation : Form
    {
        CustomerTable CustomerTable;
        AddCustomer addCustControl;
        EJHDBC DBC;
        BindingList<Room> SelectedRoomsData = new BindingList<Room>();
        BindingList<ReservationRequestItem> resvReqItems = new BindingList<ReservationRequestItem>();
        int totalPrice = 0;
        public Reservation(EJHDBC dbc)
        {
            DBC = dbc;
            CustomerTable = new CustomerTable(dbc);
            addCustControl = new AddCustomer(dbc, this);
            InitializeComponent();
            // tables definitons
            Helper.GenerateTableColumn(availableRooms,
                new string[] { "Room Number", "Room Floor", "Room Price", "Description" },
                new string[] { "RoomNumber", "RoomFloor", "RoomPrice", "Description" });
            Helper.GenerateTableColumn(selectedRooms,
                new string[] { "Room Number", "Room Floor", "Room Price", "Description" },
                new string[] { "RoomNumber", "RoomFloor", "RoomPrice", "Description" });
            Helper.GenerateTableColumn(additionalItems,
                new string[] { "Item", "Quantity", "Price", "Sub Total" },
                new string[] { "ItemName", "Qty", "ItemPrice", "TotalPrice" });
            var rmItemCol = new DataGridViewButtonColumn();
            rmItemCol.Name = "Remove";
            rmItemCol.HeaderText = "Options";
            rmItemCol.Text = "Remove";
            rmItemCol.UseColumnTextForButtonValue = true;
            additionalItems.Columns.Add(rmItemCol);
            selectedRooms.DataSource = SelectedRoomsData;
            changeCurrCustInfoMode(0);
            checkinDate.MinDate = DateTime.Now.Date;
            checkinDate.Value = DateTime.Now.Date;
            checkoutDate.Value = DateTime.Now.Date.AddDays(1);
            checkoutDate.MinDate = checkinDate.Value.AddDays(1);
            UpdateAvailableRooms(checkinDate.Value, checkoutDate.Value);
            roomTypes.DisplayMember = "Name"; roomTypes.ValueMember = "Id";
            roomTypes.DataSource = DBC.RoomTypes.ToList();
            items.DisplayMember = "Name"; items.ValueMember = "Id";
            items.DataSource = DBC.Items.ToList();
            additionalItems.DataSource = resvReqItems;
            RecalculateTotalPrice();
        }
        private void UpdateAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            var selectedRoomsNumbers = SelectedRoomsData.Select(r => r.RoomNumber).ToList();
            var query = DBC.Rooms.AsQueryable().Include("RoomType").Include("ReservationRooms").
                Where(r => !r.ReservationRooms.Any(r2 => r2.StartDateTime < checkOut && DbFunctions.AddDays(r2.StartDateTime, 1) > checkIn)).
                Where(r => !selectedRoomsNumbers.Any(s => s == r.RoomNumber));
            if(roomTypes.SelectedIndex > -1)
            {
                int selectedRoomTypeId = (int)roomTypes.SelectedValue;
                query = query.Where(r => r.RoomTypeId == selectedRoomTypeId);
            }
            availableRooms.DataSource = new BindingList<Room>(query.ToList());
            staying.Value = (int)(checkOut - checkIn).TotalDays;
        }
        private void RecalculateTotalPrice()
        {
            totalPrice = SelectedRoomsData.Sum(r => r.RoomPrice * (int)staying.Value) + resvReqItems.Sum(r => r.TotalPrice);
            totalPriceLb.Text = "Total Price: " + totalPrice.ToString("Rp#,##0;(Rp#,##0);Rp0");
        }
        public void changeCurrCustInfoMode(int index)
        {
            if(index == 0)
            {
                search.Show();
                searchMode.Checked = true;
                addCustControl.ClearFields();
                custInfoPanel.Controls.Clear();
                custInfoPanel.Controls.Add(CustomerTable);
                CustomerTable.RefreshData();
            } else
            {
                search.Hide();
                addNew.Checked = true;
                custInfoPanel.Controls.Clear();
                addCustControl.ClearFields();
                custInfoPanel.Controls.Add(addCustControl);
            }
        }

        private void onSearchMode(object sender, EventArgs e)
        {
            changeCurrCustInfoMode(0);
        }

        private void onCreateNewCustMode(object sender, EventArgs e)
        {
            changeCurrCustInfoMode(1);
        }

        private void onTrySearch(object sender, EventArgs e)
        {
            CustomerTable.RefreshData(search.Text);
        }

        private void onRoomTypeSearch(object sender, EventArgs e)
        {
            UpdateAvailableRooms(checkinDate.Value, checkoutDate.Value);
        }

        private void onRoomTypesChanged(object sender, EventArgs e)
        {
            UpdateAvailableRooms(checkinDate.Value, checkoutDate.Value);
        }

        private void onSelectRoom(object sender, EventArgs e)
        {
            SelectedRoomsData.Add((Room)availableRooms.CurrentRow.DataBoundItem);
            availableRooms.Rows.RemoveAt(availableRooms.CurrentRow.Index);
            RecalculateTotalPrice();
        }

        private void onUnselectRoom(object sender, EventArgs e)
        {
            var availableDS = (BindingList<Room>)availableRooms.DataSource;
            availableDS.Add(SelectedRoomsData[selectedRooms.CurrentRow.Index]);
            SelectedRoomsData.Remove((Room)selectedRooms.CurrentRow.DataBoundItem);
            RecalculateTotalPrice();
        }

        private void onReqItemChanged(object sender, EventArgs e)
        {
            if (items.SelectedItem == null) return;
            var item = (Item)items.SelectedItem;
            itemPrice.Text = item.RequestPrice.ToString("Rp#,##0;(Rp#,##0);Rp0");
            itemSubtotal.Text = (item.RequestPrice * (int)quantity.Value).ToString("Rp#,##0;(Rp#,##0);Rp0");
        }

        private void onItemQtyChanged(object sender, EventArgs e)
        {
            if (items.SelectedItem == null) return;
            var item = (Item)items.SelectedItem;
            itemSubtotal.Text = (item.RequestPrice * (int)quantity.Value).ToString("Rp#,##0;(Rp#,##0);Rp0");
        }

        private void onItemAdded(object sender, EventArgs e)
        {
            if(items.SelectedIndex < 0) {
                MessageBox.Show("Item harus dipilih!");
                return;
            }
            if(quantity.Value <= 0)
            {
                MessageBox.Show("Kuantitas harus lebih dari 0!");
                return;
            }
            if (resvReqItems.Any(r => r.ItemId == (int)items.SelectedValue))
            {
                var item = resvReqItems.Where(r => r.ItemId == (int)items.SelectedValue).First();
                item.Qty += (int)quantity.Value;
                item.RecalculateTotalPrice();
                additionalItems.Refresh();
            } else
            {
                resvReqItems.Add(new ReservationRequestItem()
                {
                    ItemId = (int)items.SelectedValue,
                    Item = (Item)items.SelectedItem,
                    Qty = (int)quantity.Value,
                    TotalPrice = ((Item)items.SelectedItem).RequestPrice * (int)quantity.Value
                });
            }
            quantity.Value = 1;
            RecalculateTotalPrice();
        }

        private void onAdditionalItemsCellContentClicked(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == additionalItems.Columns["Remove"].Index && e.RowIndex >= 0)
            {
                resvReqItems.RemoveAt(e.RowIndex);
                RecalculateTotalPrice();
            }
        }

        private void onSubmitReservation(object sender, EventArgs e)
        {
            if (SelectedRoomsData.Count == 0)
            {
                MessageBox.Show("Kamar belum dipilih!");
                return;
            }
            if(CustomerTable.selectedEmail == "")
            {
                MessageBox.Show("Pelanggan belum dipilih!");
                return;
            }
            var cust = CustomerTable.GetCustomer();
            var bookingCode = Helper.GenerateRandomStringV2(6);
            var reservation = new Models.Reservation
            {
                BookingCode = bookingCode,
                CustomerId = cust.Id,
                DateTime = DateTime.Now,
                EmployeeId = DBC.currEmployee.Id,
            };
            DBC.Reservations.Add(reservation);
            DBC.SaveChanges();
            foreach(var room in SelectedRoomsData)
            {
                DBC.ReservationRooms.Add(new ReservationRoom
                {
                    ReservationId = reservation.Id,
                    RoomId = room.Id,
                    RoomPrice = room.RoomPrice * (int)staying.Value,
                    StartDateTime = checkinDate.Value.Date,
                    DurationNights = (int)staying.Value,
                });
            }
            foreach(var item in resvReqItems)
            {
                item.ReservationRoomId = reservation.Id;
                DBC.ReservationRequestItems.Add(item);
            }
            DBC.SaveChanges();
            MessageBox.Show("Success!", "Info");
            MessageBox.Show($"Booking Code: {bookingCode}", "Info");
            SelectedRoomsData.Clear();
            resvReqItems.Clear();
            CustomerTable.ClearSelection();
            checkinDate.Value = DateTime.Now;
            checkoutDate.Value = DateTime.Now.AddDays(1);
            staying.Value = 1;
            quantity.Value = 1;
            RecalculateTotalPrice();
        }

        private void onCheckInChanged(object sender, EventArgs e)
        {
            checkoutDate.MinDate = checkinDate.Value.AddDays(1);
            if(checkoutDate.Value < checkinDate.Value)
            {
                checkoutDate.Value = checkinDate.Value.AddDays(1);
                return;
            }
            UpdateAvailableRooms(checkinDate.Value, checkoutDate.Value);
        }

        private void onCheckOutChanged(object sender, EventArgs e)
        {
            UpdateAvailableRooms(checkinDate.Value, checkoutDate.Value);
        }
    }
}
