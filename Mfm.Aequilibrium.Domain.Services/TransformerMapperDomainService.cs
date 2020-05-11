using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Mfm.Aequilibrium.Domain.Models.Enums;

namespace Mfm.Aequilibrium.Domain.Services
{
    public class TransformerMapperDomainService : ITransformerMapperDomainService
    {
        public TransformerDisplayModel TransformerEntityToTransformerDisplayModel(TransformerEntity transformerEntity)
        {
            return new TransformerDisplayModel
            {
                Courage = transformerEntity.Courage,
                Endurance = transformerEntity.Endurance,
                Firepower = transformerEntity.Firepower,
                Id = transformerEntity.Id,
                Intelligence = transformerEntity.Intelligence,
                Name = transformerEntity.Name,
                Rank = transformerEntity.Rank,
                Speed = transformerEntity.Speed,
                Strength = transformerEntity.Strength,
                TypeEnum = (TransformerType)transformerEntity.Type,
                Type = char.Parse(((TransformerType)transformerEntity.Type).ToString()),
                Skill = transformerEntity.Skill,
                OverallRating = transformerEntity.OverallRating
            };
        }

        public TransformerBattleModel TransformerEntityToTransformerBattleModel(TransformerEntity transformerEntity)
        {
            return new TransformerBattleModel
            {
                Courage = transformerEntity.Courage,
                Id = transformerEntity.Id,
                Name = transformerEntity.Name,
                Strength = transformerEntity.Strength,
                Skill = transformerEntity.Skill,
                OverallRating = transformerEntity.OverallRating,
                TransformerType = (TransformerType)transformerEntity.Type,
                TransformerBattleStatus = TransformerBattleStatus.DidNotBattle,
                Rank = transformerEntity.Rank
            };
        }
    }
}
