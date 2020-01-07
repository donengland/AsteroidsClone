using UnityEngine;
using NUnit.Framework;
using DonEnglandArt;
using DonEnglandArt.Asteroids;

namespace Tests
{
    public class ShipTests
    {
        private const float _distanceTolerance = 0.105f;
        
        [SetUp]
        public void before_every_test()
        {
            TestableTime.ResetTime();
            UpdateCaller.Reset();
        }
        
        [Test]
        public void ship_updates_position_based_on_velocity()
        {
            Ship ship = A.Ship.WithPosition(Vector3.zero).WithHeading(Vector3.up).WithThrustOn();
            
            TestableTime.AdvanceSeconds(1.75f);
            UpdateCaller.SendUpdate();
            
            var distance = Vector3.Distance(Vector3.up, ship.Position);
            Assert.AreEqual(0f, distance, _distanceTolerance);
        }
    }
}