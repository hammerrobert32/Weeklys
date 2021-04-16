using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Data
{
    public class Taxes
    {
        [Key]
        [ForeignKey(nameof(Weekly))]
        public int TaxesID { get; set; }
        public virtual Weekly Weekly { get; set; }


        public double State { get; set; }

        public double Federal { get; set; }
    }
}
