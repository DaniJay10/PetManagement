using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.DTOs.Deworming;
using PetMangement.Server.Services.Deworming;

namespace PetMangement.Server.Controllers.Deworming
{
    [ApiController]
    [Route("api/[controller]")]
    public class DewormingController : ControllerBase
    {
        private readonly IDewormingService _dewormingService;

        public DewormingController(IDewormingService dewormingService)
        {
            _dewormingService = dewormingService;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetDewormings()
        {
            var dewormings = _dewormingService.GetDewormings();
            return Ok(dewormings);
        }

        /// <summary>
        /// Get a specific record from deworming
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        [HttpGet("{dewormingId}")]
        public IActionResult GetDewormingById(int dewormingId)
        {
            var deworming = _dewormingService.GetDewormingById(dewormingId);

            if (deworming == null)
                return NotFound();

            return Ok(deworming);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="deworming"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateDeworming([FromBody] CreateDewormingDTO deworming)
        {
            var result = _dewormingService.CreateDeworming(deworming);

            if (!result)
                return BadRequest("Error al guardar");

            return StatusCode(201, result);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <param name="deworming"></param>
        /// <returns></returns>
        [HttpPut("{dewormingId}")]
        public IActionResult UpdateDeworming(
            int dewormingId,
            [FromBody] UpdateDewormingDTO deworming)
        {
            deworming.dewormingId = dewormingId;

            var result = _dewormingService.UpdateDeworming(deworming);

            if (!result)
                return BadRequest("Error al editar");

            return Ok(result);
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="dewormingId"></param>
        /// <returns></returns>
        [HttpDelete("{dewormingId}")]
        public IActionResult DeleteDeworming(int dewormingId)
        {
            var result = _dewormingService.DeleteDeworming(dewormingId);

            if (!result)
                return BadRequest("Error al eliminar");

            return Ok(result);
        }
    }
}