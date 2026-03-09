using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Index("ItemId", Name = "IX_ItemId")]
[Index("ReservationRoomId", Name = "IX_ReservationRoomId")]
public partial class ReservationRequestItem
{
    [Key]
    public int Id { get; set; }

    public int ReservationRoomId { get; set; }

    public int ItemId { get; set; }

    public int Qty { get; set; }

    public int TotalPrice { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ReservationRequestItems")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("ReservationRoomId")]
    [InverseProperty("ReservationRequestItems")]
    public virtual ReservationRoom ReservationRoom { get; set; } = null!;
}
