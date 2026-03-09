using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Index("JobId", Name = "IX_JobId")]
public partial class Employee
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Username { get; set; }

    [StringLength(50)]
    public string? Password { get; set; }

    [StringLength(100)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Email { get; set; }

    [StringLength(200)]
    public string? Address { get; set; }

    public DateOnly DateOfBirth { get; set; }

    public int JobId { get; set; }

    [StringLength(100)]
    public string? Photo { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Fdcheckout> Fdcheckouts { get; set; } = new List<Fdcheckout>();

    [ForeignKey("JobId")]
    [InverseProperty("Employees")]
    public virtual Job Job { get; set; } = null!;

    [InverseProperty("Employee")]
    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
