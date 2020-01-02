using commissioning_assistance.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.DataAccess.Repositories
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        public ProductTypeRepository(DatabaseDbContext context) : base(context) { }

        public DatabaseDbContext dbContext { get => Context as DatabaseDbContext; }
    }
}
