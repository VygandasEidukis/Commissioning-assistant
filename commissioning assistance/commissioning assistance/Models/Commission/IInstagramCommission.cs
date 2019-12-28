using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.Commission
{
    public interface IInstagramCommission : IBaseCommission
    {
        string Instagram { get; set; }
    }
}
