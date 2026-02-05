using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaJatiHotel.Views
{
    public partial class MasterRoom : Form
    {
        EJHDBC DBC;
        bool editing = false;
        public MasterRoom(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            Helper.GenerateTableColumn(table1,
                new string[] { "Room Number", "Room Type", "Room Floor", "Description"},
                new string[] { "RoomNumber", "RoomType", "RoomFloor", "Description" });
            roomTypes.DataSource = DBC.RoomTypes.ToList();
            roomTypes.DisplayMember = "Name"; roomTypes.ValueMember = "Id";
            RefreshData();
            updateFields(false, true);
            insert.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
        }

        private void RefreshData()
        {
            table1.DataSource = DBC.Rooms.Include("RoomType").ToList();
        }

        private void updateFields(bool enabled = true, bool clear = false)
        {
            if (clear)
            {
                roomNumber.Text = "";
                roomTypes.SelectedIndex = -1;
                roomFloor.Text = "";
                description.Text = "";
            }
            roomNumber.Enabled = enabled;
            roomTypes.Enabled = enabled;
            roomFloor.Enabled = enabled;
            description.Enabled = enabled;
            insert.Enabled = !enabled;
            update.Enabled = !enabled;
            delete.Enabled = !enabled;
            save.Enabled = enabled;
            cancel.Enabled = enabled;
            table1.Enabled = !enabled;
        }

        private void onSave(object sender, EventArgs e)
        {
            if(roomNumber.Text.Trim() == "")
            {
                MessageBox.Show("No. Ruangan tidak boleh kosong!");
                return;
            }
            if(roomTypes.SelectedItem == null)
            {
                MessageBox.Show("Tipe kamar tidak boleh kosong!");
                return;
            }
            if (roomFloor.Text.Trim() == "")
            {
                MessageBox.Show("No. Lantai tidak boleh kosong!");
                return;
            }
            if (description.Text.Trim() == "")
            {
                MessageBox.Show("Deskripsi tidak boleh kosong!");
                return;
            }
            if (editing)
            {
                var selected = table1.SelectedRows[0].DataBoundItem as Room;
                DBC.Rooms.Attach(selected);
                selected.RoomNumber = roomNumber.Text.Trim();
                selected.RoomFLoor = roomFloor.Text;
                selected.RoomTypeId = (int)roomTypes.SelectedValue;
                selected.Description = description.Text.Trim();
                DBC.Entry(selected).State = System.Data.Entity.EntityState.Modified;
            } else
            {
                var newRoom = new Room()
                {
                    RoomNumber = roomNumber.Text.Trim(),
                    RoomTypeId = (int)roomTypes.SelectedValue,
                    RoomFLoor = roomFloor.Text.Trim(),
                    Description = description.Text.Trim(),
                };
                DBC.Rooms.Add(newRoom);
            }
            DBC.SaveChanges();
            updateFields(false, true);
            RefreshData();
        }

        private void onCancel(object sender, EventArgs e)
        {
            updateFields(false, true);
        }

        private void onCreate(object sender, EventArgs e)
        {
            editing = false;
            updateFields(true, true);
        }

        private void onUpdate(object sender, EventArgs e)
        {
            editing = true;
            updateFields(true, false);
        }

        private void onDelete(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            var selected = table1.SelectedRows[0].DataBoundItem as Room;
            DBC.Rooms.Attach(selected);
            DBC.Rooms.Remove(selected);
            DBC.SaveChanges();
            RefreshData();
            updateFields(false, true);
        }

        private void onTableCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selected = table1.Rows[e.RowIndex].DataBoundItem as Room;
            roomNumber.Text = selected.RoomNumber;
            roomTypes.SelectedValue = selected.RoomTypeId;
            roomFloor.Text = selected.RoomFLoor;
            description.Text = selected.Description;
            insert.Enabled = true;
            update.Enabled = true;
            delete.Enabled = true;
        }
    }
}
