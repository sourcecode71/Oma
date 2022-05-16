using System.ComponentModel.DataAnnotations;

namespace Oma.Data.Models
{
    public class BasedEntity
    {
        [StringLength(50)]
        public string SetUser { get; set; }
        public DateTime SetDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
