using Mfm.Aequilibrium.Data.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Mfm.Aequilibrium.Data.Services.UnitTests.MockProviders
{
    internal class TransformerEntityDataAccessMockerProvider
    {
        public static IQueryable<TransformerEntity> GetMockedData()
        {
            return new List<TransformerEntity>
            {
                new TransformerEntity()
            }.AsQueryable();
        }

        public static Mock<TransformerEntityDataAccess> GetMockedDataAccessService()
        {
            var mockedDbContext = TestDbContextMockerProvider.GetMockedTestDbContext<TestDbContext, TransformerEntity>(GetMockedData());
            var mockedDataAccessSerice = new Mock<TransformerEntityDataAccess>(mockedDbContext.Object) { CallBase = true };
            mockedDataAccessSerice =
               TestDbContextMockerProvider.SetupDataAccessServices<TransformerEntityDataAccess, TransformerEntity>
               (mockedDataAccessSerice, GetMockedData());
            return mockedDataAccessSerice;
        }
    }
}
