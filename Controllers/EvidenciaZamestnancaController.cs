using Emp.DAL;
using Emp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.KeyVault.Models;

namespace Emp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class EvidenciaZamestnancaController : Controller
    {
        private readonly EvidenciaZamestnancaRepository _evidenciaZamestnancaRepository;

        public EvidenciaZamestnancaController(EvidenciaZamestnancaRepository evidenciaZamestnancaRepository)
        {
            _evidenciaZamestnancaRepository = evidenciaZamestnancaRepository;
        }

        [HttpGet("/api/ZoznamAktualnychZamestnancov")]
        public IActionResult GetZoznamAktualnychZamestnancov()
        {
            var zoznam = _evidenciaZamestnancaRepository.GetZoznamAktualnychZamestnancov();
            return new OkObjectResult(zoznam);
        }

        [HttpGet("/api/ZoznamPredoslychZamestnancov")]
        public IActionResult GetZoznamPredoslychZamestnancov()
        {
            var zoznam = _evidenciaZamestnancaRepository.GetZoznamPredoslychZamestnancov();
            return new OkObjectResult(zoznam);
        }

        [HttpGet("{zamestnanecID}", Name = nameof(GetZamestnanecInfo))]
        public IActionResult GetZamestnanecInfo(int zamestnanecID)
        {
            var zamestnanecInfo = _evidenciaZamestnancaRepository.GetZamestnanecInfo(zamestnanecID);
            if (zamestnanecInfo == null)
            {
                return new NotFoundObjectResult(
                    new Error("404", $"Zamestnanec s ID:{zamestnanecID} - Sa nenachadza v databaze!"));
            }
            return new OkObjectResult(zamestnanecInfo);
        }

        [HttpPost]
        public IActionResult AddZamestnanecInfo([FromBody] EvidenciaZamestnanca evidenciaZamestnanca)
        {
            if (evidenciaZamestnanca == null) return BadRequest();

            _evidenciaZamestnancaRepository.Add(evidenciaZamestnanca);
            _evidenciaZamestnancaRepository.Save();

            return Ok(evidenciaZamestnanca);
        }

        [HttpPut]
        public IActionResult UpdateZamestnanecInfo([FromBody] EvidenciaZamestnanca evidenciaZamestnanca)
        {
            if (evidenciaZamestnanca == null) return BadRequest();

            evidenciaZamestnanca.Pozicia = null;
            _evidenciaZamestnancaRepository.Update(evidenciaZamestnanca);
            _evidenciaZamestnancaRepository.Save();

            return Ok(evidenciaZamestnanca);
        }
    }
}