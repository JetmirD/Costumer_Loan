using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Costumer_Loan.Entities
{
    public class Costumer
    {
        [Key]
        public int? CostumerId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; } = false;
        [JsonIgnore]
        public ICollection<Loan>? Loans { get; set; }
    }
}
