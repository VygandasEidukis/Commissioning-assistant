using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.DataAccess;

namespace commissioning_assistance.Models.Commission
{
    public class InstagramCommission : IInstagramCommission, IReferencedCommission
    {
        public List<ImageModel> References { get; set; }
        public string Instagram { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public float Money { get; set; }
        public string CurrencyType { get; set; }
        public int Quantity { get; set; }
        public ProductType ProductType { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime FinishedDate { get; set; }

        public InstagramCommission()
        {
            OrderDate = DateTime.Today;
            DueDate = DateTime.Today;
            FinishedDate = DateTime.Today;
            ProductType = new ProductType();
            References = new List<ImageModel>();
        }

        public void Create(DataAccessModel dataAccess)
        {
            throw new NotImplementedException();
        }

        public void Delete(DataAccessModel dataAccess)
        {
            throw new NotImplementedException();
        }

        public void Update(DataAccessModel dataAccess)
        {
            throw new NotImplementedException();
        }
    }
}
