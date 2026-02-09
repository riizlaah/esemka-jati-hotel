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
    public partial class CheckInReport : Form
    {
        EJHDBC DBC;
        public CheckInReport(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
        }

        private void onPreviewClicked(object sender, EventArgs e)
        {

        }
    }
}
