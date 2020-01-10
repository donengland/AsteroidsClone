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

        public static Vector3 SetMagnitude(this Vector3 original, float maxMagnitude)
        {
            return (original.magnitude > maxMagnitude) ? original.normalized * maxMagnitude : original;
        }

        public static Vector3 Rotate2D(this Vector3 original, float degrees)
        {
            var turnAmount = degrees * TestableTime.deltaTime;
            var newX = original.x * Mathf.Cos(turnAmount) - (original.y * Mathf.Sin(turnAmount));
            var newY = original.x * Mathf.Sin(turnAmount) + (original.y * Mathf.Cos(turnAmount));
            return new Vector3(newX, newY, original.z);
        }
    }
}