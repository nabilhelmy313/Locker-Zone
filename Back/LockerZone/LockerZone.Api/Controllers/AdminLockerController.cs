﻿using LockerZone.Application.Interfaces.Services;
using LockerZone.Controllers;
using LockerZone.Domain.Common;
using LockerZone.Domain.Dtos;
using LockerZone.Domain.Dtos.Locker;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LockerZone.Api.Controllers
{
    [AllowAnonymous]
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
        [HttpGet]
        [Route(RouteClass.LockerRoute.GetLockersAdmin)]
        public async Task<IActionResult> GetLockersAdmin()
        {
            var serviceResponse = await _lockerService.GetLockersAdmin();
            return Ok(serviceResponse);
        }
        [HttpGet]
        [Route(RouteClass.LockerRoute.GetLocker)]
        public async Task<IActionResult> GetLocker(Guid id)
        {
            var serviceResponse = await _lockerService.GetLocker(id);
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
