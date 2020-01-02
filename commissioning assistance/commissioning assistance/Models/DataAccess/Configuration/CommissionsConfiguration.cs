using commissioning_assistance.Models.Commission;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.DataAccess.Configuration
{
    public class CommissionsConfiguration : EntityTypeConfiguration<InstagramCommission>
    {
        public CommissionsConfiguration()
        {
            HasRequired(c => c.ProductType)
                .WithMany(a => a.Commissions)
                .HasForeignKey(c => c.ProductTypeId)
                .WillCascadeOnDelete(false);

            HasMany(s => s.References)
                .WithRequired(x => x.Commission)
                .HasForeignKey(p => p.CommissionId);
        }
    }
}
