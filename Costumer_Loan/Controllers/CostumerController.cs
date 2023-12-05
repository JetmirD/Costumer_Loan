using AutoMapper;
using Costumer_Loan.Entities;
using Costumer_Loan.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Costumer_Loan.Controllers
{
    [ApiController]
    [Route("api/Costumers")]
    public class CostumerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDBContext _context;

        public CostumerController(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CostumerDTO>>> GetCostumers()
        {
            var costumer = await _context.Costumers.ToListAsync();
            var costumerDTO = _mapper.Map<IEnumerable<CostumerDTO>>(costumer);
            return Ok(costumerDTO);
        }

        [HttpPost]
        public async Task<ActionResult<CostumerDTO>>CreateCostumer(CostumerDTO costumerDTO)
        {
            var costumers = _mapper.Map<Costumer>(costumerDTO);
            _context.Costumers.Add(costumers);
            await _context.SaveChangesAsync();

            var newCostumer = _mapper.Map<CostumerDTO>(costumers);
            return CreatedAtAction(nameof(GetCostumers), new { id = costumers.CostumerId }, newCostumer);
        }

        [HttpDelete]
        public async Task<IActionResult>DeleteCostumer(int id)
        {
            var costumeri = await _context.Costumers.FindAsync(id);
            if(costumeri == null)
            {
                return BadRequest("No costumer with this ID was found");
            }
            costumeri.IsDeleted = true;
            await _context.SaveChangesAsync();

            return Ok("Costumer Deleted Succesfully");

        }
    }
}
