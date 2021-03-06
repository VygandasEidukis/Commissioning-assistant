﻿using commissioning_assistance.Models.Commission;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace commissioning_assistance.Models
{
    public class ProductType
    {
        [Key]
        public int ProductTypeId { get; set; }
        public string Type { get; set; }

        public virtual ICollection<InstagramCommission> Commissions { get; set; }

        public ProductType(string type)
        {
            Type = type;
        }

        public ProductType(){}

        public override string ToString()
        {
            return Type;
        }
    }
}
