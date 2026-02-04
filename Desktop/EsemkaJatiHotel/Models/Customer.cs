using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string NIK { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public char gender { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
    }
}
