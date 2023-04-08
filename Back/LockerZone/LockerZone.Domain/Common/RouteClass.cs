using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockerZone.Domain.Common
{
    public static class RouteClass
    {
        public static class AuthRoute
        {
            public const string Login = "Api/Auth/Login";
            public const string Register = "Api/Auth/Register";
        }
        public static class MasterData
        {
            public const string AddMasterData = "Api/MasterData/AddMasterData";
        }

    }
}
