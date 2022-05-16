using Oma.Data.Models.Common;

namespace Oma.Data.Queries.Common
{
    public interface IStateQueryProcessor
    {
        IQueryable<States> Get();
        States Get(Guid id);
    }
}
