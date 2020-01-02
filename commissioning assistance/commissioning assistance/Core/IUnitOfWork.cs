using commissioning_assistance.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ICommissionRepository Commissions { get; }
        IProductTypeRepository ProductTypes { get; }
        IImageRepository Images { get; }

        int Complete();
    }
}
