using Oma.Api.Common.Exceptions;
using Oma.Data.Models.Vendor;
using Oma.Data.Repository.DAL;

namespace Oma.Data.Queries.Vendor
{
    public class SupplierQueryProcessor : ISupplierQueryProcessor
    {
        private readonly IUnitOfWork _uow;

        public SupplierQueryProcessor(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Supplier> Create(Supplier model)
        {
            _uow.Add(model);
            await _uow.CommitAsync();
            return model;
        }

        public async Task Delete(Guid id)
        {
            var supplier = this.GetQuery().FirstOrDefault(x => x.Id == id);
            if (supplier == null)
            {
                throw new NotFoundException("User is not found");
            }

            if (supplier.IsDeleted) return;

            supplier.IsDeleted = true;
            await _uow.CommitAsync();
        }

        public IQueryable<Supplier> Get()
        {
            var q = _uow.Query<Supplier>().Where(p => !p.IsDeleted);
            return q;
        }

        public Supplier Get(Guid id)
        {
            var category = _uow.Query<Supplier>().FirstOrDefault(p => p.Id == id);
            if (category == null)
            {
                throw new NotFoundException("Category is not found");
            }
            return category;
        }

        public IQueryable<Supplier> GetQuery()
        {
            var q = _uow.Query<Supplier>().Where(p => !p.IsDeleted);
            return q;
        }

        public async Task<Supplier> Update(Guid id, Supplier model)
        {
            var supplier = _uow.Query<Supplier>().FirstOrDefault(x => x.Id == id);
            if (supplier == null)
            {
                throw new NotFoundException("Category not found");
            }

            supplier.Name = model.Name;
            supplier.AddressLine1 = model.AddressLine1;
            supplier.AddressLine2 = model.AddressLine2;
            supplier.PostalCode = model.PostalCode;
            supplier.City = model.City;
            supplier.StateId = model.StateId;

            await _uow.CommitAsync();
            return supplier;
        }

    }
}
