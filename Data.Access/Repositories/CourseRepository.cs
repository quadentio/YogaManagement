using Data.Access.Data;
using Data.Models;

namespace Data.Access.Repositories
{
    public interface ICourseRepository : IRepository<Course>
    {
        public void Save();
        public void Update(Course obj);
    }
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        private readonly YogaManagementDbContext _dbContext;
        public CourseRepository(YogaManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(Course obj)
        {
            _dbContext.Courses.Update(obj);
        }
    }
}
