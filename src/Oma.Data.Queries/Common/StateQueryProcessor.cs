using Oma.Data.Models.Common;
using Oma.Data.Repository.DAL;

namespace Oma.Data.Queries.Common
{
    public class StateQueryProcessor : IStateQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public StateQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public IQueryable<States> Get()
        {
           var q=_uow.Query<States>().Where(p=>p.IsDeleted==false);
            return q;
        }

        public States Get(Guid id)
        {
            var q = _uow.Query<States>().FirstOrDefault(p => p.IsDeleted==false);
            return q;
        }
    }
}
