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

namespace EsemkaJatiHotel
{
    public partial class Login : Form
    {
        EJHDBC DBC;
        public Login()
        {
            DBC = new EJHDBC();
            InitializeComponent();
            DBC.Jobs.Add(new Job { Name = "Admin" });
            DBC.Jobs.Add(new Job { Name = "Front Office" });
            DBC.SaveChanges();
        }

        private void onTryLogin(object sender, EventArgs e)
        {
            
        }
    }
}
