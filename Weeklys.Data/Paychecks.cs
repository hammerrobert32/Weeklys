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
        public Guid OwnerId { get; set; }

        [Required]
        public Name Name { get; set; }

        [Required]
        public double AmountPaid { get; set; }

        [Required]
        [ForeignKey(nameof(MoneyFlow))]
        public int MoneyFlowID { get; set; }
        public virtual MoneyFlow MoneyFlow { get; set; }

        [Required]
        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }

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
