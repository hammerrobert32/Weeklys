using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Models
{
    public class MoneyFlowListItem
    {
        public int MoneyFlowID { get; set; }

        public double Profit { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
