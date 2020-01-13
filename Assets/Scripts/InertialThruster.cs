using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class InertialThruster
    {
        private readonly FloatAccelerator _floatAccelerator;
        private readonly SteerableDirection _heading;
        private readonly float _dampenVelocityRate;

        public Vector3 Velocity { get; private set; }

        public InertialThruster(SteerableDirection heading, float dampenVelocityRate, float thrustRate, float maxThrust)
        {
            _floatAccelerator = new FloatAccelerator(thrustRate, maxThrust);
            _dampenVelocityRate = dampenVelocityRate;
            _heading = heading;
        }

        public void ThrustOn()
        {
            _floatAccelerator.AccelerationOn();
        }

        public void ThrustOff()
        {
            _floatAccelerator.AccelerationOff();
        }
        
        public void Tick()
        {
            _floatAccelerator.Tick();
            Velocity += _floatAccelerator.CurrentAcceleration * _heading.Forward;
            Velocity = Velocity.SetMagnitude(_floatAccelerator.MaxAcceleration);
            DampenVelocity();
        }
        
        private void DampenVelocity()
        {
            Velocity = Vector3.Lerp(Velocity, Vector3.zero, _dampenVelocityRate * TestableTime.deltaTime);
        }
    }
}