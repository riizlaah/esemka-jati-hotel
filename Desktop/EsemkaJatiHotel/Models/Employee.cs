using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50)] public string Username { get; set; }
        [StringLength(50)] public string Password { get; set; }
        [StringLength(100)] public string Name { get; set; }
        [StringLength(50)] public string Email { get; set; }
        [StringLength(200)] public string Address { get; set; }
        [Column(TypeName = "date")] public DateTime DateOfBirth { get; set; }
        public int JobId { get; set; }
        public virtual Job Job { get; set; }
        [StringLength(100)] public string Photo { get; set; } = "default.jpg";
    }
}
