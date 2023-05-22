using LockerZone.Application.Interfaces.Services.General;
using LockerZone.Domain.Common;
using LockerZone.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LockerZone.Controllers.GeneralB
{
    public class AuthController : ApiControllersBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route(RouteClass.AuthRoute.Login)]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _userService.Token(loginDto);
            return Ok(token);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route(RouteClass.AuthRoute.Register)]
        public async Task<IActionResult> Register([FromBody] RegisterDto RegisterDto)
        {
            var response = await _userService.RegisterAccounUser(RegisterDto);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route(RouteClass.AuthRoute.RegisterAdmin)]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterDto RegisterDto)
        {
            var response = await _userService.RegisterAccounAdmin(RegisterDto);
            return Ok(response);
        }
    }
}
