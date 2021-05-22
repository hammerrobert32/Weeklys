using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Models
{
    public class PaychecksCreate
    {
        public Enum Name { get; set; }

        [Required]
        public double AmountPaid { get; set; }
    }
}
