using AutoMapper;
using Oma.Api.models.Common;
using Oma.Data.Models.Common;

namespace Oma.Server.Maps
{
    public class StateMap : IAutoMapperTypeConfigurator
    {
        public void Configure(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<States, StatesModel>();
        }
    }
}
