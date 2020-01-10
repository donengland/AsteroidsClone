﻿using System;
using UnityEngine;
using NUnit.Framework;
using DonEnglandArt;
using DonEnglandArt.Asteroids;
using NSubstitute;

namespace Tests
{
    public class ShipTests
    {
        private const float _distanceTolerance = 0.105f;
        private IProvideUpdates _updater;
        
        [SetUp]
        public void before_every_test()
        {
            _updater = Substitute.For<IProvideUpdates>();
            TestableTime.ResetTime();
        }
        
        [Test]
        public void ship_updates_position_when_thrusters_on()
        {
            Ship ship = A.Ship.WithPosition(Vector3.zero).WithThrustOn();
            
            TestableTime.AdvanceSeconds(1f);
            ship.Tick();
            
            Assert.AreNotEqual(Vector3.zero, ship.Position);
        }
    }
}