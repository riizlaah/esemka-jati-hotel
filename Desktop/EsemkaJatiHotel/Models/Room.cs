using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        [StringLength(50)] public string RoomNumber { get; set; }
        [StringLength(50)] public string RoomFLoor { get; set; }
        [Column(TypeName ="text")] public string Description { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}
