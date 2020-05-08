using Mfm.Aequilibrium.Data.Contracts;

namespace Mfm.Aequilibrium.Data.Services
{
    public class DbInitializer: IDbInitializer
    {
        private readonly ITestDbContext _context;
        public DbInitializer(ITestDbContext testDbContext)
        {
            _context = testDbContext;
        }
        public void Initialize()
        {
            _context.EnsureCreated();
        }
    }
}
