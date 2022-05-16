using Oma.Data.Models.Vendor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oma.Data.Queries.Vendor
{
    public interface ISupplierQueryProcessor
    {
        IQueryable<Supplier> GetQuery();
        IQueryable<Supplier> Get();
        Supplier Get(Guid id);
        Task<Supplier> Create(Supplier model);
        Task<Supplier> Update(Guid id, Supplier model);
        Task Delete(Guid id);
    }
}
