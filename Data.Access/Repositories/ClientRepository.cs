using Data.Access.Data;
using Data.Models;

namespace Data.Access.Repositories
{
    public interface IClientRepository : IRepository<Client>
    {
        public void Save();
        public void Update(Client obj);
    }
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        private readonly YogaManagementDbContext _dbContext;
        public ClientRepository(YogaManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Client obj)
        {
            _dbContext.Clients.Update(obj);
        }
    }
}
