using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public interface ISteerable2D
    {
        void DegreesPerSecond(float degrees);
        Vector3 Forward { get; }
    }
}