using ADA.Pagamentos.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ADA.Pagamentos.API.Infrastructure.Data.Context
{
    public class ADAContext : DbContext
    {
        public ADAContext(DbContextOptions<ADAContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
    }
}
