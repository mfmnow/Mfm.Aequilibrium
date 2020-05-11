using Mfm.Aequilibrium.Data.Contracts;
using Mfm.Aequilibrium.Data.Entities;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Mfm.Aequilibrium.Domain.Models.Enums;
using Mfm.Aequilibrium.Domain.Models.Exceptions;
using Mfm.Aequilibrium.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mfm.Aequilibrium.Domain.Services
{
    public class TransformerBattleDomainService : ITransformerBattleDomainService
    {
        private readonly ITransformerEntityDataAccess _transformerEntityDataAccess;
        private readonly AppSettings _appSettings;
        private readonly ITransformerMapperDomainService _transformerMapperDomainService;

        public TransformerBattleDomainService(ITransformerEntityDataAccess transformerEntityDataAccess,
            AppSettings appSettings, ITransformerMapperDomainService transformerMapperDomainService) 
        {
            _transformerEntityDataAccess = transformerEntityDataAccess;
            _appSettings = appSettings;
            _transformerMapperDomainService = transformerMapperDomainService;
        }

        public async Task<TransformerBattleResultModel> GetTransformersBattleResult(List<int> transformersIds) 
        {
            var allTransformersEntities = await _transformerEntityDataAccess.GetTransformerEntitiesByIds(transformersIds);
            var allTransformerBattleModels = allTransformersEntities.Select(t => 
            { 
                return _transformerMapperDomainService.TransformerEntityToTransformerBattleModel(t); 
            }
            ).ToList();
            var autobots = allTransformerBattleModels.Where(t => t.TransformerType == TransformerType.A)
                .OrderBy(t => t.Rank).ToList();
            var decepticons = allTransformerBattleModels.Where(t => t.TransformerType == TransformerType.D)
                .OrderBy(t => t.Rank).ToList();

            var smallerTeamCount = autobots.Count <= decepticons.Count ? autobots.Count : decepticons.Count;
            var losersList = new List<int>();
            for (var i = 0; i < smallerTeamCount; i++) {
                try
                {
                    var winnerTransformer = await GetBattleWinner(autobots[i], decepticons[i]);
                    MarkAsWinner(autobots[i], decepticons[i], winnerTransformer);
                }
                catch (InvalidBattleException ex) {
                    return new TransformerBattleResultModel
                    {
                        Winner = '\0',
                        SurvivorsFromTheLosingTeam = null,
                        NumberOfBattles = 0
                    };
                }
            }
            var autobotsWins = autobots.Where(t => t.TransformerBattleStatus == TransformerBattleStatus.Winned).Count();
            var decepticonsWins = decepticons.Where(t => t.TransformerBattleStatus == TransformerBattleStatus.Winned).Count();
            var winner = autobotsWins > decepticonsWins ? char.Parse(TransformerType.A.ToString()) :
                decepticonsWins > autobotsWins ? char.Parse(TransformerType.D.ToString()) : '\0';
            var survivorsFromTheLosingTeam = new List<TransformerDisplayModel>();
            if (autobotsWins > decepticonsWins) 
            {
                survivorsFromTheLosingTeam = decepticons.Where(t => t.TransformerBattleStatus != TransformerBattleStatus.Losed).
                    Select(e => {
                        var entity = allTransformersEntities.Where(en => en.Id == e.Id).FirstOrDefault();
                        return _transformerMapperDomainService.TransformerEntityToTransformerDisplayModel(entity);
                }).ToList();
            }
            else if (decepticonsWins > autobotsWins)
            {
                survivorsFromTheLosingTeam = autobots.Where(t => t.TransformerBattleStatus != TransformerBattleStatus.Losed).
                    Select(e => {
                        var entity = allTransformersEntities.Where(en => en.Id == e.Id).FirstOrDefault();
                        return _transformerMapperDomainService.TransformerEntityToTransformerDisplayModel(entity);
                    }).ToList();
            }
            return new TransformerBattleResultModel { 
                NumberOfBattles = smallerTeamCount,
                SurvivorsFromTheLosingTeam = survivorsFromTheLosingTeam,
                Winner = winner
            };
        }

        public Task<TransformerType> GetBattleWinner(TransformerBattleModel autobotsTransformer, TransformerBattleModel decepticonsTransformer)
        {
            if (_appSettings.WildCardNames.Contains(autobotsTransformer.Name) &&
                _appSettings.WildCardNames.Contains(decepticonsTransformer.Name))
            {
                throw new InvalidBattleException("Two WildCardNames met each other");
            }
            else if (_appSettings.WildCardNames.Contains(autobotsTransformer.Name)) {
                return Task.FromResult(TransformerType.A);
            }
            else if (_appSettings.WildCardNames.Contains(decepticonsTransformer.Name))
            {
                return Task.FromResult(TransformerType.D);
            }
            else if (autobotsTransformer.Courage >= decepticonsTransformer.Courage + 4
                && autobotsTransformer.Strength >= decepticonsTransformer.Strength + 3)
            {
                return Task.FromResult(TransformerType.A);
            }
            else if (decepticonsTransformer.Courage >= autobotsTransformer.Courage + 4
                && decepticonsTransformer.Strength >= autobotsTransformer.Strength + 3)
            {
                return Task.FromResult(TransformerType.D);
            }
            else if (autobotsTransformer.Skill >= decepticonsTransformer.Skill + 3)
            {
                return Task.FromResult(TransformerType.A);
            }
            else if (decepticonsTransformer.Skill >= autobotsTransformer.Skill + 3)
            {
                return Task.FromResult(TransformerType.D);
            }
            else
            {
                if (autobotsTransformer.OverallRating > decepticonsTransformer.OverallRating)
                {
                    return Task.FromResult(TransformerType.A);
                }
                if (decepticonsTransformer.OverallRating > autobotsTransformer.OverallRating)
                {
                    return Task.FromResult(TransformerType.D);
                }
            }
            return null;
        }

        public void MarkAsWinner(TransformerBattleModel autobotsTransformer, TransformerBattleModel decepticonsTransformer,
            TransformerType transformerType)
        {
            autobotsTransformer.TransformerBattleStatus = transformerType == TransformerType.A ? 
                TransformerBattleStatus.Winned : TransformerBattleStatus.Losed;
            decepticonsTransformer.TransformerBattleStatus = transformerType == TransformerType.D ?
                TransformerBattleStatus.Winned : TransformerBattleStatus.Losed;
        }
    }
}
