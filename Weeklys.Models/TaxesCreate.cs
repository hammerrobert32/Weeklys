using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Models
{
    public class TaxesCreate
    { 
        [Required]
        public int MoneyFlowID { get; set; }

        [Required]
        public double State { get; set; }

        [Required]
        public double Federal { get; set; }

    }
}
