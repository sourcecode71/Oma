using Oma.Api.models.Common;
using System.ComponentModel.DataAnnotations;

namespace Oma.Api.models.Vendor
{
    public class SupplierModel : BasedModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Name is required"),MaxLength(50,ErrorMessage ="Name max length is 50")]
        public string Name { get; set; }
        [Required(ErrorMessage = "AddressLine1 is required"), MaxLength(255, ErrorMessage = "Addresssline1 max length is 255")]
        public string AddressLine1 { get; set; }
        [Required(ErrorMessage = "AddressLine2 is required"), MaxLength(255, ErrorMessage = "Addresssline2 max length is 255")]
        public string AddressLine2 { get; set; }
        [Required(ErrorMessage = "City is required"), MaxLength(50, ErrorMessage = "City max length is 255")]
        public string City { get; set; }
        [Required(ErrorMessage = "Postal code is required"), MaxLength(50, ErrorMessage = "Postal code length is 50")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "State is required")]
        public string StateId { get; set; }

        public virtual StatesModel States { get; set; }

        public string StateName { get; set; }
    }
}
