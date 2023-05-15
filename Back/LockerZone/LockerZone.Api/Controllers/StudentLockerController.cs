using LockerZone.Application.Interfaces.Services;
using LockerZone.Controllers;
using LockerZone.Domain.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerZone.Api.Controllers
{
    public class StudentLockerController : ApiControllersBase
    {
        private readonly ILockerService _lockerService;

        public StudentLockerController(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }
        [HttpPut]
        [Route(RouteClass.LockerRoute.ReserveLocker)]
        public async Task<IActionResult> GetLockers(Guid id)
        {
            var serviceResponse = await _lockerService.ResereveLocker(id);
            return Ok(serviceResponse);
        }
    }
}
