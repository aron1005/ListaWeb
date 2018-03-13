using Microsoft.EntityFrameworkCore;

namespace ListaWeb.Models
{
    public class ListaDbContext : DbContext
    {
        public ListaDbContext(DbContextOptions<ListaDbContext> options) : base(options)
        {

        }

        public DbSet<PendienteItem> Pendientes { get; set; }
    }

}