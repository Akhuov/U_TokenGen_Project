using Microsoft.AspNetCore.Mvc;
using U_Token_Proj.Model;
using U_Token_Proj.Services;
using U_Token_Proj.Services.AuthServices;

namespace U_Token_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(IAuthService authService, ILogger<AuthController> logger)
        {
            _authService = authService;
            _logger = logger;

        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(LoginRequest request)
        {
            try
            {
                request.Password = HashData.HashPass(request.Password);
                var token = await _authService.Login(request);

                return Ok(token);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
                return BadRequest("Username or Password is not valid");
            }
        }
    }
}
