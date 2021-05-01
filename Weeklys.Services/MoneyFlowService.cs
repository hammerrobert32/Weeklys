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

        public IEnumerable<MoneyFlowListItem> GetMoneyFlows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MoneyFlow
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new MoneyFlowListItem
                                {
                                    MoneyFlowID = e.MoneyFlowID,
                                    Profit = e.Profit,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public MoneyFlowDetail GetMoneyFlowByID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MoneyFlow
                        .Single(e => e.MoneyFlowID == ID && e.OwnerID == _userID);
                return
                    new MoneyFlowDetail
                    {
                        MoneyFlowID = entity.MoneyFlowID,
                        Revenue = entity.Revenue,
                        Expenses = entity.Expenses,
                        TaxesSum = entity.TaxesSum,
                        Profit = entity.Profit,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }

        public bool UpdateMoneyFlow(MoneyFlowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MoneyFlow
                        .Single(e => e.MoneyFlowID == model.MoneyFlowID && e.OwnerID == _userID);

                entity.Revenue = model.Revenue;
                entity.Expenses = model.Expenses;
                entity.TaxesSum = model.TaxesSum;
                entity.Profit = model.Profit;

                return ctx.SaveChanges() == 1;
            }
        }

        //public bool DeleteNote(int noteId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //                .Notes
        //                .Single(e => e.NoteId == noteId && e.OwnerId == _userId);

        //        ctx.Notes.Remove(entity);

        //        return ctx.SaveChanges() == 1;
        //    }
        //}


    }
}
