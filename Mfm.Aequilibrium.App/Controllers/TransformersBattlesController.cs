using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mfm.Aequilibrium.App.Models;
using Mfm.Aequilibrium.Domain.Contracts;
using Mfm.Aequilibrium.Domain.Models;
using Mfm.Aequilibrium.Domain.Models.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Mfm.Aequilibrium.App.Controllers
{
    [ApiController]
    [Route("api/transformers-battles")]
    public class TransformersBattlesController : ControllerBase
    {
        private readonly ILogger<TransformerModelController> _logger;
        private readonly ITransformerBattleDomainService _transformerBattleDomainService;

        public TransformersBattlesController(ITransformerBattleDomainService transformerBattleDomainService, ILogger<TransformerModelController> logger)
        {
            _transformerBattleDomainService = transformerBattleDomainService;
            _logger = logger;
        }

        [HttpPost("get-result")]
        public async Task<APIRequestResult<TransformerBattleResultModel>> CreateTestModel([FromBody] List<int> transformersIds)
        {
            try
            {
                var result = await _transformerBattleDomainService.GetTransformersBattleResult(transformersIds);
                return new APIRequestResult<TransformerBattleResultModel>
                {
                    Success = true,                    
                    Data = result
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<TransformerBattleResultModel>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }
    }
}
