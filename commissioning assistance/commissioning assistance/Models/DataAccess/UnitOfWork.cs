using commissioning_assistance.Core;
using commissioning_assistance.Core.Repositories;
using commissioning_assistance.Models.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseDbContext _context;

        public ICommissionRepository Commissions { get; private set; }
        public IProductTypeRepository ProductTypes { get; private set; }
        public IImageRepository Images { get; private set; }

        public UnitOfWork(DatabaseDbContext context)
        {
            _context = context;
            Commissions = new CommissionRepository(context);
            ProductTypes = new ProductTypeRepository(context);
            Images = new ImageRepository(context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
