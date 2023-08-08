using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Access.Data
{
    public class YogaManagementDbContext : DbContext
    {
        public YogaManagementDbContext(DbContextOptions<YogaManagementDbContext> options) : base(options)
        {

        }
    }
}
