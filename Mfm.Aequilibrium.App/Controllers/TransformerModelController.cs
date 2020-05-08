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
    [Route("api/transformer")]
    public class TransformerModelController : ControllerBase
    {
        private readonly ILogger<TransformerModelController> _logger;
        private readonly ITransformerDomainService _transformerDomainService;

        public TransformerModelController(ITransformerDomainService transformerDomainService, ILogger<TransformerModelController> logger)
        {
            _transformerDomainService = transformerDomainService;
            _logger = logger;
        }

        [HttpPost("create")]
        public async Task<APIRequestResult<string>> CreateTransformer([FromBody] TransformerModel transformerModel)
        {
            try
            {
                await _transformerDomainService.CreateTransformer(transformerModel);
                return new APIRequestResult<string>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }

        [HttpPost("Update")]
        public async Task<APIRequestResult<string>> UpdateTransformer([FromBody] TransformerUpdateModel transformerUpdateModel)
        {
            try
            {
                await _transformerDomainService.UpdateTransformer(transformerUpdateModel);
                return new APIRequestResult<string>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }

        [HttpPost("Delete")]
        public async Task<APIRequestResult<string>> DeleteTransformer([FromBody] TransformerDeleteModel transformerDeleteModel)
        {
            try
            {
                await _transformerDomainService.DeleteTransformer(transformerDeleteModel);
                return new APIRequestResult<string>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<string>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }

        [HttpGet("GetAll")]
        public async Task<APIRequestResult<List<TransformerDisplayModel>>> GetTransformers()
        {
            try
            {
                var list = await _transformerDomainService.GetTransformers();
                return new APIRequestResult<List<TransformerDisplayModel>>
                {
                    Success = true,
                    Data = list
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return new APIRequestResult<List<TransformerDisplayModel>>
                {
                    Success = false,
                    ErrorMessage = "Server error occured."
                };
            }
        }
    }
}
