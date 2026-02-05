using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class FoodAndDrinks
    {
        public int Id { get; set; }
        [StringLength(50)] public string Name { get; set; }
        public char Type { get; set; } // 'F' for Food, 'D' for Drinks
        public string LongType => Type == 'F' ? "Food" : "Drinks";
        public int Price { get; set; }
        [StringLength(50)] public string Photo { get; set; } = "default.jpg";
    }
}
