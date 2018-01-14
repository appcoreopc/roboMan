
namespace RoboMan.Util
{
    public static class ExtensionToInt
    {
        public static int? ToInt(this string locationText)
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
