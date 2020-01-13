using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace DonEnglandArt.Asteroids
{
    public class Ship : IWrapInBounds, IReceiveShipCommands
    {
        public static event Action<Ship> Fire;
        
        private readonly InertialThruster _thruster;
        private readonly SteerableDirection _heading;
        private float _turnSpeed;
        private bool _turnRight;
        private bool _turnLeft;
        private bool _firing;

        private Cooldown _fireCooldown;

        private Transform _transform;
        private Vector3 _position;

        public Vector3 Position => _position;
        public Vector3 Heading => _heading.Forward;
        public Vector3 Velocity => _thruster.Velocity;
        public float HalfSizeX { get; private set; }
        public float HalfSizeY { get; private set; }

        public Ship(Vector3 position, Vector3 heading)
        {
            _position = position;
            HalfSizeX = 0.03f;
            HalfSizeY = 0.03f;
            _turnSpeed = 270f;
            _fireCooldown = new Cooldown(0.35f);
            _heading = new SteerableDirection(heading);
            _thruster = new InertialThruster(_heading, 0.2f, 0.1f, 8f);
        }

        public void SetTransform(Transform transform)
        {
            _transform = transform;
        }

        public void WrapTo(Vector3 position)
        {
            _position = position;
        }

        public void Tick()
        {
            UpdateHeading();
            UpdatePosition();
            UpdateTransform();
            UpdateFiring();
        }

        public void FireOn()
        {
            _firing = true;
        }

        public void FireOff()
        {
            _firing = false;
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
                _heading.DegreesPerSecond(-_turnSpeed);
            }
            if (_turnRight)
            {
                _heading.DegreesPerSecond(_turnSpeed);
            }
            _heading.Tick();
        }

        private void UpdatePosition()
        {
            _thruster.Tick();
            _position += TestableTime.deltaTime * _thruster.Velocity;
        }

        private void UpdateTransform()
        {
            if (!_transform) return; 
            _transform.position = _position;
            _transform.rotation = Quaternion.LookRotation(Vector3.forward, _heading.Forward);
        }

        private void UpdateFiring()
        {
            _fireCooldown.Tick();
            if (_fireCooldown.IsReady && _firing)
            {
                _fireCooldown.Reset();
                Fire?.Invoke(this);
            }
        }
    }
}