using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using U_Token_Proj.Dtos;
using U_Token_Proj.Services.UserServices;

namespace U_Token_Proj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IUserService _userService;
        public ValuesController(IUserService userService)
        {
            this._userService = userService;
        }
        [HttpPost]
        public async ValueTask<IActionResult> CreataAsync(UserCreateDto userCreateDto)
        {
            var result = await _userService.CreateNewUser(userCreateDto);
            return Ok(result);
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result);
        }
    }
}
