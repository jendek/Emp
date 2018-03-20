using Emp.DAL;
using Emp.Model;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Add([FromBody] Pozicia newPozicia)
        {
            if (newPozicia == null)
            {
                return BadRequest();
            }

            _poziciaRepository.Add(newPozicia);
            _poziciaRepository.Save();
            return new NoContentResult();
        }

        [HttpDelete("{poziciaID}")]
        public IActionResult Delete(int poziciaID)
        {
            var pozicia = new Pozicia { PoziciaID = poziciaID };
            _poziciaRepository.Remove(pozicia);
            _poziciaRepository.Save();
            return new NoContentResult();
        }
    }
}

