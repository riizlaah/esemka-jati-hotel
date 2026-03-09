using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Index("ReservationId", Name = "IX_ReservationId")]
[Index("RoomId", Name = "IX_RoomId")]
public partial class ReservationRoom
{
    [Key]
    public int Id { get; set; }

    public int ReservationId { get; set; }

    public int RoomId { get; set; }

    public DateOnly StartDateTime { get; set; }

    public int DurationNights { get; set; }

    public int RoomPrice { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckInDateTime { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? CheckOutDateTime { get; set; }

    [InverseProperty("ReservationRoom")]
    public virtual ICollection<Fdcheckout> Fdcheckouts { get; set; } = new List<Fdcheckout>();

    [ForeignKey("ReservationId")]
    [InverseProperty("ReservationRooms")]
    public virtual Reservation Reservation { get; set; } = null!;

    [InverseProperty("ReservationRoom")]
    public virtual ICollection<ReservationCheckOut> ReservationCheckOuts { get; set; } = new List<ReservationCheckOut>();

    [InverseProperty("ReservationRoom")]
    public virtual ICollection<ReservationRequestItem> ReservationRequestItems { get; set; } = new List<ReservationRequestItem>();

    [ForeignKey("RoomId")]
    [InverseProperty("ReservationRooms")]
    public virtual Room Room { get; set; } = null!;
}
