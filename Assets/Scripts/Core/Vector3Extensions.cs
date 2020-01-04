using UnityEngine;

namespace DonEnglandArt
{
    public static class Vector3Extensions
    {
        public static Vector3 Plus(this Vector3 original, float? x = null, float? y = null, float? z = null)
        {
            return (original + new Vector3(x ?? 0, y ?? 0, z ?? 0));
        }
        
        public static Vector3 With(this Vector3 original, float? x = null, float? y = null, float? z = null)
        {
            return new Vector3(x ?? original.x, y ?? original.y, z ?? original.z);
        }
    }
}