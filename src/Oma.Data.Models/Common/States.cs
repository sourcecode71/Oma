using Oma.Data.Models.Vendor;
using System.ComponentModel.DataAnnotations;

namespace Oma.Data.Models.Common
{
    public class States :BasedEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(2)]
        public string Code { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }
        public ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
