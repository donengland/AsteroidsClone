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
            UpdateCaller.Update += Update;
        }

        public void DegreesPerSecond(float degrees)
        {
            _turnAngle = degrees;
        }

        private void Update()
        {
            var turnAmount = _turnAngle * TestableTime.deltaTime;
            var newX = Forward.x * Mathf.Cos(turnAmount) - (Forward.y * Mathf.Sin(turnAmount));
            var newY = Forward.x * Mathf.Sin(turnAmount) + (Forward.y * Mathf.Cos(turnAmount));
            Forward = new Vector3(newX, newY, Forward.z);
        }
    }
}