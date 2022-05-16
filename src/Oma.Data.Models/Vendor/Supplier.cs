using Oma.Data.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace Oma.Data.Models.Vendor
{
    public class Supplier : BasedEntity
    {
        [Key]
        public Guid Id { get; set; }
       
        [Required,StringLength(50)]
        public string Name { get; set; }
       
        [Required, StringLength(255)]
        public string AddressLine1 { get; set; }
       
        [Required, StringLength(255)]
        public string AddressLine2 { get; set; }
       
        [Required,  StringLength(100)]
        public string City { get; set; }
       
        [Required,  StringLength(10)]
        public string PostalCode { get; set; }
       
        [Required]
        public int StateId { get; set; }
        public  States States { get; set; }
    }
}
