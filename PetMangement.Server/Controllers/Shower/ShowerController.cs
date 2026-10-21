using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.DTOs.Shower;
using PetMangement.Server.Models;
using PetMangement.Server.Services.Shower;

namespace PetMangement.Server.Controllers.Shower
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShowerController : ControllerBase
    {
        private readonly IShowerService _showerService;

        public ShowerController(IShowerService showerService)
        {
            _showerService = showerService;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetShowers()
        {
            var showers = _showerService.GetShowers();
            return Ok(showers);
        }

        /// <summary>
        /// Get a specific record from shower
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        [HttpGet("{showerId}")]
        public IActionResult GetShowerById(int showerId)
        {
            var shower = _showerService.GetShowerById(showerId);

            if (shower == null)
                return NotFound();

            return Ok(shower);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="shower"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateShower([FromBody] CreateShowerDTO shower)
        {
            var result = _showerService.CreateShower(shower);

            if (!result)
                return BadRequest("Error al guardar");

            return StatusCode(201, result);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="shower"></param>
        /// <returns></returns>
        [HttpPut("{showerId}")]
        public IActionResult UpdateShower(int showerId, [FromBody] UpdateShowerDTO shower)
        {
            shower.showerId = showerId;

            var result = _showerService.UpdateShower(shower);

            if (!result)
                return BadRequest("Error al editar");

            return Ok(result);
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="showerId"></param>
        /// <returns></returns>
        [HttpDelete("{showerId}")]
        public IActionResult DeleteShower(int showerId)
        {
            var result = _showerService.DeleteShower(showerId);

            if (!result)
                return BadRequest("Error al eliminar");

            return Ok(result);
        }
    }
}