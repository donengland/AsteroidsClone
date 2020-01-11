﻿using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class InertialThruster
    {
        private readonly Thruster _thruster;
        private readonly SteerableDirection _heading;
        private readonly float _dampenVelocityRate;

        public Vector3 Velocity { get; private set; }

        public InertialThruster(SteerableDirection heading, float dampenVelocityRate, float thrustRate, float maxThrust)
        {
            _thruster = new Thruster(thrustRate, maxThrust);
            _dampenVelocityRate = dampenVelocityRate;
            _heading = heading;
        }

        public void ThrustOn()
        {
            _thruster.ThrustOn();
        }

        public void ThrustOff()
        {
            _thruster.ThrustOff();
        }
        
        public void Tick()
        {
            _thruster.Tick();
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