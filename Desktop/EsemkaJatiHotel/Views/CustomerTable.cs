using EsemkaJatiHotel.Models;
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

namespace EsemkaJatiHotel.Views
{
    public partial class CustomerTable : UserControl
    {
        EJHDBC DBC;
        public string selectedEmail { get; private set; } = "";
        public CustomerTable(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            var checkBoxColumn = new DataGridViewCheckBoxColumn();
            checkBoxColumn.HeaderText = "Choose";
            checkBoxColumn.TrueValue = true;
            checkBoxColumn.FalseValue = false;
            checkBoxColumn.ReadOnly = false;
            table0.Columns.Add(checkBoxColumn);
            Helper.GenerateTableColumn(table0,
                new string[] {"Name", "Email", "Gender" },
                new string[] {"Name", "Email", "LongGender" }
                );
            table0.CurrentCellDirtyStateChanged += (s, e) =>
            {
                // supaya checkbox langsung ke-commit saat di-klik, bukan saat pindah sel
                if (table0.CurrentCell is DataGridViewCheckBoxCell)
                {
                    table0.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            };
            table0.CellValueChanged += (s, e) =>
            {
                if (e.ColumnIndex == 0)
                {
                    var row = table0.CurrentRow;
                    var cust = row.DataBoundItem as Customer;
                    bool isChecked = Convert.ToBoolean(row.Cells[0].Value);
                    if (isChecked)
                    {
                        foreach(DataGridViewRow r in table0.Rows)
                        {
                            if (r.Index == e.RowIndex) continue;
                            r.Cells[0].Value = false;
                        }
                        //row.Cells[0].Value = true;
                        selectedEmail = cust.Email;
                    }
                    else
                    {
                        selectedEmail = "";
                    }
                    table0.Invalidate();
                }
            };
            RefreshData();
        }

        public void ClearSelection()
        {
            RefreshData();
            foreach (DataGridViewRow r in table0.Rows)
            {
                r.Cells[0].Value = false;
            }
            table0.ClearSelection();
            table0.Refresh();
        }

        public Customer GetCustomer()
        {
            return table0.CurrentRow.DataBoundItem as Customer;
        }
        public void RefreshData(string src = "")
        {
            if(src.Trim() == "")
            {
                table0.DataSource = DBC.Customers.ToList();
            }
            else
            {
                table0.DataSource = DBC.Customers
                    .Where(c => c.Name.Contains(src) || c.Email.Contains(src) || c.NIK.Contains(src) || c.PhoneNumber.Contains(src))
                    .ToList();
            }
            foreach(DataGridViewRow row in table0.Rows) {
                var cust = row.DataBoundItem as Customer;
                if (selectedEmail == cust.Email)
                {
                    row.Cells[0].Value = true;
                }
            };
        }
    }
}
