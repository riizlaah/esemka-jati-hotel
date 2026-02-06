using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class ReservationRoom
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        [Column(TypeName = "date")] public DateTime StartDateTime { get; set; }
        public int DurationNights { get; set; }
        public int RoomPrice { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CheckInDateTime { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CheckOutDateTime { get; set; }
        public string RoomNumber => Room != null ? Room.RoomNumber : "";
        public string RoomFloor => Room != null ? Room.RoomFloor : "";
        public string RoomType => Room != null ? Room.RoomType.ToString() : "";
        public virtual Reservation Reservation { get; set; }
        public virtual Room Room { get; set; }
    }
}
