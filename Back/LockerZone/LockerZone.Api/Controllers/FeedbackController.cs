using LockerZone.Application.Interfaces.Services;
using LockerZone.Controllers;
using LockerZone.Domain.Common;
using LockerZone.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LockerZone.Api.Controllers
{
    public class FeedbackController : ApiControllersBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route(RouteClass.Feeback.SendFeeback)]
        public async Task<IActionResult> SendFeeback([FromBody] FeedbackMessageDto feedbackMessageDto)
        {
            var token = await _feedbackService.AddNewMessage(feedbackMessageDto);
            return Ok(token);
        }
    }
}
