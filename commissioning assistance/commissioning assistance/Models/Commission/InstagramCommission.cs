﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.Commission
{
    public class InstagramCommission : IInstagramCommission, IReferencedCommission, IEntity
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

        public void Create()
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            context.Commissions.Add(this);
            context.SaveChanges();
        }

        public void Update()
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            context.SaveChanges();
        }

        public void Delete()
        {
            using DatabaseDbContext context = new DatabaseDbContext();
            context.Commissions.Remove(this);
        }
    }
}
