﻿using DonEnglandArt.Asteroids;
using UnityEngine;

namespace Tests
{
    public class ShipBuilder
    {
        private Vector3 _position;
        private Vector3 _heading;
        private Vector3 _maxVelocity = Vector3.one;
        private bool _thrustOn;

        public ShipBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public ShipBuilder WithHeading(Vector3 heading)
        {
            _heading = heading;
            return this;
        }

        public ShipBuilder WithThrustOn()
        {
            _thrustOn = true;
            return this;
        }

        public ShipBuilder WithThrustOff()
        {
            _thrustOn = false;
            return this;
        }

        public Ship Build()
        {
            var ship = new Ship(_position, _heading);
            if (_thrustOn) ship.ThrustOn();
            return ship;
        }

        public static implicit operator Ship(ShipBuilder builder)
        {
            return builder.Build();
        }
        
    }
}