using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Data
{
    public class Weekly
    {
        [Key]
        public int WeeklyID { get; set; }

        [Required]
        public double Revenue { get; set; }

        [Required]
        public double Expenses { get; set; }

        public double? TaxesSum { get; set; }

        public double? Profit { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
