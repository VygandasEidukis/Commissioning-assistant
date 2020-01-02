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

        public void AddReferences(InstagramCommission com, List<ImageModel> imgs)
        {
            throw new System.Exception("");
            for(int i = 0; i < com.References.Count; i++)
            {
                foreach(var img in imgs)
                {
                    if(img.Path == com.References[i].Path)
                    {
                        dbContext.Entry(com.References[i]).State = EntityState.Added;
                    }
                }
            }
        }

        public IEnumerable<InstagramCommission> GetFullCommissions()
        {
            return dbContext.Commissions.Include(pt => pt.ProductType).Include(reference => reference.References).AsNoTracking().ToList();
        }

        public void UpdateCommission(InstagramCommission commission)
        {
            dbContext.Entry(commission).State = EntityState.Modified;
            dbContext.Entry(commission.ProductType).State = EntityState.Modified;
        }

    }
}
