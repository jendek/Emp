using Emp.Model;
using Microsoft.EntityFrameworkCore;
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
                .Except(zoznamAktualnychZamestnancov)
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

        public EmpDBContext EmpContext
        {
            get { return Context as EmpDBContext; }
        }
    }
}
