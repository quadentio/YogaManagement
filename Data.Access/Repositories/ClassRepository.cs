using Data.Access.Data;
using Data.Models;

namespace Data.Access.Repositories
{
    public interface IClassRepository : IRepository<Class>
    {
        public void Save();
        public void Update(Class obj);
    }
    public class ClassRepository : Repository<Class>, IClassRepository
    {
        private readonly YogaManagementDbContext _dbContext;
        public ClassRepository(YogaManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Class obj)
        {
            _dbContext.Classes.Update(obj);
        }
    }
}
