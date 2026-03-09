using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EsemkaJatiHotelAPI.Models;

public partial class Item
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public int RequestPrice { get; set; }

    public int CompensationFee { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<ReservationCheckOut> ReservationCheckOuts { get; set; } = new List<ReservationCheckOut>();

    [InverseProperty("Item")]
    public virtual ICollection<ReservationRequestItem> ReservationRequestItems { get; set; } = new List<ReservationRequestItem>();
}
