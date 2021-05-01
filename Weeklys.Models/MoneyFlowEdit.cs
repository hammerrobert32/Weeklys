using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weeklys.Models
{
    public class MoneyFlowEdit
    {
        public int MoneyFlowID { get; set; }

        public double Revenue { get; set; }

        public double Expenses { get; set; }

        public double TaxesSum { get; set; }

        public double Profit { get; set; }

    }
}
