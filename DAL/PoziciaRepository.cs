using Emp.Model;
using System.Collections.Generic;

namespace Emp.DAL
{
    public class PoziciaRepository : Repository<Pozicia>
    {
        public PoziciaRepository(EmpDBContext context) : base(context)
        {
        }
    }
}
