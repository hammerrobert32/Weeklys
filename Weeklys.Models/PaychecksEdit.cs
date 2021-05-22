using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Models
{
    public class PaychecksEdit
    {
        public int PaychecksID { get; set; }

        public Enum Name { get; set; }

        public double AmountPaid { get; set; }
    }
}
