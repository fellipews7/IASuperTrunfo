using Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Attribute = Domain.Model.Attribute;

namespace Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }
        
        public DbSet<Card> Card { get; set; }
        public DbSet<Attribute> Attribute { get; set; }
        public DbSet<Theme> Theme { get; set; }
        public DbSet<CardHasAttribute> CardsHasAttribute { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserHasCards> UserHasCards { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<GameHasUser> GameHasUser { get; set; }

        public static DatabaseContext ContextNotLazy(int timeOut = 6000, bool autoDetectChanges = false)
        {
            DatabaseContext db = new();
            db.ChangeTracker.AutoDetectChangesEnabled = autoDetectChanges;
            db.ChangeTracker.LazyLoadingEnabled = false;

            db.Database.SetCommandTimeout(timeOut);

            return db;
        }

    }
}
