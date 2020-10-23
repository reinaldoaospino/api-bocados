using System;

namespace Application.Extension
{
    public static class ExtensionString
    {
        public static string GenerateId(this string id)
        {
            return Guid.NewGuid().ToString();
        }
    }
}
