using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weeklys.Data;
using Weeklys.Models;

namespace Weeklys.Services
{
    public class MoneyFlowService
    {
        private readonly Guid _userID;

        public MoneyFlowService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateMoneyFlow(MoneyFlowCreate model)
        {
            var entity =
                new MoneyFlow()
                {
                    OwnerID = _userID,
                    Revenue = model.Revenue,
                    Expenses = model.Expenses,
                    TaxesSum = model.TaxesSum,
                    Profit = model.Profit,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MoneyFlow.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
