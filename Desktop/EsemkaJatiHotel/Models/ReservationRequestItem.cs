using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class ReservationRequestItem
    {
        public int Id { get; set; }
        public int ReservationRoomId { get; set; }
        public int ItemId { get; set; }
        public int Qty { get; set; }
        public int TotalPrice { get; set; }
        public virtual ReservationRoom ReservationRoom { get; set; }
        public virtual Item Item { get; set; }
    }
}
