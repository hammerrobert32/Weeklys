using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Data
{
    public class Paychecks
    {
        [Key]
        public int PaychecksID { get; set; }

        [Required]
        public Name Name { get; set; }

        [Required]
        public double AmountPaid { get; set; }

        [Required]
        [ForeignKey(nameof(Weekly))]
        public int WeeklyID { get; set; }
        public virtual Weekly Weekly { get; set; }
    }

    public enum Name
    {
        Julie,
        April,
        Bobby,
        Geante,
        Jenny,
        Lionel
    }
}
