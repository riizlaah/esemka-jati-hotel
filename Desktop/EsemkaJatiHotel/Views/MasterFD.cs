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
    public partial class MasterFD : Form
    {
        EJHDBC DBC;
        bool editing = false;
        string selectedFilePath = "";
        string assetsDir = Helper.GetAssetsDir("food_n_drinks");
        public MasterFD(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            filePicker.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            filePicker.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            Helper.GenerateTableColumn(table1,
                new string[] { "Name", "Type", "Price"},
                new string[] { "Name", "LongType", "Price" });
            types.Items.AddRange(new string[] { "Food", "Drinks" });
            RefreshData();
            updateFields(false, true);
            insert.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
        }

        private void RefreshData()
        {
            table1.DataSource = DBC.FoodAndDrinks.ToList();
        }

        private void updateFields(bool enabled = true, bool clear = false)
        {
            if (clear)
            {
                name.Text = "";
                types.SelectedIndex = -1;
                price.Text = "";
                picture1.Image = null;
                selectedFilePath = "";
            }
            name.Enabled = enabled;
            types.Enabled = enabled;
            price.Enabled = enabled;
            openFile.Enabled = enabled;
            insert.Enabled = !enabled;
            update.Enabled = !enabled && table1.SelectedRows.Count > 0;
            delete.Enabled = !enabled && table1.SelectedRows.Count > 0;
            save.Enabled = enabled;
            cancel.Enabled = enabled;
            table1.Enabled = !enabled;
        }

        private void onSave(object sender, EventArgs e)
        {
            if(name.Text.Trim() == "")
            {
                MessageBox.Show("Nama makanan/minuman tidak boleh kosong!");
                return;
            }
            if(types.SelectedIndex < 0)
            {
                MessageBox.Show("Tipe tidak valid!");
                return;
            }
            if(int.TryParse(price.Text.Trim(), out int priceVal) == false || priceVal < 0)
            {
                MessageBox.Show("Harga tidak valid!");
                return;
            }
            if(!editing && selectedFilePath == "")
            {
                MessageBox.Show("Foto harus dipilih!");
                return;
            }
            if(editing)
            {
                var selected = table1.SelectedRows[0].DataBoundItem as FoodAndDrinks;
                var dbFilePath = assetsDir + "\\" + selected.Photo;
                DBC.FoodAndDrinks.Attach(selected);
                selected.Name = name.Text.Trim();
                selected.Type = types.SelectedIndex == 0 ? 'F' : 'D';
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
                var newFoodAndDrinks = new FoodAndDrinks()
                {
                    Name = name.Text.Trim(),
                    Type = types.SelectedIndex == 0 ? 'F' : 'D',
                    Price = priceVal,
                    Photo = fileName
                };
                DBC.FoodAndDrinks.Add(newFoodAndDrinks);
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
            var selected = table1.SelectedRows[0].DataBoundItem as FoodAndDrinks;
            picture1.Image.Dispose();
            DBC.FoodAndDrinks.Attach(selected);
            DBC.FoodAndDrinks.Remove(selected);
            DBC.SaveChanges();
            RefreshData();
            updateFields(false, true);
            File.Delete(assetsDir + "\\" + selected.Photo);
        }

        private void onTableCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selected = table1.Rows[e.RowIndex].DataBoundItem as FoodAndDrinks;
            name.Text = selected.Name;
            types.SelectedIndex = selected.Type == 'F' ? 0 : 1;
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
