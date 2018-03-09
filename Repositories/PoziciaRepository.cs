using Emp.Data;
using Emp.Data.Entity;

namespace Emp.Repositories
{
    public class PoziciaRepository : Repository<Pozicia>
    {
        public PoziciaRepository(EmpDBContext context) : base(context)
        {
        }
    }
}
