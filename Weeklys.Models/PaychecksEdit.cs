using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weeklys.Data;

namespace Weeklys.Models
{
    public class PaychecksEdit
    {
        public int PaychecksID { get; set; }

        public Name Name { get; set; }

        public double AmountPaid { get; set; }
    }
}
