using Emp.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Emp.Controllers
{
    [Produces("application/json")]
    [Route("api/Zamestnanec")]
    public class ZamestnanecController : Controller
    {
        private ZamestnanecRepository _zamestnanecRepository;

        public ZamestnanecController(ZamestnanecRepository zamestnanecRepository)
        {
            _zamestnanecRepository = zamestnanecRepository;
        }

        [HttpGet("/api/Zamestnanec")]
        public IActionResult GetAll()
        {
            var zoznam = _zamestnanecRepository.GetAll();
            return new OkObjectResult(zoznam);
        }
    }
}