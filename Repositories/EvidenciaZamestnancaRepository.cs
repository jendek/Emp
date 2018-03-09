using Emp.Data;
using Emp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Emp.Repositories
{
    public class EvidenciaZamestnancaRepository : Repository<EvidenciaZamestnanca>
    {
        public EvidenciaZamestnancaRepository(EmpDBContext context) : base(context)
        {
        }

        public IEnumerable<EvidenciaZamestnanca> GetZoznamAktualnychZamestnancov()
        {
            return EmpContext.EvidenciaZamestnancov
                .Include(e => e.Zamestnanec)
                .Include(e => e.Pozicia)
                .Where(e => e.DatumUkoncenia == null)
                .ToList();
        }

        public IEnumerable<EvidenciaZamestnanca> GetZoznamPredoslychZamestnancov()
        {
            var zoznamAktualnychZamestnancov = EmpContext.EvidenciaZamestnancov
                .Include(e => e.Zamestnanec)
                .Include(e => e.Pozicia)
                .Where(e => e.DatumUkoncenia == null)
                .ToList();

            return EmpContext.EvidenciaZamestnancov
                .Include(e => e.Zamestnanec)
                .Include(e => e.Pozicia)
                .Except(zoznamAktualnychZamestnancov)
                .ToList();
        }

        public IEnumerable<EvidenciaZamestnanca> GetZaznamyZamestnanca(Zamestnanec zamestnanec)
        {
            return EmpContext.EvidenciaZamestnancov
                .Include(e => e.Zamestnanec)
                .Include(e => e.Pozicia)
                .Where(e => e.Zamestnanec == zamestnanec)
                .ToList();
        }

        public EmpDBContext EmpContext
        {
            get { return Context as EmpDBContext; }
        }
    }
}
