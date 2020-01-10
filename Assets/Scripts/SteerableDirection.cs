using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class SteerableDirection : ISteerable2D
    {
        private float _turnAngle;
        public Vector3 Forward { get; private set; }

        public SteerableDirection(Vector3 forward)
        {
            _turnAngle = 0;
            Forward = forward;
        }

        public void DegreesPerSecond(float degrees)
        {
            _turnAngle = degrees;
        }

        public void Tick()
        {
            Forward = Forward.Rotate2D(_turnAngle);
        }
    }
}