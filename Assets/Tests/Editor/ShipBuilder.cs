﻿using UnityEngine;
using DonEnglandArt;
using DonEnglandArt.Asteroids;

namespace Tests
{
    public class ShipBuilder
    {
        private Vector3 _position = Vector3.zero;
        private Vector3 _heading = Vector3.up;
        private Vector3 _maxVelocity = Vector3.one;
        private bool _thrustOn;
        private bool _firing;

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

        public ShipBuilder WithFiringOn()
        {
            _firing = true;
            return this;
        }

        private Ship Build()
        {
            var ship = new Ship(_position, _heading);
            if (_thrustOn) ship.ThrustOn();
            if (_firing) ship.FireOn();
            return ship;
        }

        public static implicit operator Ship(ShipBuilder builder)
        {
            return builder.Build();
        }
        
    }
}