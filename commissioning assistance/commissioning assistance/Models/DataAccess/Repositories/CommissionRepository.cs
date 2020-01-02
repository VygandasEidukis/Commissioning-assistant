using commissioning_assistance.Core.Repositories;
using commissioning_assistance.Models.Commission;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace commissioning_assistance.Models.DataAccess.Repositories
{
    public class CommissionRepository : Repository<InstagramCommission>, ICommissionRepository
    {
        public CommissionRepository(DatabaseDbContext context) : base(context) {}

        public DatabaseDbContext dbContext { get => Context as DatabaseDbContext; }

        public IEnumerable<InstagramCommission> GetFullCommissions()
        {
            return dbContext.Commissions.Include(pt => pt.ProductType).Include(reference => reference.References).AsNoTracking().ToList();
        }

        public void UpdateCommission(InstagramCommission commission)
        {
            dbContext.Entry(commission).State = EntityState.Modified;
        }
    }
}
