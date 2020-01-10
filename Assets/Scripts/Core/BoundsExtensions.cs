using UnityEngine;

namespace DonEnglandArt
{
    public static class BoundsExtensions
    {
        public static Vector3 PointOnBounds2D(this Bounds original)
        {
            var pointOnBounds = new Vector3(Random.Range(original.min.x, original.max.x),
                Random.Range(original.min.y, original.max.y), 0f);

            var useX = (Random.value > 0.5f);
            if (useX)
            {
                if (pointOnBounds.x > 0 && pointOnBounds.x < original.max.x)
                    pointOnBounds.x = original.max.x;
                else if (pointOnBounds.x <= 0 && pointOnBounds.x > original.min.x)
                    pointOnBounds.x = original.min.x;
            }
            else
            {
                if (pointOnBounds.y > 0 && pointOnBounds.y < original.max.y)
                    pointOnBounds.y = original.max.y;
                else if (pointOnBounds.y <= 0 && pointOnBounds.y > original.min.y)
                    pointOnBounds.y = original.min.y;
            }
            
            return pointOnBounds;
        }
    }
}