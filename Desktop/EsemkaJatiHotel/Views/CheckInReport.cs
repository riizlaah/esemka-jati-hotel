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
            checkInTodayText.Text = DateTime.Now.ToString("dd-MMM-yyyy");
            from.Value = DateTime.Now;
            to.Value = DateTime.Now;
        }

        private void onPreviewClicked(object sender, EventArgs e)
        {
            var crv = new CheckInReportViewer(DBC);
            crv.MdiParent = MdiParent;
            crv.Show();
            if(checkInToday.Checked)
            {
                crv.LoadCheckInReport(DateTime.Now, DateTime.Now);
            } else
            {
                crv.LoadCheckInReport(from.Value, to.Value);
            }
        }

        private void onFromDateChanged(object sender, EventArgs e)
        {
            if (from.Value > to.Value)
            {
                to.Value = from.Value.AddDays(1);
                return;
            }
            checkInFrom.Checked = true;
        }

        private void onToDateChanged(object sender, EventArgs e)
        {
            if(to.Value < from.Value)
            {
                from.Value = to.Value.AddDays(-1);
            }
            checkInFrom.Checked = true;
        }
    }
}
