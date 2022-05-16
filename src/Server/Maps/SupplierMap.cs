using AutoMapper;
using Oma.Api.models.Vendor;
using Oma.Data.Models.Vendor;

namespace Oma.Server.Maps
{
    public class SupplierMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Supplier, SupplierModel>();
            configuration.CreateMap<CreateUpdateSupplierModel, Supplier>();
        }
    }
}
