using System.ComponentModel.DataAnnotations;

namespace Oma.Api.models.Common
{
    public class StatesModel : BasedModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
