using Costumer_Loan.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Costumer_Loan.Entities
{
    public class Loan
    {
        [Key]
        public int? LoanId { get; set; }
        [Required]
        public int? Amount { get; set; }
        public LoanStatus? Status { get; set; }
        public bool? isDeleted { get; set; } = false;
        public int? CostumerId { get; set; }
        [ForeignKey("CostumerId")]
        public Costumer? Costumer { get; set; }
    }
}
