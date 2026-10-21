using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.DTOs.Vaccine;
using PetMangement.Server.Services.Vaccine;

namespace PetMangement.Server.Controllers.Vaccine
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaccineController : ControllerBase
    {
        private readonly IVaccineService _vaccineService;

        public VaccineController(IVaccineService vaccineService)
        {
            _vaccineService = vaccineService;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetVaccines()
        {
            var vaccines = _vaccineService.GetVaccines();
            return Ok(vaccines);
        }

        /// <summary>
        /// Get specific record from vaccine
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{vaccineId}")]
        public IActionResult GetVaccineById(int vaccineId)
        {
            var vaccine = _vaccineService.GetVaccineById(vaccineId);
            if (vaccine == null)
                return NotFound();
            return Ok(vaccine);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="vaccine"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateVaccine([FromBody] CreateVaccineDTO vaccine)
        {
            var result = _vaccineService.CreateVaccine(vaccine);
            if (!result)
                return BadRequest("Error al guardar");
            return StatusCode(201, result);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        [HttpPut("{vaccineId}")]
        public IActionResult UpdateVaccine(int vaccineId, [FromBody] UpdateVaccineDTO vaccine)
        {
            vaccine.vaccineId = vaccineId;
            var result = _vaccineService.UpdateVaccine(vaccine);
            if (!result)
                return BadRequest("Error al editar");
            return Ok(result);
        }

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="vaccineId"></param>
        /// <returns></returns>
        [HttpDelete("{vaccineId}")]
        public IActionResult DeleteVaccine(int vaccineId)
        {
            var result = _vaccineService.DeleteVaccine(vaccineId);
            if (!result)
                return BadRequest("Error al eliminar");
            return Ok(result);
        }
    }
}
