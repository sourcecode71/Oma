using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oma.Api.models.Common;
using Oma.Data.Models.Common;
using Oma.Data.Queries.Common;
using Oma.Server.Maps;

namespace Oma.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateQueryProcessor _query;
        private readonly ILogger<SupplierController> _logger;
        private readonly IAutoMapper _mapper;



        public StatesController(ILogger<SupplierController> logger, IStateQueryProcessor query, IAutoMapper autoMapper)
        {
            _logger = logger;
            _mapper = autoMapper;
            _query = query;
        }

        [HttpGet]
        public IQueryable<StatesModel> Get()
        {
            var result = _query.Get();
            var models = _mapper.Map<States, StatesModel>(result);
            return models;
        }

    }
}
