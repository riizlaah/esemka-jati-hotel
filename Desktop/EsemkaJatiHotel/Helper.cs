using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EsemkaJatiHotel
{
    public class Helper
    {
        public static void GenerateTableColumn(DataGridView table, string[] header, string[] bindProperty)
        {
            table.AutoGenerateColumns = false;
            for (int i = 0; i < header.Length; i++)
            {
                var col = new DataGridViewTextBoxColumn();
                col.Name = header[i];
                col.HeaderText = header[i];
                col.DataPropertyName = bindProperty[i];
                table.Columns.Add(col);
            }
        }
        public static string GetAssetsDir(string suffix = "")
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dir = Path.Combine(appData, @"EsemkaJatiHotel\assets");
            if (suffix != "")
            {
                dir = Path.Combine(dir, suffix);
            }
            if(!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            return dir;
        }

        public static string GenerateRandomString(int maxLength = 0)
        {
            var guid = Guid.NewGuid().ToString().Replace("-", "");
            if (maxLength > 0 && maxLength < guid.Length)
            {
                return guid.Substring(0, maxLength);
            }
            else
            {
                return guid;
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
