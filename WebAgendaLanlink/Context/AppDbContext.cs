using Microsoft.EntityFrameworkCore;
using WebAgendaLanlink.Models;

namespace WebAgendaLanlink.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Contato> Contatos { get; set; }

    }
}
