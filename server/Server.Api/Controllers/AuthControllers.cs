using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Core.Interfaces;
using Server.Core.Requests.User;
using Server.Database.Data;

namespace Server.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthControllers : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        private readonly IMailService _mailService;

        public AuthControllers(IAuthRepository authRepo, IMailService mailService)
        {
            _authRepo = authRepo;
            _mailService = mailService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginDto req)
        {
            var res = await _authRepo.Login(req);

            if (res != null)
                return Ok(res);

            return BadRequest(res);
        }

        [HttpPost("insert")]
        public async Task<IActionResult> Post([FromBody] UserInsertRequest req)
        {
            var res = await _authRepo.InsertUser(req);
            
            return res != null ? Ok(res) : BadRequest(res);
        }
    }
}