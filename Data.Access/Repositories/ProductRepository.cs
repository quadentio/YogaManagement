using Data.Access.Data;
using Data.Models;

namespace Data.Access.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        public void Save();
        public void Update(Product obj);
    }
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly YogaManagementDbContext _dbContext;
        public ProductRepository(YogaManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Product obj)
        {
            _dbContext.Products.Update(obj);
        }
    }
}
