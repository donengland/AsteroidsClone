using UnityEngine;

namespace DonEnglandArt
{
    public static class WrapBounds2DSystem
    {
        public static void ProcessMove(IWrapInBounds mover, Bounds bounds)
        {
            if (bounds.Contains(mover.Position)) return;
            WrapXPosition(mover, bounds);
            WrapYPosition(mover, bounds);
        }

        private static float WrapValue(float min, float max, float current)
        {
            var result = 0f;
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

        private static void WrapXPosition(IWrapInBounds mover, Bounds bounds)
        {
            var minX = bounds.min.x - mover.HalfSizeX;
            var maxX = bounds.max.x + mover.HalfSizeX;
            var newX = WrapValue(minX, maxX, mover.Position.x);
            mover.WrapTo(mover.Position.With(x:newX));
        }

        private static void WrapYPosition(IWrapInBounds mover, Bounds bounds)
        {
            var minY = bounds.min.y - mover.HalfSizeY;
            var maxY = bounds.max.y + mover.HalfSizeY;
            var newY = WrapValue(minY, maxY, mover.Position.y);
            mover.WrapTo(mover.Position.With(y:newY));
        }
    }
}