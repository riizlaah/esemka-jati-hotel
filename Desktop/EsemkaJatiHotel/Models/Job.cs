using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsemkaJatiHotel.Models
{
    public class Job
    {
        public int Id { get; set; }
        [StringLength(50)] public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
