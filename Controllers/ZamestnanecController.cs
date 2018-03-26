using Emp.DAL;
using Emp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Web.Http;

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

        [HttpGet]
        public IActionResult Get(int zamestnanecID)
        {
            var zamestnanec = _zamestnanecRepository.Get(zamestnanecID);
            return new OkObjectResult(zamestnanec);
        }

        [HttpGet("/api/ZoznamZamestnancov")]
        public IActionResult GetAll()
        {
            var zoznam = _zamestnanecRepository.GetAll();
            return new OkObjectResult(zoznam);
        }

        [HttpDelete("{zamestnanecID}")]
        public IActionResult Delete(int zamestnanecID)
        {
            var zamestnanec = new Zamestnanec { ZamestnanecID = zamestnanecID };
            _zamestnanecRepository.Remove(zamestnanec);
            _zamestnanecRepository.Save();
            return new NoContentResult();
        }

        [HttpPost]
        public IActionResult Add([FromBody] Zamestnanec newZamestnanec)
        {
            if (newZamestnanec == null) return BadRequest();

            _zamestnanecRepository.Add(newZamestnanec);
            _zamestnanecRepository.Save();

            return Ok(newZamestnanec);
        }
    }
}