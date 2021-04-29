using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Models
{
    public class MoneyFlowCreate
    {

        [Required]
        public double Revenue { get; set; }

        [Required]
        public double Expenses { get; set; }

        [Required]
        public double TaxesSum { get; set; }

        [Required]
        public double Profit { get; set; }

    }
}
