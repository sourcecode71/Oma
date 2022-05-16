using Microsoft.AspNetCore.Mvc;
using Oma.Api.models.Vendor;
using Oma.Data.Models.Vendor;
using Oma.Data.Queries.Vendor;
using Oma.Server.Filter;
using Oma.Server.Maps;

namespace Oma.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierQueryProcessor _query;
        private readonly ILogger<SupplierController> _logger;
        private readonly IAutoMapper _mapper;

        public SupplierController(ILogger<SupplierController> logger,ISupplierQueryProcessor supplierQuery,IAutoMapper autoMapper )
        {
            _logger = logger;
            _query = supplierQuery;
            _mapper = autoMapper;
        }

        [HttpGet]
        public IQueryable<SupplierModel> Get()
        {
            var result = _query.Get();
            var models = _mapper.Map<Supplier, SupplierModel>(result);
            return models;
        }

        [HttpGet("{id}")]
        public SupplierModel Get(Guid id)
        {
            var item = _query.Get(id);
            var model = _mapper.Map<SupplierModel>(item);
            return model;
        }

        [HttpPost]
        [ValidateModel]
        public async Task<SupplierModel> Post([FromBody] CreateUpdateSupplierModel requestModel)
        {
            var supplier = _mapper.Map<Supplier>(requestModel);
            var item = await _query.Create(supplier);
            var model = _mapper.Map<SupplierModel>(item);
            return model;
        }

        [HttpPut("{id}")]
        [ValidateModel]
        public async Task<SupplierModel> Put(Guid id, [FromBody] CreateUpdateSupplierModel requestModel)
        {
            _logger.LogInformation("Update operaation call for the ID ", id);
            var supplier = _mapper.Map<Supplier>(requestModel);
            var item = await _query.Update(id, supplier);
            var model = _mapper.Map<SupplierModel>(item);
            _logger.LogInformation("Update operaation done for the ID ", id);
            return model;
        }

        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            _logger.LogInformation("Delete operaation call for the ID ", id);
            await _query.Delete(id);
        }


    }
}
