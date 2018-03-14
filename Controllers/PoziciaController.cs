using Emp.DAL;
using Emp.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Emp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PoziciaController : Controller
    {
        private readonly PoziciaRepository _poziciaRepository;

        public PoziciaController(PoziciaRepository poziciaRepository)
        {
            _poziciaRepository = poziciaRepository;
        }

        [HttpGet("/api/ZoznamPozicii")]
        public IActionResult GetAll()
        {
            var zoznam = _poziciaRepository.GetAll();
            return new OkObjectResult(zoznam);
        }
    }
}

