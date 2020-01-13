using NUnit.Framework;
using DonEnglandArt;
using DonEnglandArt.Asteroids;
using UnityEngine;

namespace Tests
{
    public class CooldownTests
    {
        private Cooldown _cooldown;

        [SetUp]
        public void before_every_test()
        {
            TestableTime.ResetTime();
            _cooldown = new Cooldown(1f);
        }
        
        [Test]
        public void cooldown_1_second_shows_IsReady_on_creation()
        {
            Assert.AreEqual(true, _cooldown.IsReady);
        }
        
        [Test]
        public void cooldown_1_second_shows_IsReady_false_half_second_after_reset()
        {
            _cooldown.Reset();
            TestableTime.AdvanceSeconds(0.5f);
            _cooldown.Tick();
            
            Assert.AreEqual(false, _cooldown.IsReady);
        }
        
        [Test]
        public void cooldown_1_second_shows_IsReady_true_1_second_after_reset()
        {
            _cooldown.Reset();
            TestableTime.AdvanceSeconds(1f);
            _cooldown.Tick();
            
            Assert.AreEqual(true, _cooldown.IsReady);
        }
    }
    public class SteerableDirectionTests
    {
        private const float RotationTolerance = 0.01f;
        
        [SetUp]
        public void before_every_test()
        {
            TestableTime.ResetTime();
        }
        
        [Test]
        public void _turning_90_degrees_updates_forward_90_degrees()
        {
            SteerableDirection steerableDirection = A.SteerableDirection.WithDegreesPerSecond(90f);
            Assert.AreEqual(Vector3.up, steerableDirection.Forward);
            
            TestableTime.AdvanceSeconds(1f - TestableTime.deltaTime);
            steerableDirection.Tick();
            
            var result = steerableDirection.Forward;
            var resultX = result.x;
            var resultY = result.y;
                
            Assert.AreEqual(Vector3.right.x, resultX, RotationTolerance);
            Assert.AreEqual(Vector3.right.y, resultY, RotationTolerance);
        }
        
        [Test]
        public void _turning_180_degrees_updates_forward_180_degrees()
        {
            SteerableDirection steerableDirection = A.SteerableDirection.WithDegreesPerSecond(180f);
            Assert.AreEqual(Vector3.up, steerableDirection.Forward);
            
            TestableTime.AdvanceSeconds(1f - TestableTime.deltaTime);
            steerableDirection.Tick();
            
            var result = steerableDirection.Forward;
            var resultX = result.x;
            var resultY = result.y;
                
            Assert.AreEqual(Vector3.down.x, resultX, RotationTolerance);
            Assert.AreEqual(Vector3.down.y, resultY, RotationTolerance);
        }
    }
}