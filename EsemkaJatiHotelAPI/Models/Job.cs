using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

public partial class Job
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [InverseProperty("Job")]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
