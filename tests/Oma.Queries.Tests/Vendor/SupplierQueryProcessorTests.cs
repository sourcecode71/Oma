using Moq;
using System;
using Xunit;
using System.Collections.Generic;
using Oma.Data.Repository.DAL;
using System.Linq;
using Oma.Data.Queries.Vendor;
using FluentAssertions;
using Oma.Data.Models.Vendor;
using Oma.Api.Common.Exceptions;

namespace Oma.Queries.Tests.Vendor
{
   
    public class SupplierQueryProcessorTests
    {
        private Mock<IUnitOfWork> _uow;
        private List<Supplier> _supplierList;
        private ISupplierQueryProcessor _query;
        private Random _random;

        public SupplierQueryProcessorTests()
        {
            _uow = new Mock<IUnitOfWork>();
            _supplierList = new List<Supplier>();
            _uow.Setup(x => x.Query<Supplier>()).Returns(() => _supplierList.AsQueryable());
            _query = new SupplierQueryProcessor(_uow.Object);
            _random = new Random();
        }

        [Fact]
        public void GetShouldReturnAll()
        {
            _supplierList.Add(new Supplier { Id = Guid.NewGuid() });
            var result = _query.Get().ToList();
            result.Count.Should().Be(1);
        }

        [Fact]
        public void GetShouldReturnAllActiveCategories()
        {
            _supplierList.Add(new Supplier { Id = Guid.NewGuid(), IsDeleted = false });
            _supplierList.Add(new Supplier { Id = Guid.NewGuid(), IsDeleted = true });
            var result = _query.GetQuery().ToList();
            result.Count.Should().Be(1);
        }

        [Fact]
        public void GetShouldReturnOnlySupplierIdWise()
        {
            Guid guid = Guid.NewGuid();
            _supplierList.Add(new Supplier { Id = Guid.NewGuid() });
            _supplierList.Add(new Supplier { Id = guid });
            var result = _query.Get(guid);
            result.Id.Should().Be(result.Id);
        }

        [Fact]
        public async void CreateShouldSaveNew()
        {
            var supplier = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                AddressLine1 = _random.Next().ToString(),
                AddressLine2 = _random.Next().ToString(),
                City = _random.Next().ToString(),
                PostalCode = _random.Next().ToString()
            };

            var result = await _query.Create(supplier);

            result.Id.Should().Be(supplier.Id);
            result.Name.Should().Be(supplier.Name);
            result.AddressLine1.Should().Be(supplier.AddressLine1);
            result.AddressLine2.Should().Be(supplier.AddressLine2);
            result.City.Should().Be(supplier.City);
            result.PostalCode.Should().Be(supplier.PostalCode);

            _uow.Verify(x => x.Add(result));
            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public async void UpdateShouldUpdateFields()
        {
            var supplier = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                AddressLine1 = _random.Next().ToString(),
                AddressLine2 = _random.Next().ToString(),
                City = _random.Next().ToString(),
                PostalCode = _random.Next().ToString()
            };

            _supplierList.Add(supplier);

            var supplierModel = new Supplier
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                AddressLine1 = _random.Next().ToString(),
                AddressLine2 = _random.Next().ToString(),
                City = _random.Next().ToString(),
                PostalCode = _random.Next().ToString()
            };

            var result = await _query.Update(supplier.Id, supplierModel);

            result.Name.Should().Be(result.Name);
            result.AddressLine1.Should().Be(result.AddressLine1);
            result.AddressLine2.Should().Be(result.AddressLine2);
            result.City.Should().Be(result.City);
            result.PostalCode.Should().Be(result.PostalCode);

            _uow.Verify(x => x.CommitAsync());
        }

        [Fact]
        public void UpdateShoudlThrowExceptionIfItemIsNotFound()
        {
            Action create = () =>
            {
                var result = _query.Update(Guid.NewGuid(), new Supplier()).Result;
            };

            create.Should().Throw<NotFoundException>();
        }

    }
}
