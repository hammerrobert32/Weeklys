using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weeklys.Data;
using Weeklys.Models;

namespace Weeklys.Services
{
    public class PaychecksService
    {
        private readonly Guid _userID;

        public PaychecksService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePaychecks(PaychecksCreate model, int moneyFlowID)
        {
            var entity =
                new Paychecks()
                {
                    OwnerID = _userID,
                    MoneyFlowID = moneyFlowID,
                    Name = model.Name,
                    AmountPaid = model.AmountPaid,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Paychecks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PaychecksListItem> GetPaychecks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Paychecks
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new PaychecksListItem
                                {
                                    PaychecksID = e.PaychecksID,
                                    Name = e.Name,
                                    AmountPaid = e.AmountPaid,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public PaychecksDetail GetPaychecksByID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Paychecks
                        .Single(e => e.PaychecksID == ID && e.OwnerID == _userID);
                return
                    new PaychecksDetail
                    {
                        PaychecksID = entity.PaychecksID,
                        Name = entity.Name,
                        AmountPaid = entity.AmountPaid,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }

        public bool UpdatePaychecks(PaychecksEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Paychecks
                        .Single(e => e.PaychecksID == model.PaychecksID && e.OwnerID == _userID);

                entity.Name = model.Name;
                entity.AmountPaid = model.AmountPaid;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePaychecks(int paychecksID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Paychecks
                        .Single(e => e.PaychecksID == paychecksID && e.OwnerID == _userID);

                ctx.Paychecks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }


    }
}
