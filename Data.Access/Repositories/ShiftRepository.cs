using Data.Access.Data;
using Data.Models;

namespace Data.Access.Repositories
{
    public interface IShiftRepository : IRepository<Class>
    {
        public void Save();
        public void Update(Shift obj);
    }
    public class ShiftRepository : Repository<Class>, IShiftRepository
    {
        private readonly YogaManagementDbContext _dbContext;
        public ShiftRepository(YogaManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Shift obj)
        {
            _dbContext.Shifts.Update(obj);
        }
    }
}
