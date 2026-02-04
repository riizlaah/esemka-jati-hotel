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
            InitializeComponent();
            timer.Start();
            login = loginForm;
            Timer_Tick(this, EventArgs.Empty);
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
