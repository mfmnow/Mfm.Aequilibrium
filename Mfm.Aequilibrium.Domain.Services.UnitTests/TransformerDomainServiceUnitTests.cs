using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Mfm.Aequilibrium.Domain.Services.UnitTests.MockProviders;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Mfm.Aequilibrium.Domain.Services.UnitTests
{
    public class TransformerDomainServiceUnitTests
    {
        private readonly Mock<ITransformerEntityDataAccess> _mockedITransformerEntityDataAccess;
        private readonly Mock<ITransformerMapperDomainService> _mockedITransformerMapperDomainService;
        private readonly Mock<TransformerDomainService> _mockedTransformerDomainService;

        public TransformerDomainServiceUnitTests()
        {
            (_mockedITransformerEntityDataAccess, _mockedITransformerMapperDomainService, _mockedTransformerDomainService) =
                TransformerDomainServiceMockerProvider.GetMocks();
        }

        [Fact]
        public async Task CreateTransformer_Should_Follow_LogicalFlow_On_Valid_Empty_Model()
        {
            await _mockedTransformerDomainService.Object.CreateTransformer(TransformerDomainServiceMockerProvider.MockedTransformerModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.CreateTransformerEntity(It.IsAny<string>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), ""), Times.Once);
        }

        [Fact]
        public async Task CreateTransformer_Should_Calculate_OverallRating_Correctly()
        {
            await _mockedTransformerDomainService.Object.CreateTransformer(TransformerDomainServiceMockerProvider.MockedTransformerModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.CreateTransformerEntity(It.IsAny<string>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), TransformerDomainServiceMockerProvider.MockedOverallRating, ""), Times.Once);
        }

        [Fact]
        public async Task CreateTransformer_Should_Calculate_ExpectedTypeByte_Correctly()
        {
            await _mockedTransformerDomainService.Object.CreateTransformer(TransformerDomainServiceMockerProvider.MockedTransformerModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.CreateTransformerEntity(It.IsAny<string>(),
                TransformerDomainServiceMockerProvider.ExpectedTypeByte, It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), ""), Times.Once);
        }

        [Fact]
        public async Task UpdateTransformer_Should_Follow_LogicalFlow_On_Valid_Empty_Model()
        {
            await _mockedTransformerDomainService.Object.UpdateTransformer(TransformerDomainServiceMockerProvider.MockedTransformerUpdateModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.UpdateTransformerEntity(It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), ""), Times.Once);
        }

        [Fact]
        public async Task UpdateTransformer_Should_Calculate_OverallRating_Correctly()
        {
            await _mockedTransformerDomainService.Object.UpdateTransformer(TransformerDomainServiceMockerProvider.MockedTransformerUpdateModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.UpdateTransformerEntity(It.IsAny<int>(), It.IsAny<string>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), TransformerDomainServiceMockerProvider.MockedOverallRating, ""), Times.Once);
        }

        [Fact]
        public async Task UpdateTransformer_Should_Calculate_ExpectedTypeByte_Correctly()
        {
            await _mockedTransformerDomainService.Object.UpdateTransformer(TransformerDomainServiceMockerProvider.MockedTransformerUpdateModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.UpdateTransformerEntity(It.IsAny<int>(), It.IsAny<string>(),
                TransformerDomainServiceMockerProvider.ExpectedTypeByte, It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(),
                It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), It.IsAny<byte>(), ""), Times.Once);
        }

        [Fact]
        public async Task DeleteTransformer_Should_Follow_LogicalFlow_On_Valid_Empty_Model()
        {
            await _mockedTransformerDomainService.Object.DeleteTransformer(TransformerDomainServiceMockerProvider.MockedTransformerDeleteModel);

            _mockedITransformerEntityDataAccess.Verify(t => t.DeleteTransformerEntityById
            (TransformerDomainServiceMockerProvider.MockedTransformerDeleteModel.Id), Times.Once);
        }
    }
}