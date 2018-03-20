using Emp.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Emp.DAL
{
    public class ZamestnanecRepository : Repository<Zamestnanec>
    {
        public ZamestnanecRepository(EmpDBContext context) : base(context)
        {
        }
    }
}
