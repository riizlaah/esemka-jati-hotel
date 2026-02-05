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
    public partial class MasterItem : Form
    {
        EJHDBC DBC;
        bool editing = false;
        public MasterItem(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            Helper.GenerateTableColumn(table1,
                new string[] { "Name", "Request Price", "Compensation Fee"},
                new string[] { "Name", "RequestPrice", "CompensationFee"});
            RefreshData();
            updateFields(false, true);
            insert.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
        }

        private void RefreshData()
        {
            table1.DataSource = DBC.Items.ToList();
        }

        private void updateFields(bool enabled = true, bool clear = false)
        {
            if (clear)
            {
                name.Text = "";
                reqPrice.Text = "";
                compFee.Text = "";
            }
            name.Enabled = enabled;
            reqPrice.Enabled = enabled;
            compFee.Enabled = enabled;
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
                MessageBox.Show("Nama Item tidak boleh kosong!");
                return;
            }
            if (!int.TryParse(reqPrice.Text, out int reqVal))
            {
                MessageBox.Show("Request Price tidak valid!");
                return;
            }
            if (!int.TryParse(compFee.Text, out int compVal))
            {
                MessageBox.Show("Compensation Fee tidak valid!");
                return;
            }
            if (editing)
            {
                var selected = table1.SelectedRows[0].DataBoundItem as Item;
                DBC.Items.Attach(selected);
                selected.Name = name.Text.Trim();
                selected.RequestPrice = reqVal;
                selected.CompensationFee = compVal;
                DBC.Entry(selected).State = System.Data.Entity.EntityState.Modified;
            } else
            {
                var newItem = new Item()
                {
                    Name = name.Text.Trim(),
                    RequestPrice = reqVal,
                    CompensationFee = compVal
                };
                DBC.Items.Add(newItem);
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
            var selected = table1.SelectedRows[0].DataBoundItem as Item;
            DBC.Items.Attach(selected);
            DBC.Items.Remove(selected);
            DBC.SaveChanges();
            RefreshData();
            updateFields(false, true);
        }

        private void onTableCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selected = table1.Rows[e.RowIndex].DataBoundItem as Item;
            name.Text = selected.Name;
            reqPrice.Text = selected.RequestPrice.ToString();
            compFee.Text = selected.CompensationFee.ToString();
            insert.Enabled = true;
            update.Enabled = true;
            delete.Enabled = true;
        }
    }
}
