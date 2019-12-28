using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.Commission
{
    public interface IReferencedCommission
    {
        List<ImageModel> References { get; set; }
    }
}
