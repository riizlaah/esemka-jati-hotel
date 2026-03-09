using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Index("RoomTypeId", Name = "IX_RoomTypeId")]
public partial class Room
{
    [Key]
    public int Id { get; set; }

    public int RoomTypeId { get; set; }

    [StringLength(50)]
    public string? RoomNumber { get; set; }

    [StringLength(50)]
    public string? RoomFloor { get; set; }

    [Column(TypeName = "text")]
    public string? Description { get; set; }

    [InverseProperty("Room")]
    public virtual ICollection<ReservationRoom> ReservationRooms { get; set; } = new List<ReservationRoom>();

    [ForeignKey("RoomTypeId")]
    [InverseProperty("Rooms")]
    public virtual RoomType RoomType { get; set; } = null!;
}
