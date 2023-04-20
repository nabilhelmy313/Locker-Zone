using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace LockerZone.Controllers
{
    [ApiController]
    [Authorize]
    public class ApiControllersBase : ControllerBase
    {

        public string CurrentUserId
        {
            get
            {
                var s = ClaimTypes.Name;

                var d = User;
                return User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
        }

        public string CurrentUserName
        {
            get
            {
                return User.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string CurrentUserEmail
        {
            get
            {
                return User.FindFirst(ClaimTypes.Email).Value;
            } 
        }
    }
 }
