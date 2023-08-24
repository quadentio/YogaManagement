using Data.Access.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace Data.Access.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IClassRepository ClassRepository { get; }
        IProductRepository ProductRepository { get; }
        ICourseRepository CourseRepository { get; }
        IClientRepository ClientRepository { get; }
        IShiftRepository ShiftRepository { get; }

        IUserRepository UserRepository { get; }

        void BeginTransaction();
        void Commit();
        void Save();
        void ExecuteQuery(string query);
    }

    public class UnitOfWork : IUnitOfWork
    {
        #region DBContext
        private readonly YogaManagementDbContext _dbContext;
        private IDbContextTransaction _transaction;
        #endregion

        #region Repositories
        private IClassRepository _classRepository;
        private IProductRepository _productRepository;
        private ICourseRepository _courseRepository;
        private IClientRepository _clientRepository;
        private IShiftRepository _shiftRepository;
        private IUserRepository _userRepository;
        #endregion

        public UnitOfWork(YogaManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Transaction
        public void BeginTransaction()
        {
            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }
        #endregion

        public IClassRepository ClassRepository
        {
            get
            {
                if (_classRepository == null)
                {
                    _classRepository = new ClassRepository(_dbContext);
                }
                return _classRepository;
            }
        }

        public IProductRepository ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new ProductRepository(_dbContext);
                }
                return _productRepository;
            }
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                if (_courseRepository == null)
                {
                    _courseRepository = new CourseRepository(_dbContext);
                }
                return _courseRepository;
            }
        }

        public IClientRepository ClientRepository
        {
            get
            {
                if (_clientRepository == null)
                {
                    _clientRepository = new ClientRepository(_dbContext);
                }
                return _clientRepository;
            }
        }

        public IShiftRepository ShiftRepository
        {
            get
            {
                if (_shiftRepository == null)
                {
                    _shiftRepository = new ShiftRepository(_dbContext);
                }
                return _shiftRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose of managed resources
                _dbContext?.Dispose();
                _classRepository?.Dispose();
                _productRepository?.Dispose();
                _clientRepository?.Dispose();
                _courseRepository?.Dispose();
                _shiftRepository?.Dispose();
            }

            // Dispose of unmanaged resources

            // Example: Close database connections, release file handles, etc.
        }
        public void ExecuteQuery(string query)
        {
            //_dbContext.Database.ExecuteSql(query);
        }
    }
}
