﻿using System.Data.Entity;
using Moshavit.Entity;
using Moshavit.Entity.EntityTable;
using Moshavit.Entity.TableEntity;

namespace Moshavit.DataBase
{
    public class Context : DbContext
    {
        public Context()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
        }

        public DbSet<UserTable> Users { get; set; }
        public DbSet<MessageTable> Messages { get; set; }
    }
}
