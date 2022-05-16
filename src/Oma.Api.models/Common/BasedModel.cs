using System.ComponentModel.DataAnnotations;

namespace Oma.Api.models.Common
{
    public class BasedModel
    {
        [MaxLength(50)]
        public string SetUser { get; set; } = "Admin";
        public DateTime SetDate { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }=false;
    }
}
