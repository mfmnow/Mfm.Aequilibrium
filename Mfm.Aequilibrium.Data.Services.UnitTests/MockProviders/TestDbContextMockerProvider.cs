using Mfm.Aequilibrium.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Data.Services.UnitTests.MockProviders
{
    public class TestDbContextMockerProvider
    {
        public static Mock<TDBContext> GetMockedTestDbContext<TDBContext, TEntity>(IQueryable<TEntity> data)
            where TEntity : class
            where TDBContext : DbContext
        {
            var mockedDbSet = new Mock<DbSet<TEntity>>();
            mockedDbSet
                .As<IQueryable<TEntity>>()
                .Setup(m => m.GetEnumerator())
                .Returns(data.GetEnumerator());

            var dbContext = new Mock<TDBContext>(new DbContextOptions<TDBContext>());
            dbContext
                .Setup(f => f.Set<TEntity>())
                .Returns(mockedDbSet.Object);

            return dbContext;
        }

        public static Mock<TGenericDataAccessService>
            SetupDataAccessServices<TGenericDataAccessService, TEntity>(Mock<TGenericDataAccessService> mockedDataAccessService,
            IQueryable<TEntity> mockedData)
            where TEntity : BaseEntity
            where TGenericDataAccessService : GenericRepository<TEntity>
        {
            mockedDataAccessService.Setup(m => m.Create(It.IsAny<TEntity>()))
                .Returns(Task.CompletedTask);
            return mockedDataAccessService;
        }
    }
}
