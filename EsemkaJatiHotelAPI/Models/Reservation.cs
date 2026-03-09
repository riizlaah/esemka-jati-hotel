using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Index("CustomerId", Name = "IX_CustomerId")]
[Index("EmployeeId", Name = "IX_EmployeeId")]
public partial class Reservation
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DateTime { get; set; }

    public int EmployeeId { get; set; }

    public int CustomerId { get; set; }

    [StringLength(6)]
    public string? BookingCode { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Reservations")]
    public virtual Customer Customer { get; set; } = null!;

    [ForeignKey("EmployeeId")]
    [InverseProperty("Reservations")]
    public virtual Employee Employee { get; set; } = null!;

    [InverseProperty("Reservation")]
    public virtual ICollection<ReservationRoom> ReservationRooms { get; set; } = new List<ReservationRoom>();
}
