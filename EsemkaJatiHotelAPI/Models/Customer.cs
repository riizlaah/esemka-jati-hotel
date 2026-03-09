using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [Column("NIK")]
    [StringLength(50)]
    public string? Nik { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(1)]
    public string? Gender { get; set; }

    [StringLength(20)]
    public string? PhoneNumber { get; set; }

    public int Age { get; set; }

    [InverseProperty("Customer")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
