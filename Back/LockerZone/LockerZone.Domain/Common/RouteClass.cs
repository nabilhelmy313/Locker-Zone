namespace LockerZone.Domain.Common
{
    public static class RouteClass
    {
        public static class AuthRoute
        {
            public const string Login = "Api/Auth/Login";
            public const string Register = "Api/Auth/Register";
            public const string RegisterAdmin = "Api/Auth/RegisterAdmin";
        }
        public static class Feeback
        {
            public const string SendFeeback = "Api/Feedback/SendFeeback";
        }
        public static class LockerRoute
        {
            public const string GetLockers = "Api/Lokcer/GetLockers";
            public const string GetLockersAdmin = "Api/Lokcer/GetLockersAdmin";
            public const string GetLocker = "Api/Lokcer/GetLocker";
            public const string AddLocker = "Api/Lokcer/AddLocker";
            public const string EditLocker= "Api/Lokcer/EditLocker";
            public const string DeleteLocker= "Api/Lokcer/DeleteLocker";
            public const string ResereveLocker = "Api/Lokcer/ResereveLocker";
            public const string RefundLocker = "Api/Lokcer/RefundLocker";
        }

    }
}
