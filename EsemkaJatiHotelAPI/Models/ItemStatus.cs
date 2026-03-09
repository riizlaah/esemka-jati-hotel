using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

[Table("ItemStatus")]
public partial class ItemStatus
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [InverseProperty("ItemStatus")]
    public virtual ICollection<ReservationCheckOut> ReservationCheckOuts { get; set; } = new List<ReservationCheckOut>();
}
