using commissioning_assistance.Models.Commission;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models
{
    public class ImageModel
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public virtual InstagramCommission Commission { get; set; }
        public int CommissionId { get; set; }

        public ImageModel(string Path)
        {
            this.Path = Path;
        }
        public ImageModel(){}

        public override string ToString()
        {
            return Path;
        }
    }
}
