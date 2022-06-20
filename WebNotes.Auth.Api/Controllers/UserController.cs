using Microsoft.AspNetCore.Mvc;
using WebNotes.Auth.Api.Authorization;
using WebNotes.Auth.Domain.Entities.Request;
using WebNotes.Auth.Domain.Entities.Response;
using WebNotes.Auth.Domain.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebNotes.Auth.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // POST api/<UserController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request)
        {
            await _userService.CreateUser(request);
            return Ok();
        }

        [HttpGet("login")]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResponse>> LoginUser([FromQuery] LoginRequest request)
        {
            
            return Ok(await _userService.LoginUser(request));
        }


    }
}
