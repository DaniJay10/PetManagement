using Microsoft.AspNetCore.Mvc;
using PetMangement.Server.Services.Expedient;

namespace PetMangement.Server.Controllers.Expedient
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpedientController : ControllerBase
    {
        private readonly IExpedientService _expedientService;

        public ExpedientController(IExpedientService expedientService)
        {
            _expedientService = expedientService;
        }

        /// <summary>
        /// Get all the information of the expedient
        /// </summary>
        /// <param name="petId"></param>
        /// <returns></returns>
        [HttpGet("{petId}")]
        public IActionResult GetExpedientByPetId(int petId)
        {
            var expedient = _expedientService.GetExpedientByPetId(petId);
            return Ok(expedient);
        }
    }
}
