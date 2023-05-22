using LockerZone.Application.Interfaces.Services;
using LockerZone.Controllers;
using LockerZone.Domain.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerZone.Api.Controllers
{
    [AllowAnonymous]
    public class StudentLockerController : ApiControllersBase
    {
        private readonly ILockerService _lockerService;

        public StudentLockerController(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }
        [HttpPut]
        [Route(RouteClass.LockerRoute.ResereveLocker)]
        public async Task<IActionResult> ResereveLocker([FromQuery]Guid id)
        {
            var serviceResponse = await _lockerService.ResereveLocker(id);
            return Ok(serviceResponse);
        }
        [HttpPut]
        [Route(RouteClass.LockerRoute.RefundLocker)]
        public async Task<IActionResult> RefundLocker([FromQuery] Guid id)
        {
            var serviceResponse = await _lockerService.RefundLocker(id);
            return Ok(serviceResponse);
        }
    }
}
