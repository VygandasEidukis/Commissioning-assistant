using commissioning_assistance.Core.Repositories;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace commissioning_assistance.Models.DataAccess.Repositories
{
    public class ImageRepository : Repository<ImageModel>, IImageRepository
    {
        public ImageRepository(DatabaseDbContext context) : base(context) { }

        public DatabaseDbContext dbContext { get => Context as DatabaseDbContext; }

        public void DeatatchImage(ImageModel img)
        {
            dbContext.Entry(img).State = EntityState.Detached;
        }

        public void RemoveById(int id)
        {
            dbContext.Images.Delete(i => i.Id == id);
        }
    }
}
