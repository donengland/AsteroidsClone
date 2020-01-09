using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DonEnglandArt.Asteroids
{
    public class Ship : IWrapInBounds, IReceiveShipCommands
    {
        private readonly InertialThruster _thruster;
        private readonly SteerableDirection _heading;
        private float _turnSpeed;
        private bool _turnRight;
        private bool _turnLeft;

        private Transform _transform;

        private Vector3 _position;
        
        public Vector3 Position => _position;
        public float HalfSizeX { get; private set; }
        public float HalfSizeY { get; private set; }

        public Ship(IProvideUpdates updater, Vector3 position, Vector3 heading)
        {
            _position = position;
            HalfSizeX = 0.03f;
            HalfSizeY = 0.03f;
            _turnSpeed = 5f;
            _heading = new SteerableDirection(updater, heading);
            _thruster = new InertialThruster(updater, _heading);
            updater.Update += Tick;
        }

        public void SetTransform(Transform transform)
        {
            _transform = transform;
        }

        public void WrapTo(Vector3 position)
        {
            _position = position;
        }

        private void Tick()
        {
            UpdateHeading();
            UpdatePosition();
            UpdateTransform();
        }

        public void FireOn()
        {
        }

        public void FireOff()
        {
        }

        public void ThrustOn()
        {
            _thruster.ThrustOn();
        }

        public void ThrustOff()
        {
            _thruster.ThrustOff();
        }

        public void TurnLeftBegin()
        {
            _turnLeft = true;
        }

        public void TurnLeftEnd()
        {
            _turnLeft = false;
        }

        public void TurnRightBegin()
        {
            _turnRight = true;
        }

        public void TurnRightEnd()
        {
            _turnRight = false;
        }

        private void UpdateHeading()
        {
            if (!(_turnLeft ^ _turnRight))
            {
                _heading.DegreesPerSecond(0f);
            }
            if (_turnLeft)
            {
                _heading.DegreesPerSecond(_turnSpeed);
            }
            if (_turnRight)
            {
                _heading.DegreesPerSecond(-_turnSpeed);
            }
        }

        private void UpdatePosition()
        {
            _position += TestableTime.deltaTime * _thruster.Velocity;
        }

        private void UpdateTransform()
        {
            if (_transform == null) return; 
            _transform.position = _position;
            _transform.rotation = Quaternion.LookRotation(Vector3.forward, _heading.Forward);
        }
    }
}