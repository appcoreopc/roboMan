using System;
 
namespace RoboMan.Util
{
    public static class ExtensionToFacingDirection
    {
        public static FaceDirection? ToDirection(this string directionText)
        {
            if (string.IsNullOrWhiteSpace(directionText))
                return null;

            if (Enum.TryParse(directionText.ToUpper(), out FaceDirection intendedFacingDirection))
            {
                return intendedFacingDirection;
            }
            return null;
        }
    }
}