using LockerZone.Application.Interfaces.Services;
using LockerZone.Controllers;
using LockerZone.Domain.Common;
using LockerZone.Domain.Dtos;
using LockerZone.Domain.Dtos.Locker;
using Microsoft.AspNetCore.Mvc;

namespace LockerZone.Api.Controllers
{
    public class AdminLockerController : ApiControllersBase
    {
        private readonly ILockerService _lockerService;

        public AdminLockerController(ILockerService lockerService)
        {
            _lockerService = lockerService;
        }
        [HttpGet]
        [Route(RouteClass.LockerRoute.GetLockers)]
        public async Task<IActionResult> GetLockers()
        {
            var serviceResponse = await _lockerService.GetLockers();
            return Ok(serviceResponse);
        }
        [HttpPost]
        [Route(RouteClass.LockerRoute.AddLocker)]
        public async Task<IActionResult> AddLocker([FromBody] AddLockerDto addLockerDto)
        {
            var serviceResponse = await _lockerService.AddLocker(addLockerDto);
            return Ok(serviceResponse);
        }
        [HttpPut]
        [Route(RouteClass.LockerRoute.EditLocker)]
        public async Task<IActionResult> EditLocker([FromBody] EditLockerDto editLockerDto)
        {
            var serviceResponse = await _lockerService.EditLocker(editLockerDto);
            return Ok(serviceResponse);
        }
        [HttpDelete]
        [Route(RouteClass.LockerRoute.DeleteLocker)]
        public async Task<IActionResult> DeleteLocker(Guid id)
        {
            var token = await _lockerService.DeleteLocker(id);
            return Ok(token);
        }
    }
}
