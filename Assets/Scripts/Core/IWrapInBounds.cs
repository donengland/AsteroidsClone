using UnityEngine;

namespace DonEnglandArt
{
    public interface IWrapInBounds
    {
        Vector3 Position { get; }
        float HalfSizeX { get; }
        float HalfSizeY { get; }
        void WrapTo(Vector3 position);
    }
}