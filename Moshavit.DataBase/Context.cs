using System.Data.Entity;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.TableEntity;

namespace Moshavit.DataBase
{
    public class Context : DbContext
    {
        public Context()
            : base("MoshavitDb")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<UserTable> Users { get; set; }
        public DbSet<MessageTable> Messages { get; set; }
        public DbSet<SurveyTable> Survey { get; set; }
        public DbSet<VotingLIstTable> VoterLIsts { get; set; }
    }
}
