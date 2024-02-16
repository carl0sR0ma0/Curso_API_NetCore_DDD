using Domain.DTOs.County;
using Domain.Interfaces.Services.County;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountiesController : ControllerBase
    {
        public ICountyService _service { get; set; }

        public CountiesController(ICountyService service)
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

        [HttpGet]
        [Route("{id}", Name = "GetCountyWithId")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetCountyCompleteWithId")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetCompleteById(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.GetCompleteById(id);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpGet]
        [Route("{codeIBGE}", Name = "GetCountyWithCodeIBGE")]
        [Authorize("Bearer")]
        public async Task<IActionResult> GetCompleteByIBGE(int codeIBGE)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.GetCompleteByIBGE(codeIBGE);
                if (result == null) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> Post([FromBody] CountyCreateDTO dtoCreate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(dtoCreate);
                if (result is not null) return Created(new Uri(Url.Link("GetCountyCompleteWithId", new { id = result.Id })), result);
                else return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> Put([FromBody] CountyUpdateDTO dtoUpdate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.Put(dtoUpdate);
                if (result is not null) return Ok(result);
                else return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                return Ok(await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
