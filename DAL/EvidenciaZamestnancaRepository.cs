using Emp.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace Emp.DAL
{
    public class EvidenciaZamestnancaRepository : Repository<EvidenciaZamestnanca>
    {
        public EvidenciaZamestnancaRepository(EmpDBContext context) : base(context)
        {
        }

        public IEnumerable<EvidenciaZamestnanca> GetZoznamVsetkychZamestnancov()
        {
            return EmpContext.EvidenciaZamestnancov
                .Include(e => e.Zamestnanec)
                .Include(e => e.Pozicia)
                .ToList();
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
                .Where(z => !(from x in zoznamAktualnychZamestnancov select x.ZamestnanecID).Contains(z.ZamestnanecID))
                .ToList();
        }

        public IEnumerable<EvidenciaZamestnanca> GetZamestnanecInfo(int zamestnanecId)
        {
            return EmpContext.EvidenciaZamestnancov
                .Include(e => e.Zamestnanec)
                .Include(e => e.Pozicia)
                .Where(e => e.ZamestnanecID == zamestnanecId)
                .ToList();
        }

        public void Update(EvidenciaZamestnanca evidenciaZamestnanca)
        {
            EmpContext.EvidenciaZamestnancov.Attach(evidenciaZamestnanca);
            EntityEntry<EvidenciaZamestnanca> entryE = EmpContext.Entry(evidenciaZamestnanca);
            entryE.State = EntityState.Modified;
            EntityEntry<Zamestnanec> entryZ = EmpContext.Entry(evidenciaZamestnanca.Zamestnanec);
            entryZ.State = EntityState.Modified;
            EmpContext.SaveChanges();
        }

        public EmpDBContext EmpContext
        {
            get { return Context as EmpDBContext; }
        }
    }
}
