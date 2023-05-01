namespace LockerZone.Domain.Common
{
    public static class RouteClass
    {
        public static class AuthRoute
        {
            public const string Login = "Api/Auth/Login";
            public const string Register = "Api/Auth/Register";
        }
        public static class Feeback
        {
            public const string SendFeeback = "Api/Feedback/SendFeeback";
        }
        public static class LockerRoute
        {
            public const string GetLockers = "Api/Lokcer/GetLockers";
            public const string AddLocker = "Api/Lokcer/AddLocker";
            public const string EditLocker= "Api/Lokcer/EditLocker";
            public const string DeleteLocker= "Api/Lokcer/DeleteLocker";

        }

    }
}
