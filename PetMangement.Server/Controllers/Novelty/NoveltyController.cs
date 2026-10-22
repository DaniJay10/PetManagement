using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.DTOs.Novelty;
using PetMangement.Server.Services.Novelty;

namespace PetMangement.Server.Controllers.Novelty
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoveltyController : ControllerBase
    {
        private readonly INoveltyService _noveltyService;

        public NoveltyController(INoveltyService noveltyService)
        {
            _noveltyService = noveltyService;
        }

        /// <summary>
        /// Get all the records from the DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetNovelties()
        {
            var novelties = _noveltyService.GetNovelties();
            return Ok(novelties);
        }

        /// <summary>
        /// Get a specific record from novelty
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        [HttpGet("{noveltyId}")]
        public IActionResult GetNoveltyById(int noveltyId)
        {
            var novelty = _noveltyService.GetNoveltyById(noveltyId);

            if (novelty == null)
                return NotFound();

            return Ok(novelty);
        }

        /// <summary>
        /// Insert one record in the DB
        /// </summary>
        /// <param name="novelty"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CreateNovelty([FromBody] CreateNoveltyDTO novelty)
        {
            var result = _noveltyService.CreateNovelty(novelty);

            if (!result)
                return BadRequest("Error al guardar");

            return StatusCode(201, result);
        }

        /// <summary>
        /// Update one record in the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <param name="novelty"></param>
        /// <returns></returns>
        [HttpPut("{noveltyId}")]
        public IActionResult UpdateNovelty(
            int noveltyId,
            [FromBody] UpdateNoveltyDTO novelty)
        {
            novelty.noveltyId = noveltyId;

            var result = _noveltyService.UpdateNovelty(novelty);

            if (!result)
                return BadRequest("Error al editar");

            return Ok(result);
        }

        /// <summary>
        /// Delete one record from the DB
        /// </summary>
        /// <param name="noveltyId"></param>
        /// <returns></returns>
        [HttpDelete("{noveltyId}")]
        public IActionResult DeleteNovelty(int noveltyId)
        {
            var result = _noveltyService.DeleteNovelty(noveltyId);

            if (!result)
                return BadRequest("Error al eliminar");

            return Ok(result);
        }
    }
}