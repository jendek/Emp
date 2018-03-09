using Emp.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Emp.Data
{
    public class EmpDBContext : DbContext
    {
        public EmpDBContext(DbContextOptions<EmpDBContext> options) : base(options)
        {

        }

        public DbSet<Zamestnanec> Zamestnanci { get; set; }
        public DbSet<Pozicia> Pozicie { get; set; }
        public DbSet<EvidenciaZamestnanca> EvidenciaZamestnancov { get; set; }
    } 
}
