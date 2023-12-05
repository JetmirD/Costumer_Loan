using Costumer_Loan.Entities;
using Costumer_Loan.Models.DTO;
using AutoMapper;
namespace Costumer_Loan.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<Costumer, CostumerDTO>().ReverseMap();
            CreateMap<Loan, LoanDTO>().ReverseMap();
        }
    }
}
