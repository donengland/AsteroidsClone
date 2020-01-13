using DonEnglandArt;
using DonEnglandArt.Asteroids;
using NUnit.Framework;

namespace Tests
{
    public class FloatAccleratorTests
    {
        private float _floatTolerance;

        [SetUp]
        public void before_every_test()
        {
            _floatTolerance = 0.01f;
            TestableTime.ResetTime();
        }
        
        [Test]
        public void floatAccelerator_with_1_accelerationRate_has_1_current_acceleration_after_1_second_on()
        {
            FloatAccelerator floatAccelerator = A.FloatAccelerator.WithMaxAcceleration(1f).WithAccelerationRate(1f).WithAccelerationOn();
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration);
            
            TestableTime.AdvanceSeconds(1f);
            floatAccelerator.Tick();
            
            Assert.AreEqual(1f, floatAccelerator.CurrentAcceleration, _floatTolerance);
        }

        [Test]
        public void floatAccelerator_with_0_accelerationRate_has_0_current_acceleration_after_1_second_on()
        {
            FloatAccelerator floatAccelerator = A.FloatAccelerator.WithMaxAcceleration(1f).WithAccelerationRate(0f).WithAccelerationOn();
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration);
            
            TestableTime.AdvanceSeconds(1f);
            floatAccelerator.Tick();
            
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration, _floatTolerance); 
        }
        
        [Test]
        public void floatAccelerator_with_1_accelerationRate_and_0_maxAcceleration_has_0_current_acceleration_after_1_second_on()
        {
            FloatAccelerator floatAccelerator = A.FloatAccelerator.WithMaxAcceleration(0f).WithAccelerationRate(1f).WithAccelerationOn();
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration);
            
            TestableTime.AdvanceSeconds(1f);
            floatAccelerator.Tick();
            
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration, _floatTolerance); 
        }
        
        [Test]
        public void floatAccelerator_with_1_accelerationRate_and_1_maxAcceleration_has_0_current_acceleration_when_off_after_1_second_on()
        {
            FloatAccelerator floatAccelerator = A.FloatAccelerator.WithMaxAcceleration(1f).WithAccelerationRate(1f).WithAccelerationOn();
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration);
            
            TestableTime.AdvanceSeconds(1f);
            floatAccelerator.Tick();
            
            floatAccelerator.AccelerationOff();
            TestableTime.AdvanceSeconds(1f);
            floatAccelerator.Tick();
            
            Assert.AreEqual(0f, floatAccelerator.CurrentAcceleration, _floatTolerance); 
        }
    }
}