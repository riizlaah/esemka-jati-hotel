using EsemkaJatiHotel.Models;
using EsemkaJatiHotel.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
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
            Debug.WriteLine("App Data Dir: " + Helper.GetAssetsDir());
        }

        private void onTryLogin(object sender, EventArgs e)
        {
            if(username.Text.Trim() == "")
            {
                MessageBox.Show("Username tidak boleh kosong!");
                return;
            }
            if(password.Text.Trim() == "")
            {
                MessageBox.Show("Password tidak boleh kosong!");
                return;
            }
            var user = DBC.Employees.Include("Job").Where(emp => emp.Username == username.Text.Trim()).FirstOrDefault();
            if(user == null)
            {
                MessageBox.Show("Username tidak ditemukan!");
                return;
            }
            if(!isHashSame(password.Text.Trim(), user.Password))
            {
                MessageBox.Show("Kredensial salah!");
                return;
            }
            DBC.currEmployee = user;
            Hide();
            username.Text = "";
            password.Text = "";
            if (user.Job.Name == "Admin")
            {
                var adminForm = new Admin(DBC, this);
                adminForm.Show();
            } else
            {
                var frontOffice = new FrontOffice(DBC, this);
                frontOffice.Show();
            }
        }
        public static string hashSHA256(string text)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(text));
                return Convert.ToBase64String(bytes);
            }
        }
        public static bool isHashSame(string text, string hash)
        {
            var hashedText = hashSHA256(text);
            return hashedText == hash;
        }
    }
}
