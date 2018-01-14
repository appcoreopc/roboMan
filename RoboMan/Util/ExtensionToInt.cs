
namespace RoboMan.Util
{
    public static class ExtensionToInt
    {
        public static int? ToInt(this string locationText)
        {
            if (int.TryParse(locationText, out int location))
            {
                return location;
            }
            return null;
        }
    }
}
