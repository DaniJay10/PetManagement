using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.DTOs.Consultation;
using PetMangement.Server.DTOs.Pet;
using PetMangement.Server.Services.Consultation;
using PetMangement.Server.Services.Pet;

namespace PetMangement.Server.Controllers.Consultation
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultationController : ControllerBase
    {
        private readonly IConsultationService _consultationService;

        public ConsultationController(IConsultationService consultationService)
        {
            _consultationService = consultationService;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetConsultations()
        {
            var consultations = _consultationService.GetConsultations();
            return Ok(consultations);
        }

        /// <summary>
        /// Get specific record from consultation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{consultationId}")]
        public IActionResult GetConsultationById(int consultationId)
        {
            var consultation = _consultationService.GetConsultation(consultationId);
            if (consultation == null)
                return NotFound();
            return Ok(consultation);
        }


        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="consultation"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult InsertConsultation([FromBody] CreateConsultDTO consultation)
        {
            var result = _consultationService.InsertConsultation(consultation);
            if (!result)
                return BadRequest("Error al guardar");
            return StatusCode(201, result);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="Pet"></param>
        /// <returns></returns>
        [HttpPut("{consultationId}")]
        public IActionResult UpdatePet(int consultationId, [FromBody] UpdateConsultDTO consultation)
        {
            consultation.consultationId = consultationId;
            var result = _consultationService.UpdateConsultation(consultation);
            if (!result)
                return BadRequest("Error al editar");
            return Ok(result);
        }

        /// <summary>
        /// Delete one record in the DB
        /// </summary>
        /// <param name="consultationId"></param>
        /// <returns></returns>
        [HttpDelete("{consultationId}")]
        public IActionResult DeletePet(int consultationId)
        {
            var result = _consultationService.DeleteConsultation(consultationId);
            if (!result)
                return BadRequest("Error al eliminar");
            return Ok(result);
        }
    }
}