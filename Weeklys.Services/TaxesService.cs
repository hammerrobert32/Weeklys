using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weeklys.Data;
using Weeklys.Models;

namespace Weeklys.Services
{
    public class TaxesService
    {
        private readonly Guid _userID;

        public TaxesService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateTaxes(TaxesCreate model)
        {
            var entity =
                new Taxes()
                {
                    OwnerID = _userID,
                    State = model.State,
                    Federal = model.Federal,
                    CreatedUtc = DateTimeOffset.Now
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Taxes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TaxesListItem> GetTaxes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Taxes
                        .Where(e => e.OwnerID == _userID)
                        .Select(
                            e =>
                                new TaxesListItem
                                {
                                    TaxesID = e.TaxesID,
                                    State = e.State,
                                    Federal = e.Federal,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }

        public TaxesDetail GetTaxesByID(int ID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Taxes
                        .Single(e => e.TaxesID == ID && e.OwnerID == _userID);
                return
                    new TaxesDetail
                    {
                        TaxesID = entity.TaxesID,
                        State = entity.State,
                        Federal = entity.Federal,
                        CreatedUtc = entity.CreatedUtc,
                    };
            }
        }

        public bool UpdateTaxes(TaxesEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Taxes
                        .Single(e => e.TaxesID == model.TaxesID && e.OwnerID == _userID);

                entity.State = model.State;
                entity.Federal = model.Federal;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTaxes(int taxesID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Taxes
                        .Single(e => e.TaxesID == taxesID && e.OwnerID == _userID);

                ctx.Taxes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
