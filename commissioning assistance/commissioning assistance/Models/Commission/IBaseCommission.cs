using DataAccessLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.Commission
{
    public interface IBaseCommission
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        float Money { get; set; }
        string CurrencyType { get; set; }
        int Quantity { get; set; }
        ProductType ProductType { get; set; }
        string Description { get; set; }
        DateTime OrderDate { get; set; }
        DateTime DueDate { get; set; }
        DateTime FinishedDate { get; set; }

        void Create(DataAccessModel dataAccess);
        void Update(DataAccessModel dataAccess);
        void Delete(DataAccessModel dataAccess);

    }
}
