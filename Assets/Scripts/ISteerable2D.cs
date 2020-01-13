using UnityEngine;

namespace DonEnglandArt
{
    public interface ISteerable2D
    {
        void DegreesPerSecond(float degrees);
        Vector3 Forward { get; }
    }
}