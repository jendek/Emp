using Emp.Data;
using Emp.Data.Entity;

namespace Emp.Repositories
{
    public class ZamestnanecRepository : Repository<Zamestnanec>
    {
        public ZamestnanecRepository(EmpDBContext context) : base(context)
        {
        }
    }
}
