
namespace RoboMan.Util
{
    static class ExtensionToInt
    {
        internal static int? ToInt(this string locationText)
        {
            if (string.IsNullOrWhiteSpace(locationText))
                return null;

            if (int.TryParse(locationText?.Trim(), out int location))
            {
                return location;
            }
            return null;
        }
    }
}
