using jap_task.Data;
using jap_task.Dtos.User;
using jap_task.Models;
using Microsoft.AspNetCore.Mvc;

namespace jap_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthControllers : ControllerBase
    {
        private readonly IAuthRepository _authRepo;

        public AuthControllers(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(request.Email, request.Password);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}