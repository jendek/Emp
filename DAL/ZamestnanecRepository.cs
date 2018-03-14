using Emp.Model;

namespace Emp.DAL
{
    public class ZamestnanecRepository : Repository<Zamestnanec>
    {
        public ZamestnanecRepository(EmpDBContext context) : base(context)
        {
        }
    }
}
