using commissioning_assistance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Core.Repositories
{
    public interface IImageRepository : IRepository<ImageModel>
    {
        public void RemoveById(int id);
        public void DeatatchImage(ImageModel img);
    }
}
