using System;

namespace RoboMan.Util
{
    public static class ExtensionToFacingDirection
    {
        public static FaceDirection? ToDirection(this string directionText)
        {
            if (Enum.TryParse(directionText, out FaceDirection a))
            {
                return a;
            }
            return null;
        }
    }
}