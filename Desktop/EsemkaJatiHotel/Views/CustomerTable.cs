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

namespace EsemkaJatiHotel.Views
{
    public partial class CustomerTable : UserControl
    {
        EJHDBC DBC;
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
            RefreshData();
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
        }
    }
}
