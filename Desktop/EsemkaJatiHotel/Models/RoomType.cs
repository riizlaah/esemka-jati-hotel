using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        [StringLength(50)] public string Name { get; set; }
        public int Capacity { get; set; }
        public int Price { get; set; }
        [StringLength(100)] public string Photo { get; set; } = "default.jpg";
    }
}
