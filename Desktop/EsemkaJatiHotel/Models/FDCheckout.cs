using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class FDCheckout
    {
        public int Id { get; set; }
        public int ReservationRoomId { get; set; }
        public int FDId { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public int Qty { get; set; }
        public int TotalPrice { get; set; }
        public string FDName => FD != null ? FD.Name : "";
        public string FDType => FD != null ? (FD.Type == "F" ? "Food" : "Drink") : "?";
        public int FDPrice => FD != null ? FD.Price : 0;
        public virtual ReservationRoom ReservationRoom { get; set; }
        [ForeignKey("FDId")] public virtual FoodAndDrinks FD { get; set; }
    }
}
