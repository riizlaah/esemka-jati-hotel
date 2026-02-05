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
    public partial class Reservation : Form
    {
        CustomerTable CustomerTable;
        AddCustomer addCustControl;
        EJHDBC DBC;
        public Reservation(EJHDBC dbc)
        {
            CustomerTable = new CustomerTable(dbc);
            addCustControl = new AddCustomer(dbc, this);
            InitializeComponent();
            changeCurrCustInfoMode(0);
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
    }
}
