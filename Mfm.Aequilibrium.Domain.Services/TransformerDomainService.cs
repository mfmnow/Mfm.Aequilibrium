using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Mfm.Aequilibrium.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Domain.Services
{
    public class TransformerDomainService : ITransformerDomainService
    {
        private readonly ITransformerEntityDataAccess _transformerEntityDataAccess;
        private readonly ITransformerMapperDomainService _transformerMapperDomainService;

        public TransformerDomainService(ITransformerEntityDataAccess transformerEntityDataAccess
            , ITransformerMapperDomainService transformerMapperDomainService) 
        {
            _transformerEntityDataAccess = transformerEntityDataAccess;
            _transformerMapperDomainService = transformerMapperDomainService;
        }

        public async Task CreateTransformer(TransformerModel transformerModel) 
        {
            var overallRating = transformerModel.Strength + transformerModel.Intelligence + transformerModel.Speed +
                transformerModel.Endurance + transformerModel.Firepower;
            transformerModel.TypeEnum = (TransformerType) Enum.Parse(typeof(TransformerType), transformerModel.Type.ToString());
            await _transformerEntityDataAccess.CreateTransformerEntity(transformerModel.Name,
                (byte)transformerModel.TypeEnum, transformerModel.Strength, transformerModel.Intelligence, transformerModel.Speed,
                transformerModel.Endurance, transformerModel.Rank, transformerModel.Courage, transformerModel.Firepower,
                transformerModel.Skill, (byte)overallRating, "");
        }

        public async Task UpdateTransformer(TransformerUpdateModel transformerModel)
        {
            var overallRating = transformerModel.Strength + transformerModel.Intelligence + transformerModel.Speed +
                transformerModel.Endurance + transformerModel.Firepower;
            transformerModel.TypeEnum = (TransformerType)Enum.Parse(typeof(TransformerType), transformerModel.Type.ToString());
            await _transformerEntityDataAccess.UpdateTransformerEntity(transformerModel.Id, transformerModel.Name,
                (byte)transformerModel.TypeEnum, transformerModel.Strength, transformerModel.Intelligence, transformerModel.Speed,
                transformerModel.Endurance, transformerModel.Rank, transformerModel.Courage, transformerModel.Firepower,
                transformerModel.Skill, (byte)overallRating, "");
        }

        public async Task DeleteTransformer(TransformerDeleteModel transformerDeleteModel)
        {
            await _transformerEntityDataAccess.DeleteTransformerEntityById(transformerDeleteModel.Id);
        }

        public async Task<List<TransformerDisplayModel>> GetTransformers()
        {
            var allEntities = await _transformerEntityDataAccess.GetTransformerEntities();
            return allEntities.Select(e => {
                return _transformerMapperDomainService.TransformerEntityToTransformerDisplayModel(e);
            }).ToList();
        }
    }
}
