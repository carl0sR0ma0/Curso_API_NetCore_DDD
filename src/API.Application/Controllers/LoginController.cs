﻿using Domain.Entities;
using Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<object> Login([FromBody] UserEntity userEntity, [FromServices] ILoginService service)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (userEntity is null) return BadRequest();

            try
            {
                var result = await service.FindByLogin(userEntity);

                if (result is not null) return Ok(result);
                else return NotFound();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
