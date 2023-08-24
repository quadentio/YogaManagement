using Data.Access.Data;
using Data.Models;

namespace Data.Access.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        public void Save();
        public void Update(User obj);
    }
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly YogaManagementDbContext _dbContext;
        public UserRepository(YogaManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(User obj)
        {
            _dbContext.Users.Update(obj);
        }
    }
}
