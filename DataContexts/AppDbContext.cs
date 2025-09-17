using ApiServico.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiServico.DataContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Chamado> Chamados { get; set; }

    }
}
