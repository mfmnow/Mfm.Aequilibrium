using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Data.Services.UnitTests.MockProviders;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Aequilibrium.Data.Services.UnitTests.Services
{
    public class TransformerEntityDataAccessServiceUnitTests
    {
        private readonly Mock<TransformerEntityDataAccess> _transformerEntityDataAccess;

        public TransformerEntityDataAccessServiceUnitTests()
        {
            _transformerEntityDataAccess = TransformerEntityDataAccessMockerProvider.GetMockedDataAccessService();
        }

        [Fact]
        public async Task CreateTransformerEntity_Should_Follow_LogicalFlow()
        {
            await _transformerEntityDataAccess.Object.CreateTransformerEntity(It.IsAny<string>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), "");

            _transformerEntityDataAccess.Verify(t => t.Create(It.IsAny<TransformerEntity>()), Times.Once);
        }

        [Fact]
        public async Task UpdateTransformerEntity_Should_Follow_LogicalFlow()
        {
            _transformerEntityDataAccess.Setup(t => t.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(new TransformerEntity
                {
                    Id = 0
                }));
            await _transformerEntityDataAccess.Object.UpdateTransformerEntity(It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), "");

            _transformerEntityDataAccess.Verify(t => t.Update(It.IsAny<TransformerEntity>()), Times.Once);
            _transformerEntityDataAccess.Verify(t => t.GetById(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public async Task DeleteTransformerEntityById_Should_Follow_LogicalFlow()
        {
            _transformerEntityDataAccess.Setup(t => t.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(new TransformerEntity
                {
                    Id = 0
                }));
            await _transformerEntityDataAccess.Object.DeleteTransformerEntityById(It.IsAny<int>());

            _transformerEntityDataAccess.Verify(t => t.Delete(It.IsAny<int>()), Times.Once);
        }
    }
}
