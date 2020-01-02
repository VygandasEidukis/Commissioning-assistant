using commissioning_assistance.Models.Commission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Core.Repositories
{
    public interface ICommissionRepository : IRepository<InstagramCommission>
    {
        IEnumerable<InstagramCommission> GetFullCommissions();
        void UpdateCommission(InstagramCommission commission);
    }
}
