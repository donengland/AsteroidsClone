using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class InertialThruster
    {
        private readonly Thruster _thruster;
        private readonly SteerableDirection _heading;
        private readonly float _dampenVelocityRate;

        public Vector3 Velocity { get; private set; }

        public InertialThruster(SteerableDirection heading)
        {
            _thruster = new Thruster();
            _dampenVelocityRate = 0.2f;
            _heading = heading;
            UpdateCaller.Update += Update;
        }

        public void ThrustOn()
        {
            _thruster.ThrustOn();
        }

        public void ThrustOff()
        {
            _thruster.ThrustOff();
        }
        
        private void Update()
        {
            Velocity += _thruster.CurrentThrust * _heading.Forward;
            Velocity = Velocity.SetMagnitude(_thruster.MaxThrust);
            DampenVelocity();
        }
        
        private void DampenVelocity()
        {
            Velocity = Vector3.Lerp(Velocity, Vector3.zero, _dampenVelocityRate * TestableTime.deltaTime);
        }
    }
}