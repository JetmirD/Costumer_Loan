using AutoMapper;
using AutoMapper.Configuration.Conventions;
using Costumer_Loan.Entities;
using Costumer_Loan.Enums;
using Costumer_Loan.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Costumer_Loan.Controllers
{
    [ApiController]
    [Route("api/Loans")]
    public class LoanController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public LoanController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LoanDTO>>> GetLoan()
        {
            var loans = await _context.Loans.Include(b => b.Costumer).ToListAsync();
            var loanDTOs = _mapper.Map<IEnumerable<LoanDTO>>(loans);
            return Ok(loanDTOs);
        }

        [HttpPost]
        public async Task<ActionResult<LoanDTO>> CreateLoan(LoanDTO loanDTO)
        {
            var loan = _mapper.Map<Loan>(loanDTO);
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            var newLoan = _mapper.Map<LoanDTO>(loan);
            return CreatedAtAction(nameof(GetLoan), new { id = loan.LoanId }, newLoan);
        }

        [HttpGet("filterByStatus")]
        public IActionResult GetLoansByStatus(LoanStatus? loans)
        {
            if(loans == null)
            {
                return BadRequest("Please provide a status");
            }
            var filteredLoans = _context.Loans.Where(b => b.Status == loans).ToList();
            return Ok(filteredLoans);
        }

        [HttpGet("filterByCostumer")]
        public IActionResult GetLoansByCostumer(string? Costumeri)
        {
            
            var kredite = _context.Loans.Include(b => b.Costumer).Where(b => b.Costumer.Name == Costumeri && b.Costumer.IsDeleted == false);
      

            return Ok(kredite);
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteLoan(int id)
        {

            var loantodelete = await _context.Loans.FindAsync(id);

            if(loantodelete == null)
            {
                return BadRequest("This record does not exist");
            }
            loantodelete.isDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
