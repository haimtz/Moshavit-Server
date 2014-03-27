using System.Data.Entity;
using Moshavit.Entity;

namespace Moshavit.DataBase
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
        }

        public DbSet<User> Users { get; set; }
    }
}
