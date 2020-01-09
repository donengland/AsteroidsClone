using System;
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
        public void ship_updates_position_based_on_velocity()
        {
            Ship ship = A.Ship.WithPosition(Vector3.zero).
                WithUpdateProvider(_updater).
                WithHeading(Vector3.up).
                WithThrustOn();
            
            TestableTime.AdvanceSeconds(3f);
            _updater.Update += Raise.Event<Action>();
            
            var distance = Vector3.Distance(Vector3.up, ship.Position);
            Assert.AreEqual(0f, distance, _distanceTolerance);
        }
    }
}