using Costumer_Loan.Entities;
using Microsoft.EntityFrameworkCore;

namespace Costumer_Loan
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Costumer> Costumers { get; set; }
    }
}