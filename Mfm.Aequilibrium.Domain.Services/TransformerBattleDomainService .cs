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
            var autobots = allTransformersEntities.Where(t => t.Type == (byte)TransformerType.A).OrderBy(t => t.Rank).ToList();
            var decepticons = allTransformersEntities.Where(t => t.Type == (byte)TransformerType.D).OrderBy(t => t.Rank).ToList();

            var smallerTeamCount = autobots.Count <= decepticons.Count ? autobots.Count : decepticons.Count;
            var autobotsWins = 0;
            var decepticonsWins = 0;
            for (var i = 0; i < smallerTeamCount; i++) {
                try
                {
                    await GetBattleWinner(autobots[i], decepticons[i], ref autobotsWins, ref decepticonsWins);
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
            var winner = autobotsWins > decepticonsWins ? char.Parse(TransformerType.A.ToString()) :
                decepticonsWins > autobotsWins ? char.Parse(TransformerType.D.ToString()) : '\0';
            var survivorsFromTheLosingTeam = new List<TransformerDisplayModel>();
            if (autobotsWins > decepticonsWins && decepticons.Count > autobots.Count) 
            {
                survivorsFromTheLosingTeam = decepticons.Skip(Math.Max(0, decepticons.Count() - smallerTeamCount)).
                    Select(e => {
                    return _transformerMapperDomainService.TransformerEntityToTransformerDisplayModel(e);
                }).ToList();
            }
            else if (decepticonsWins > autobotsWins && autobots.Count > decepticons.Count)
            {
                survivorsFromTheLosingTeam = autobots.Skip(Math.Max(0, autobots.Count() - smallerTeamCount)).
                    Select(e => {
                        return _transformerMapperDomainService.TransformerEntityToTransformerDisplayModel(e);
                    }).ToList();
            }
            return new TransformerBattleResultModel { 
                NumberOfBattles = smallerTeamCount,
                SurvivorsFromTheLosingTeam = survivorsFromTheLosingTeam,
                Winner = winner
            };
        }

        public Task GetBattleWinner(TransformerEntity autobotsTransformer, TransformerEntity decepticonsTransformer,
            ref int autobotsWins, ref int decepticonsWins)
        {
            if (_appSettings.WildCardNames.Contains(autobotsTransformer.Name) &&
                _appSettings.WildCardNames.Contains(decepticonsTransformer.Name))
            {
                throw new InvalidBattleException("Two WildCardNames met each other");
            }
            else if (_appSettings.WildCardNames.Contains(autobotsTransformer.Name)) {
                autobotsWins++;
            }
            else if (_appSettings.WildCardNames.Contains(decepticonsTransformer.Name))
            {
                decepticonsWins++;
            }
            else if (autobotsTransformer.Courage >= decepticonsTransformer.Courage + 4
                && autobotsTransformer.Strength >= decepticonsTransformer.Courage + 3)
            {
                autobotsWins++;
            }
            else if (decepticonsTransformer.Courage >= autobotsTransformer.Courage + 4
                && decepticonsTransformer.Strength >= autobotsTransformer.Courage + 3)
            {
                decepticonsWins++;
            }
            else if (autobotsTransformer.Skill >= decepticonsTransformer.Courage + 3)
            {
                autobotsWins++;
            }
            else if (decepticonsTransformer.Skill >= autobotsTransformer.Courage + 3)
            {
                decepticonsWins++;
            }
            else
            {
                if (autobotsTransformer.OverallRating > decepticonsTransformer.OverallRating)
                {
                    autobotsWins++;
                }
                if (decepticonsTransformer.OverallRating > autobotsTransformer.OverallRating)
                {
                    decepticonsWins++;
                }
            }
            return Task.CompletedTask;
        }
    }
}
