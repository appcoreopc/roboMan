using System;
 
namespace RoboMan.Util
{
    static class ExtensionToFacingDirection
    {
        internal static FaceDirection? ToDirection(this string directionText)
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