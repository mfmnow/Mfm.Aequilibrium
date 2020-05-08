using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Moq;

namespace Mfm.Aequilibrium.Domain.Services.UnitTests.MockProviders
{
    internal class TransformerDomainServiceMockerProvider
    {
        public static (Mock<ITransformerEntityDataAccess>, Mock<ITransformerMapperDomainService>, 
             Mock<TransformerDomainService>) GetMocks()
        {

            var mockedITransformerEntityDataAccess = new Mock<ITransformerEntityDataAccess>();
            var mockedITransformerMapperDomainService = new Mock<ITransformerMapperDomainService>();
            var mockedTransformerDomainService = new Mock<TransformerDomainService>(mockedITransformerEntityDataAccess.Object,
                mockedITransformerMapperDomainService.Object)
            { CallBase = true };

            return (mockedITransformerEntityDataAccess, mockedITransformerMapperDomainService, mockedTransformerDomainService);
        }

        public static TransformerModel MockedTransformerModel = new TransformerModel
        {
            Courage = 1,
            Endurance = 2,
            Firepower = 3,
            Intelligence = 5,
            Name = "Name",
            Rank = 7,
            Skill = 8,
            Speed = 9,
            Strength = 10,
            Type = 'A'
        };

        public static TransformerUpdateModel MockedTransformerUpdateModel = new TransformerUpdateModel
        {
            Courage = 1,
            Endurance = 2,
            Firepower = 3,
            Intelligence = 5,
            Name = "Name",
            Rank = 7,
            Skill = 8,
            Speed = 9,
            Strength = 10,
            Type = 'A'
        };

        public static TransformerDeleteModel MockedTransformerDeleteModel = new TransformerDeleteModel
        {
            Id = 1
        };

        public static byte MockedOverallRating = 29;
        public static byte ExpectedTypeByte = (byte)Models.Enums.TransformerType.A;
    }
}