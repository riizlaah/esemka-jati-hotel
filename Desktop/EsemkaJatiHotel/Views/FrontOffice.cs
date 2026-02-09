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
    public partial class FrontOffice : Form
    {
        Login login;
        EJHDBC DBC;
        bool _logout = false;
        Timer timer = new Timer();
        public FrontOffice(EJHDBC dbc, Login loginForm)
        {
            DBC = dbc;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            IsMdiContainer = true;
            InitializeComponent();
            timer.Start();
            login = loginForm;
            Timer_Tick(this, EventArgs.Empty);
            logoutItem.Click += logout_Click;
            exitItem.Click += exit_Click;
            reservationItem.Click += onReservationClicked;
            checkInItem.Click += onCheckIn;
            reqAddItem.Click += onResvReqItems;
            checkOutItem.Click += onCheckOut;
        }
        private void onReservationClicked(object sender, EventArgs e)
        {
            var rf = new Reservation(DBC);
            rf.MdiParent = this;
            rf.Show();
        }
        private void onCheckIn(object sender, EventArgs e)
        {
            var ci = new CheckIn(DBC);
            ci.MdiParent = this;
            ci.Show();
        }
        private void onCheckOut(object sender, EventArgs e)
        {
            var co = new CheckOut(DBC);
            co.MdiParent = this;
            co.Show();
        }

        private void onResvReqItems(object sender, EventArgs e)
        {
            var rai = new ReqAdditionalItem(DBC);
            rai.MdiParent = this;
            rai.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeLb.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
        }
        private void logout_Click(object sender, EventArgs e)
        {
            _logout = true;
            login.Show();
            Close();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        protected override void OnClosed(EventArgs e)
        {
            if(!_logout)
            {
                Application.Exit();
            }
            base.OnClosed(e);
        }
    }
}
