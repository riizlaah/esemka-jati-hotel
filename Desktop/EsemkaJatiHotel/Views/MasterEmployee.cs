using EsemkaJatiHotel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaJatiHotel.Views
{
    public partial class MasterEmployee : Form
    {
        EJHDBC DBC;
        bool editing = false;
        string selectedFilePath = "";
        string assetsDir = Helper.GetAssetsDir("users");
        public MasterEmployee(EJHDBC dbc)
        {
            DBC = dbc;
            InitializeComponent();
            filePicker.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            filePicker.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            Helper.GenerateTableColumn(table1,
                new string[] { "Username", "Name", "Email", "Address", "Date of Birth", "Job"},
                new string[] { "Username", "Name", "Email", "Address", "DateOfBirth", "Job" });
            jobs.DisplayMember = "Name"; jobs.ValueMember = "Id";
            jobs.DataSource = DBC.Jobs.ToList();
            RefreshData();
            updateFields(false, true);
            insert.Enabled = true;
            update.Enabled = false;
            delete.Enabled = false;
        }

        private void RefreshData()
        {
            table1.DataSource = DBC.Employees.ToList();
        }

        private void updateFields(bool enabled = true, bool clear = false)
        {
            if (clear)
            {
                username.Text = "";
                password.Text = "";
                confirmPassword.Text = "";
                name.Text = "";
                email.Text = "";
                address.Text = "";
                dateOfBirth.Value = DateTime.Now;
                jobs.SelectedIndex = -1;
                picture1.Image = null;
            }
            username.Enabled = enabled;
            password.Enabled = enabled;
            confirmPassword.Enabled = enabled;
            name.Enabled = enabled;
            email.Enabled = enabled;
            address.Enabled = enabled;
            dateOfBirth.Enabled = enabled;
            jobs.Enabled = enabled;
            openFile.Enabled = enabled;
            insert.Enabled = !enabled;
            update.Enabled = !enabled;
            delete.Enabled = !enabled;
            save.Enabled = enabled;
            cancel.Enabled = enabled;
            table1.Enabled = !enabled;
        }

        private void onSave(object sender, EventArgs e)
        {
            if(username.Text.Trim() == "")
            {
                MessageBox.Show("Username tidak boleh kosong!");
                return;
            }
            if(!email.Text.Contains('@'))
            {
                MessageBox.Show("Email tidak valid!");
                return;
            }
            if(name.Text.Trim() == "")
            {
                MessageBox.Show("Nama tidak boleh kosong!");
                return;
            }
            if(dateOfBirth.Value >= DateTime.Now)
            {
                MessageBox.Show("Tanggal lahir tidak valid!");
                return;
            }
            if(jobs.SelectedIndex == -1)
            {
                MessageBox.Show("Pekerjaan harus dipilih!");
                return;
            }
            if (!editing && selectedFilePath == "")
            {
                MessageBox.Show("Foto tipe kamar harus dipilih!");
                return;
            }
            if(address.Text.Trim() == "")
            {
                MessageBox.Show("Alamat tidak boleh kosong!");
                return;
            }
            if (!editing && selectedFilePath == "")
            {
                MessageBox.Show("Foto karyawan harus ada!");
                return;
            }
            if (editing)
            {
                var selected = table1.SelectedRows[0].DataBoundItem as Employee;
                var dbFilePath = assetsDir + "\\" + selected.Photo;
                DBC.Employees.Attach(selected);
                selected.Name = username.Text.Trim();
                if(password.Text.Trim() != "")
                {
                    selected.Username = username.Text.Trim();
                    selected.Password = Helper.hashSHA256(password.Text);
                }
                selected.Email = email.Text.Trim();
                selected.Address = address.Text.Trim();
                selected.DateOfBirth = dateOfBirth.Value.Date;
                selected.JobId = (jobs.SelectedItem as Job).Id;
                if (Path.GetFileName(selectedFilePath) != selected.Photo)
                {
                    var fileName = Path.GetFileNameWithoutExtension(selected.Photo);
                    var Extension = Path.GetExtension(selectedFilePath);
                    File.Copy(selectedFilePath, assetsDir + $"\\{fileName}.{Extension}", true);
                }
                DBC.Entry(selected).State = System.Data.Entity.EntityState.Modified;
            } else
            {
                if (!password.Text.Any(Char.IsDigit) || !password.Text.Any(Char.IsLetter) ||
                !password.Text.Any(c => !Char.IsDigit(c) && Char.IsLetter(c)))
                {
                    MessageBox.Show("Password harus mengkombinasikan alfabet, angka dan simbol!");
                    return;
                }
                if (password.Text != confirmPassword.Text)
                {
                    MessageBox.Show("Password dan konfirmasi password tidak sesuai!");
                    return;
                }
                var fileName = Helper.GenerateRandomString() + Path.GetExtension(selectedFilePath);
                File.Copy(selectedFilePath, assetsDir + "\\" + fileName, true);
                var newEmployee = new Employee()
                {
                    Name = username.Text.Trim(),
                    Username = username.Text.Trim(),
                    Password = Helper.hashSHA256(password.Text),
                    Email = email.Text.Trim(),
                    Address = address.Text.Trim(),
                    DateOfBirth = dateOfBirth.Value.Date,
                    JobId = (jobs.SelectedItem as Job).Id,
                    Photo = fileName,
                };
                DBC.Employees.Add(newEmployee);
            }
            DBC.SaveChanges();
            updateFields(false, true);
            RefreshData();
        }

        private void onCancel(object sender, EventArgs e)
        {
            updateFields(false, true);
        }

        private void onCreate(object sender, EventArgs e)
        {
            editing = false;
            updateFields(true, true);
        }

        private void onUpdate(object sender, EventArgs e)
        {
            editing = true;
            updateFields(true, false);
        }

        private void onDelete(object sender, EventArgs e)
        {
            var res = MessageBox.Show("Apakah anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo);
            if (res == DialogResult.No) return;
            var selected = table1.SelectedRows[0].DataBoundItem as Employee;
            picture1.Image.Dispose();
            DBC.Employees.Attach(selected);
            DBC.Employees.Remove(selected);
            DBC.SaveChanges();
            RefreshData();
            updateFields(false, true);
            File.Delete(assetsDir + "\\" + selected.Photo);
        }

        private void onTableCellClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var selected = table1.Rows[e.RowIndex].DataBoundItem as Employee;
            username.Text = selected.Name;
            password.Text = "";
            confirmPassword.Text = "";
            name.Text = selected.Name;
            email.Text = selected.Email;
            dateOfBirth.Value = selected.DateOfBirth;
            address.Text = selected.Address;
            jobs.SelectedValue = selected.JobId;
            selectedFilePath = assetsDir + "\\" + selected.Photo;
            picture1.Image = Image.FromFile(selectedFilePath);
            insert.Enabled = true;
            update.Enabled = true;
            delete.Enabled = true;
        }

        private void onFilePickClicked(object sender, EventArgs e)
        {
            if(filePicker.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = filePicker.FileName;
                picture1.Image = Image.FromFile(selectedFilePath);
            }
            
        }
    }
}
