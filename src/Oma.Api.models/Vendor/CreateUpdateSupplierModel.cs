using Oma.Api.models.Common;
using System.ComponentModel.DataAnnotations;

namespace Oma.Api.models.Vendor
{
    public class CreateUpdateSupplierModel : BasedModel
    {
       
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string AddressLine1 { get; set; }

        [Required, MaxLength(255)]
        public string AddressLine2 { get; set; }

        [Required, MaxLength(100)]
        public string City { get; set; }

        [Required, MaxLength(10)]
        public string PostalCode { get; set; }

        public string StateId { get; set; }
    }
}
