using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime DateTime { get; set; }
        public int EmployeeId { get; set; }
        public int CustomerId { get; set; }
        [StringLength(6)] public string BookingCode { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<ReservationRoom> ReservationRooms { get; set; }
    }
}
