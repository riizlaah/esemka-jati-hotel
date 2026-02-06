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
using EsemkaJatiHotel.Models;

namespace EsemkaJatiHotel.Views
{
    public partial class CheckIn : Form
    {
        EJHDBC DBC;
        Timer timer;
        public CheckIn(EJHDBC dbc)
        {
            DBC = dbc;
            timer = Helper.CreateTimer(250);
            InitializeComponent();
            Helper.GenerateTableColumn(rooms,
                new string[] {"Room Number", "Room Floor", "Room Type", "Start Date"},
                new string[] {"RoomNumber", "RoomFloor", "RoomType", "StartDateTime"}
                );
            timer.Tick += TrySearchCustomer;
            RefreshRooms();
        }

        private void RefreshRooms(string bookingCodeStr = "")
        {
            var query = DBC.ReservationRooms.Include("Room").Include("Reservation.Customer")
                .Where(r => r.CheckInDateTime == null).AsQueryable();
            if (bookingCodeStr != "")
            {
                query = query.Where(r => r.Reservation.BookingCode == bookingCodeStr);
            }
            var data = query.ToList();
            if(data.Count == 0 && bookingCodeStr != "")
            {
                MessageBox.Show("Reservasi dengan Booking Code tersebut tidak ada!");
                return;
            }
            rooms.DataSource = data;
        }

        private void onCheckInClicked(object sender, EventArgs e)
        {
            if(!Regex.IsMatch(phoneNum.Text, @"^\+\d{8,20}$"))
            {
                MessageBox.Show("Nomor HP tidak valid!");
                return;
            }
            if(name.Text.Trim() == "")
            {
                MessageBox.Show("Nama belum diisi!");
                return;
            }
            if (email.Text.Trim() == "")
            {
                MessageBox.Show("Email belum diisi!");
                return;
            }
            if (!int.TryParse(age.Text, out int ageVal))
            {
                MessageBox.Show("Umur tidak valid!");
                return;
            }
            if (!nik.Text.All(Char.IsDigit))
            {
                MessageBox.Show("NIK tidak valid!");
                return;
            }
            if(rooms.CurrentRow == null)
            {
                MessageBox.Show("Belum ada kamar yang dipilih!");
                return;
            }
            var rroom = DBC.ReservationRooms.Find((rooms.CurrentRow.DataBoundItem as ReservationRoom).Id);
            if(name.Enabled)
            {
                var cust = new Customer
                {
                    Name = name.Text,
                    Email = email.Text,
                    PhoneNumber = phoneNum.Text,
                    Age = ageVal,
                    NIK = nik.Text,
                    Gender = male.Checked ? "M" : "F"
                };
                DBC.Customers.Add(cust);
                DBC.SaveChanges();
                rroom.Reservation.CustomerId = cust.Id;
            }
            rroom.CheckInDateTime = DateTime.Now;
            DBC.SaveChanges();
            phoneNum.Text = "";
            bookingCode.Text = "";
            RefreshRooms();
        }

        private void onCloseClicked(object sender, EventArgs e)
        {
            Close();
        }

        private void onTrySearch(object sender, EventArgs e)
        {
            RefreshRooms(bookingCode.Text);
        }

        private void onPhoneNumChanged(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Start();
        }
        private void TrySearchCustomer(object sender, EventArgs e)
        {
            var customer = DBC.Customers.Where(c => c.PhoneNumber == phoneNum.Text).FirstOrDefault();
            if (customer == null)
            {
                name.Enabled = true; name.Text = "";
                email.Enabled = true; email.Text = "";
                age.Enabled = true; age.Text = "";
                nik.Enabled = true; nik.Text = "";
                male.Enabled = true; 
                female.Enabled = true;
            }
            else
            {
                name.Text = customer.Name;
                email.Text = customer.Email;
                age.Text = customer.Age.ToString();
                nik.Text = customer.NIK.ToString();
                if(customer.Gender == "M")
                {
                    male.Checked = true;
                }
                else
                {
                    female.Checked = true;
                }
                name.Enabled = false;
                email.Enabled = false;
                age.Enabled = false;
                nik.Enabled = false;
                male.Enabled = false;
                female.Enabled = false;
            }
        }

        private void onReservationRoomCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (rooms.CurrentRow.DataBoundItem != null)
            {
                var rroom = rooms.CurrentRow.DataBoundItem as ReservationRoom;
                bookingCode.Text = rroom.Reservation.BookingCode;
                var cust = rroom.Reservation.Customer;
                phoneNum.Text = cust.PhoneNumber;
                timer.Stop();
                name.Text = cust.Name;
                email.Text = cust.Email;
                age.Text = cust.Age.ToString();
                nik.Text = cust.NIK.ToString();
                if (cust.Gender == "M")
                {
                    male.Checked = true;
                } else
                {
                    female.Checked = true;
                }
                if (name.Enabled)
                {
                    name.Enabled = false;
                    email.Enabled = false;
                    age.Enabled = false;
                    nik.Enabled = false;
                    male.Enabled = false;
                    female.Enabled = false;
                }
            }
        }
    }
}
