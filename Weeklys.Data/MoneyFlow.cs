using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Data
{
    public class MoneyFlow
    {
        [Key]
        public int MoneyFlowID { get; set; }

        [Required]
        public Guid OwnerID { get; set; }

        [Required]
        public double Revenue { get; set; }

        [Required]
        public double Expenses { get; set; }

        [Required]
        public double TaxesSum { get; set; }

        [Required]
        public double Profit { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
