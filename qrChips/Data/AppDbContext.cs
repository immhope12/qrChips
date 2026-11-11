using Microsoft.EntityFrameworkCore;
using qrChips.Models;

namespace qrChips.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Esta línea representa la tabla "Asistencias" en la base de datos
        public DbSet<Asistencia> Asistencias { get; set; }
    }
}