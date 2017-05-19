using System.Data.Entity.Infrastructure;

namespace BLS.Data.BLDbContext
{
    public class BlDbContextFactory : IDbContextFactory<BlDbContext>
    {
        public BlDbContext Create()
        {
            return new BlDbContext("BookConnectionString");
        }
    }
}
