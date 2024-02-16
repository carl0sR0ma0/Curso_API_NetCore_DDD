using Domain.DTOs.ZipCode;
using Domain.Interfaces.Services.ZipCode;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipCodesController : ControllerBase
    {
        public IZipCodeService _service { get; set; }

        public ZipCodesController(IZipCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}", Name = "GetZipCodeWithId")]
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
        [Route("byZipCode/{zipCode}", Name = "GetZipCodeWithZipCode")]
        [Authorize("Bearer")]
        public async Task<IActionResult> Get(string zipCode)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.Get(zipCode);
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
        public async Task<IActionResult> Post([FromBody] ZipCodeCreateDTO dtoCreate)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                var result = await _service.Post(dtoCreate);
                if (result is not null) return Created(new Uri(Url.Link("GetZipCodeWithId", new { id = result.Id })), result);
                else return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Authorize("Bearer")]
        public async Task<IActionResult> Put([FromBody] ZipCodeUpdateDTO dtoUpdate)
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
