using Costumer_Loan.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Costumer_Loan.Models.DTO
{
    public class CostumerDTO
    {
        [Key]
        public int? CostumerId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public bool? IsActive { get; set; }
        //public bool? IsDeleted { get; set; }

    }
}
