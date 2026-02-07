using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EsemkaJatiHotel.Models;

namespace EsemkaJatiHotel.Views
{
    public partial class ReqAdditionalItem : Form
    {

        EJHDBC DBC;
        BindingList<ReservationRequestItem> resvReqItems = new BindingList<ReservationRequestItem>();

        public ReqAdditionalItem(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            Helper.GenerateTableColumn(additionalItems,
                new string[] { "Item", "Quantity", "Price", "Sub Total" },
                new string[] { "ItemName", "Qty", "ItemPrice", "TotalPrice" });
            var rmItemCol = new DataGridViewButtonColumn();
            rmItemCol.Name = "Remove";
            rmItemCol.HeaderText = "Options";
            rmItemCol.Text = "Remove";
            additionalItems.Columns.Add(rmItemCol);
            roomNumbers.DisplayMember = "RoomNumber"; roomNumbers.ValueMember = "ReservationId";
            roomNumbers.DataSource = DBC.ReservationRooms.Include("Room").Where(r => r.CheckOutDateTime == null).ToList();
            items.DisplayMember = "Name"; items.ValueMember = "Id";
            items.DataSource = DBC.Items.ToList();
            additionalItems.DataSource = resvReqItems;
        }

        private void onAddReqItemClicked(object sender, EventArgs e)
        {
            if(items.SelectedItem == null)
            {
                MessageBox.Show("Item belum di pilih!");
                return;
            }
            if (quantity.Value <= 0)
            {
                MessageBox.Show("Kuantitas tidak valid!");
                return;
            }
            if(resvReqItems.Any(r => r.ItemId == (int)items.SelectedValue))
            {
                var item = resvReqItems.Where(r => r.ItemId == (int)items.SelectedValue).First();
                item.Qty += (int)quantity.Value;
                item.RecalculateTotalPrice();
                additionalItems.Refresh();
            }
            else
            {
                resvReqItems.Add(new ReservationRequestItem
                {
                    ItemId = (int)items.SelectedValue,
                    Item = (Item)items.SelectedItem,
                    ReservationRoomId = (int)roomNumbers.SelectedValue,
                    Qty = (int)quantity.Value,
                    TotalPrice = (int)quantity.Value * (items.SelectedItem as Item).RequestPrice,
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
            itemPrice.Text = item.RequestPrice.ToString("Rp#,##0;(Rp#,##0);Rp0");
            itemSubtotal.Text = (((int)quantity.Value) * item.RequestPrice).ToString("Rp#,##0;(Rp#,##0);Rp0");
        }

        private void onQtyChanged(object sender, EventArgs e)
        {
            RecalculateItemPrice();
        }

        private void onItemChanged(object sender, EventArgs e)
        {
            RecalculateItemPrice();
        }

        private void onResvReqItemsSubmitted(object sender, EventArgs e)
        {
            if (resvReqItems.Count == 0)
            {
                MessageBox.Show("Tidak ada item tambahan di dalam tabel!");
                return;
            }
            foreach (var item in resvReqItems)
            {
                DBC.ReservationRequestItems.Add(item);
            }
            DBC.SaveChanges();
            resvReqItems.Clear();
            RecalculateTotalPrice();
        }

        private void RecalculateTotalPrice()
        {
            totalPrice.Text = "Total Price: " + resvReqItems.Sum(r => r.ItemPrice * r.Qty).ToString("Rp#,##0;(Rp#,##0);Rp0");
        }

        private void onReqItemRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            RecalculateTotalPrice();
        }

        private void onReqItemCellContenClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (additionalItems.Columns[e.ColumnIndex].Name == "Remove")
            {
                resvReqItems.RemoveAt(e.RowIndex);
                RecalculateTotalPrice();
            }
        }
    }
}
