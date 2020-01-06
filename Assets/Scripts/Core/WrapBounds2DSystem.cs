using UnityEngine;

namespace DonEnglandArt
{
    public static class WrapBounds2DSystem
    {
        public static void ProcessMove(IWrapInBounds mover, Bounds bounds)
        {
            if (bounds.Contains(mover.Position)) return;
            var newX = WrapXPosition(mover, bounds);
            var newY = WrapYPosition(mover, bounds);
            mover.WrapTo(mover.Position.With(x:newX, y:newY));
        }

        public static float WrapValue(float min, float max, float current)
        {
            var result = current;
            if (current < min)
            {
                var overshoot = current - min;
                result = max + overshoot;
            }
            else if (current > max)
            {
                var overshoot = current - max;
                result = min + overshoot;
            }

            return result;
        }

        public static float WrapXPosition(IWrapInBounds mover, Bounds bounds)
        {
            var minX = bounds.min.x - mover.HalfSizeX;
            var maxX = bounds.max.x + mover.HalfSizeX;
            var newX = WrapValue(minX, maxX, mover.Position.x);
            return newX;
        }

        public static float WrapYPosition(IWrapInBounds mover, Bounds bounds)
        {
            var minY = bounds.min.y - mover.HalfSizeY;
            var maxY = bounds.max.y + mover.HalfSizeY;
            var newY = WrapValue(minY, maxY, mover.Position.y);
            return newY;
        }
    }
}