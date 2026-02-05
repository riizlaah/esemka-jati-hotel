using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaJatiHotel.Views
{
    public partial class AddCustomer : UserControl
    {
        EJHDBC DBC;
        Reservation reservationForm;
        public AddCustomer(EJHDBC dbc, Reservation reservation)
        {
            DBC = dbc;
            reservationForm = reservation;
            InitializeComponent();
        }

        private void onAdd(object sender, EventArgs e)
        {
            if (name.Text.Trim() == "")
            {
                MessageBox.Show("Nama tidak boleh kosong");
                return;
            }
            if (nik.Text.Trim() == "")
            {
                MessageBox.Show("NIK tidak boleh kosong");
                return;
            }
            if (!email.Text.Contains("@"))
            {
                MessageBox.Show("Email tidak valid");
                return;
            }
            if (gender.SelectedIndex == -1)
            {
                MessageBox.Show("Jenis kelamin harus dipilih");
                return;
            }
            if (!Regex.IsMatch(phoneNum.Text, @"^\+\d{8,16}$"))
            {
                MessageBox.Show("Nomor telepon tidak valid");
                return;
            }
            if (dateOfBirth.Value >= DateTime.Now)
            {
                MessageBox.Show("Tanggal lahir tidak valid");
                return;
            }
            var customer = new Models.Customer()
            {
                Name = name.Text.Trim(),
                NIK = nik.Text.Trim(),
                Email = email.Text.Trim(),
                Gender = gender.SelectedIndex == 0 ? "M" : "F",
                PhoneNumber = phoneNum.Text.Trim(),
                Age = DateTime.Now.Year - dateOfBirth.Value.Year
            };
            DBC.Customers.Add(customer);
            DBC.SaveChanges();
            reservationForm.changeCurrCustInfoMode(0);
        }
        public void ClearFields()
        {
            name.Text = "";
            nik.Text = "";
            email.Text = "";
            phoneNum.Text = "";
            gender.SelectedIndex = -1;
            dateOfBirth.Value = DateTime.Now;
        }
    }
}
