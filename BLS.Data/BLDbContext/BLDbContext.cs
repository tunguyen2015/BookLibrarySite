using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using BLS.Core;
using BLS.Core.Data;
using BLS.Data.Infrastructure;

namespace BLS.Data.BLDbContext
{
    public class BlDbContext : DbContext, IBlDbContext
    {
        static BlDbContext()
        {
           Database.SetInitializer<BlDbContext>(null);
        }

        public BlDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public IDbSet<Book> Books { get; set; }
        public IDbSet<User> Users { get; set; }
        public IDbSet<UserProfile> Profiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                               type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            base.OnModelCreating(modelBuilder);
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity<int>
        {
            return base.Set<TEntity>();
        }
    }
}
