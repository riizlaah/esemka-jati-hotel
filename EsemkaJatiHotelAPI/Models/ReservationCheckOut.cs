using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Index("ItemId", Name = "IX_ItemId")]
[Index("ItemStatusId", Name = "IX_ItemStatusId")]
[Index("ReservationRoomId", Name = "IX_ReservationRoomId")]
public partial class ReservationCheckOut
{
    [Key]
    public int Id { get; set; }

    public int ReservationRoomId { get; set; }

    public int ItemId { get; set; }

    public int ItemStatusId { get; set; }

    public int Qty { get; set; }

    public int TotalCharge { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ReservationCheckOuts")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("ItemStatusId")]
    [InverseProperty("ReservationCheckOuts")]
    public virtual ItemStatus ItemStatus { get; set; } = null!;

    [ForeignKey("ReservationRoomId")]
    [InverseProperty("ReservationCheckOuts")]
    public virtual ReservationRoom ReservationRoom { get; set; } = null!;
}
