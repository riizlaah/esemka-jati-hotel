using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

public partial class FoodAndDrink
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(1)]
    public string? Type { get; set; }

    public int Price { get; set; }

    [StringLength(50)]
    public string? Photo { get; set; }

    [InverseProperty("Fd")]
    public virtual ICollection<Fdcheckout> Fdcheckouts { get; set; } = new List<Fdcheckout>();
}
