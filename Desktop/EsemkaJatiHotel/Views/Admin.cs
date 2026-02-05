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
    public partial class Admin : Form
    {
        EJHDBC DBC;
        Login login;
        bool _logout = false;
        Timer timer = new Timer();
        public Admin(EJHDBC dbc, Login loginForm)
        {
            DBC = dbc;
            login = loginForm;
            timer.Interval  = 1000;
            timer.Tick += Timer_Tick;
            IsMdiContainer = true;
            InitializeComponent();
            timer.Start();
            Timer_Tick(this, EventArgs.Empty);
            logoutMenuItem.Click += logout_Click;
            exitMenuItem.Click += exit_Click;
            roomTypeItem.Click += (s, e) =>
            {
                var mrt = new MasterRoomType(DBC);
                mrt.MdiParent = this;
                mrt.Show();
            };
            roomItem.Click += (s, e) =>
            {
                var mr = new MasterRoom(DBC);
                mr.MdiParent = this;
                mr.Show();
            };
            employeesItem.Click += EmployeeClicked;
            reqAddItem.Click += (s, e) =>
            {
                var masterItem = new MasterItem(DBC);
                masterItem.MdiParent = this;
                masterItem.Show();
            };
            FDItem.Click += (s, e) =>
            {
                var mfd = new MasterFD(DBC);
                mfd.MdiParent = this;
                mfd.Show();
            };
        }

        private void EmployeeClicked(object s, EventArgs e)
        {
            var me = new MasterEmployee(DBC);
            me.MdiParent = this;
            me.Show();
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
            if (!_logout)
            {
                Application.Exit();
            }
            base.OnClosed(e);
        }
    }
}
