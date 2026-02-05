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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaJatiHotel.Views
{
    public partial class MasterRoomType : Form
    {
        EJHDBC DBC;
        bool editing = false;
        string selectedFilePath = "";
        string assetsDir = Helper.GetAssetsDir("room_types");
        public MasterRoomType(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            filePicker.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            filePicker.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            Helper.GenerateTableColumn(table1,
                new string[] { "Nama", "Kapasitas", "Harga per Malam"},
                new string[] { "Name", "Capacity", "Price" });
            RefreshData();
            updateFields(false, true);
            insert.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
        }

        private void RefreshData()
        {
            table1.DataSource = DBC.RoomTypes.ToList();
        }

        private void updateFields(bool enabled = true, bool clear = false)
        {
            if (clear)
            {
                name.Text = "";
                capacity.Value = 1;
                price.Text = "";
                picture1.Image = null;
                selectedFilePath = "";
            }
            name.Enabled = enabled;
            capacity.Enabled = enabled;
            price.Enabled = enabled;
            openFile.Enabled = enabled;
            insert.Enabled = !enabled;
            update.Enabled = !enabled;
            delete.Enabled = !enabled;
            save.Enabled = enabled;
            cancel.Enabled = enabled;
            table1.Enabled = !enabled;
        }

        private void onSave(object sender, EventArgs e)
        {
            if(name.Text.Trim() == "")
            {
                MessageBox.Show("Nama tipe kamar tidak boleh kosong!");
                return;
            }
            if(capacity.Value < 1)
            {
                MessageBox.Show("Kapasitas kamar harus lebih dari 0!");
                return;
            }
            if(int.TryParse(price.Text.Trim(), out int priceVal) == false || priceVal < 0)
            {
                MessageBox.Show("Harga kamar tidak valid!");
                return;
            }
            if(!editing && selectedFilePath == "")
            {
                MessageBox.Show("Foto tipe kamar harus dipilih!");
                return;
            }
            if(editing)
            {
                var selected = table1.SelectedRows[0].DataBoundItem as RoomType;
                var dbFilePath = assetsDir + "\\" + selected.Photo;
                DBC.RoomTypes.Attach(selected);
                selected.Name = name.Text.Trim();
                selected.Capacity = (int)capacity.Value;
                selected.Price = priceVal;
                if(Path.GetFileName(selectedFilePath) != selected.Photo)
                {
                    var fileName = Path.GetFileNameWithoutExtension(selected.Photo);
                    var Extension = Path.GetExtension(selectedFilePath);
                    File.Copy(selectedFilePath, assetsDir + $"\\{fileName}.{Extension}", true);
                }
                DBC.Entry(selected).State = System.Data.Entity.EntityState.Modified;
            } else
            {
                var fileName = Helper.GenerateRandomString() + Path.GetExtension(selectedFilePath);
                File.Copy(selectedFilePath, assetsDir + "\\" + fileName, true);
                var newRoomType = new RoomType()
                {
                    Name = name.Text.Trim(),
                    Capacity = (int)capacity.Value,
                    Price = priceVal,
                    Photo = fileName
                };
                DBC.RoomTypes.Add(newRoomType);
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
            var selected = table1.SelectedRows[0].DataBoundItem as RoomType;
            picture1.Image.Dispose();
            DBC.RoomTypes.Attach(selected);
            DBC.RoomTypes.Remove(selected);
            DBC.SaveChanges();
            RefreshData();
            updateFields(false, true);
            File.Delete(assetsDir + "\\" + selected.Photo);
        }

        private void onTableCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selected = table1.Rows[e.RowIndex].DataBoundItem as RoomType;
            name.Text = selected.Name;
            capacity.Value = selected.Capacity;
            price.Text = selected.Price.ToString();
            selectedFilePath = assetsDir + "\\" + selected.Photo;
            if(picture1.Image != null)
            {
                picture1.Image.Dispose();
            }
            picture1.Image = Image.FromFile(selectedFilePath);
            insert.Enabled = true;
            update.Enabled = true;
            delete.Enabled = true;
        }

        private void onFilePickClicked(object sender, EventArgs e)
        {
            if(filePicker.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = filePicker.FileName;
                picture1.Image = Image.FromFile(selectedFilePath);
            }
            
        }
    }
}
