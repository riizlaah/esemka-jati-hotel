using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Table("FDCheckouts")]
[Index("EmployeeId", Name = "IX_EmployeeId")]
[Index("Fdid", Name = "IX_FDId")]
[Index("ReservationRoomId", Name = "IX_ReservationRoomId")]
public partial class Fdcheckout
{
    [Key]
    public int Id { get; set; }

    public int ReservationRoomId { get; set; }

    [Column("FDId")]
    public int Fdid { get; set; }

    public int EmployeeId { get; set; }

    public int Qty { get; set; }

    public int TotalPrice { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Fdcheckouts")]
    public virtual Employee Employee { get; set; } = null!;

    [ForeignKey("Fdid")]
    [InverseProperty("Fdcheckouts")]
    public virtual FoodAndDrink Fd { get; set; } = null!;

    [ForeignKey("ReservationRoomId")]
    [InverseProperty("Fdcheckouts")]
    public virtual ReservationRoom ReservationRoom { get; set; } = null!;
}


public class PurchaseFD
{
    [Required]
    public int roomId { get; set; }

    [Required]
    public int FDId { get; set; }

    [Required]
    [Range(1, 9999)]
    public int quantity { get; set; }
}