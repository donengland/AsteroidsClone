using DonEnglandArt;
using DonEnglandArt.Asteroids;
using NUnit.Framework;

namespace Tests
{
    public class ThrusterTests
    {
        private float _floatTolerance;

        [SetUp]
        public void before_every_test()
        {
            _floatTolerance = 0.01f;
            TestableTime.ResetTime();
        }
        
        [Test]
        public void thruster_with_1_thrustRate_has_1_current_thrust_after_1_second_on()
        {
            Thruster thruster = A.Thruster.WithMaxThrust(1f).WithThrustRate(1f).WithThrusterOn();
            Assert.AreEqual(0f, thruster.CurrentThrust);
            
            TestableTime.AdvanceSeconds(1f);
            thruster.Tick();
            
            Assert.AreEqual(1f, thruster.CurrentThrust, _floatTolerance);
        }

        [Test]
        public void thruster_with_0_thrustRate_has_0_current_thrust_after_1_second_on()
        {
            Thruster thruster = A.Thruster.WithMaxThrust(1f).WithThrustRate(0f).WithThrusterOn();
            Assert.AreEqual(0f, thruster.CurrentThrust);
            
            TestableTime.AdvanceSeconds(1f);
            thruster.Tick();
            
            Assert.AreEqual(0f, thruster.CurrentThrust, _floatTolerance); 
        }
        
        [Test]
        public void thruster_with_1_thrustRate_and_0_maxThrust_has_0_current_thrust_after_1_second_on()
        {
            Thruster thruster = A.Thruster.WithMaxThrust(0f).WithThrustRate(1f).WithThrusterOn();
            Assert.AreEqual(0f, thruster.CurrentThrust);
            
            TestableTime.AdvanceSeconds(1f);
            thruster.Tick();
            
            Assert.AreEqual(0f, thruster.CurrentThrust, _floatTolerance); 
        }
        
        [Test]
        public void thruster_with_1_thrustRate_and_1_maxThrust_has_0_current_thrust_when_off_after_1_second_on()
        {
            Thruster thruster = A.Thruster.WithMaxThrust(1f).WithThrustRate(1f).WithThrusterOn();
            Assert.AreEqual(0f, thruster.CurrentThrust);
            
            TestableTime.AdvanceSeconds(1f);
            thruster.Tick();
            
            thruster.ThrustOff();
            TestableTime.AdvanceSeconds(1f);
            thruster.Tick();
            
            Assert.AreEqual(0f, thruster.CurrentThrust, _floatTolerance); 
        }
    }
}