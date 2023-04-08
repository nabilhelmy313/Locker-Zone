using System.Resources;

namespace LockerZone.Application.Common
{
    public class CultureHelper
    {
        public static string GetResourceMessage(ResourceManager manager, string key)
        {
            return manager.GetString(key, Thread.CurrentThread.CurrentCulture)!;
        }
    }
}
