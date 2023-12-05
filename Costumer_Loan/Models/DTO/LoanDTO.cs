using Costumer_Loan.Entities;
using Costumer_Loan.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Costumer_Loan.Models.DTO
{
    public class LoanDTO
    {
        [Key]
        public int? LoanId { get; set; }
        [Required]
        public int? Amount { get; set; }
        public LoanStatus? Status { get; set; }
        public int? CostumerId { get; set; }
        [ForeignKey("CostumerId")]
        public Costumer? Costumer{ get; set; }

    }
}
