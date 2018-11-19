using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOCDemo
{
    public class LGDbContext : DbContext
    {
        public LGDbContext(DbContextOptions<LGDbContext> options) : base(options) { }

        #region 
        public DbSet<User> User { get; set; }
        #endregion
    }
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int WorkId { get; set; }
        public string Pwd { get; set; }
    }
}
