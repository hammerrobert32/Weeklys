using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weeklys.Data;

namespace Weeklys.Models
{
    public class PaychecksCreate
    {
        public Name Name { get; set; }

        [Required]
        public double AmountPaid { get; set; }
    }
}
