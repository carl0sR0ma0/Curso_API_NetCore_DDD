using Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UFsController : ControllerBase
    {
        public IUFService _service { get; set; }

        public UFsController(IUFService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                return Ok(await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(id);
                if (result is null) return NotFound();
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
