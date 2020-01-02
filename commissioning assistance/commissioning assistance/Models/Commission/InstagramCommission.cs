using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime FinishedDate { get; set; }

        private ProductType _productType;

        public ProductType ProductType
        {
            get { return _productType; }
            set { _productType = value; ProductTypeId = _productType.ProductTypeId; }
        }
        public int ProductTypeId { get; set; }

        public InstagramCommission()
        {
            OrderDate = DateTime.Today;
            DueDate = DateTime.Today;
            FinishedDate = DateTime.Today;
        }
        /*

        public void Create()
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            context.Commissions.Add(this);
            context.ProductTypes.Attach(ProductType);
            context.SaveChanges();
        }

        public void Update()
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            
            foreach (var img in this.References)
            {
                context.Images.AddOrUpdate(img);
            }
            context.Commissions.AddOrUpdate(this);
            context.ProductTypes.AddOrUpdate(ProductType);
            context.SaveChanges();
        }

        public void Delete()
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            context.ProductTypes.Attach(ProductType);
            context.Commissions.Remove(this);
            context.SaveChanges();
        }

        public void HoldDeleteReference(ImageModel image)
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            context.Images.Remove(image);
        }

        public static async Task<ICollection<InstagramCommission>> GetCommissions()
        {
            using DatabaseDbContext context = new DatabaseDbContext();

            return await context.Commissions.Include(pt => pt.ProductType).Include(reference => reference.References).AsNoTracking().ToListAsync();
        }
        */

        public bool Verify()
        {
            if (References == null) return false;
            if (References.Count == 0) return false;
            if (Instagram.Length == 0) return false;
            if (Name.Length == 0) return false;
            if (Email.Length == 0) return false;
            if (CurrencyType.Length == 0) return false;
            if (Quantity == 0) return false;
            if (References.Count == 0) return false;
            if (String.IsNullOrEmpty(ProductType.ToString())) return false;

            return true;
        }
    }
}
