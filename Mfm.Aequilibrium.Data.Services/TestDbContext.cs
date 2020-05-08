using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mfm.Aequilibrium.Data.Services
{
    public class TestDbContext : DbContext, ITestDbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options) { }

        public void EnsureCreated()
        {
            Database.EnsureCreated();
        }
        public DbSet<TransformerEntity> Transformers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransformerEntity>().ToTable("Transformer");
        }
    }
}

