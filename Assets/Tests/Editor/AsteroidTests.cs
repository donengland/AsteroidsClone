using NUnit.Framework;
using UnityEngine;
using DonEnglandArt;
using DonEnglandArt.Asteroids;

namespace Tests
{
    public class AsteroidTests
    {
        private float _distanceTolerance;
        private UpdateManager _updateManager;

        public AsteroidTests()
        {
            _updateManager = UpdateManager.Instance;
        }
        
        [SetUp]
        public void before_every_test()
        {
            _distanceTolerance = 0.105f;
            TestableTime.ResetTime();
            _updateManager.Reset();
            AsteroidManager.Instance.Reset();
        }
        
        [Test]
        public void asteroids_update_their_position_based_on_velocity()
        {
            Asteroid asteroid = An.Asteroid.WithPosition(Vector3.zero).WithVelocity(Vector3.up);
            
            TestableTime.AdvanceSeconds(1f);
            _updateManager.SendUpdate();
            
            var distance = Vector3.Distance(Vector3.up, asteroid.Position);
            Assert.AreEqual(0f, distance, _distanceTolerance);
        }

        public class BreakdownMethod
        {
            private AsteroidManager _asteroidManager;

            [SetUp]
            public void before_every_test()
            {
                _asteroidManager = AsteroidManager.Instance;
            }
            
            [Test]
            public void asteroid_with_3_breakdownsRemaining_breaks_into_2_smaller_asteroids()
            {
                var breakdownsRemaining = 3;
                var breakdownPieces = 2;
                _asteroidManager.Reset();
                Asteroid asteroid = An.Asteroid.
                    WithBreakdownsRemaining(breakdownsRemaining).
                    WithBreakdownPieces(breakdownPieces);
                _asteroidManager.Add(asteroid);
                var initialAsteroidCount= _asteroidManager.AsteroidCount;
                
                asteroid.Breakdown();
                Assert.AreEqual(breakdownsRemaining-1, asteroid.BreakdownsRemaining);
                Assert.AreEqual(initialAsteroidCount + breakdownPieces - 1, _asteroidManager.AsteroidCount);
            }
            
            [Test]
            public void asteroid_with_0_breakdownsRemaining_does_not_break_into_smaller_asteroids()
            {
                _asteroidManager.Reset();
                Asteroid asteroid = An.Asteroid.WithBreakdownsRemaining(0).WithBreakdownPieces(2);
                _asteroidManager.Add(asteroid);
                var initialAsteroidCount= _asteroidManager.AsteroidCount;
                
                asteroid.Breakdown();
                Assert.AreEqual(initialAsteroidCount - 1, _asteroidManager.AsteroidCount);
            }
        }

        public class WrapToMethod
        {
            private float _distanceTolerance;
            private const float _worldSize = 5f; 
            private const float _asteroidSize = 1f;
            private const float _velocityMagnitude = 1f;
            private float _halfWorldSize => _worldSize * 0.5f;
            private float _halfAsteroidSize => _asteroidSize * 0.5f;
            private float _halfWorldPlusAsteroidSize => _halfWorldSize + _halfAsteroidSize;
            private Bounds _worldBounds;
            private UpdateManager _updateManager;

            public WrapToMethod()
            {
                _updateManager = UpdateManager.Instance;
            }

            private void AdvanceOneSecondAndUpdate()
            {
                TestableTime.AdvanceSeconds(1f);
                _updateManager.SendUpdate();
            }
            
            [SetUp]
            public void before_every_test()
            {
                var centerPosition = Vector3.zero;
                var worldSize = new Vector3(_worldSize,_worldSize,_worldSize);
                _worldBounds = new Bounds(centerPosition, worldSize);
                _distanceTolerance = 0.105f;
                TestableTime.ResetTime();
                _updateManager.Reset();
                AsteroidManager.Instance.Reset();
            }

            [Test]
            public void asteroid_wraps_position_when_traveling_negative_on_x()
            {
                var endPosition = new Vector3(_halfWorldPlusAsteroidSize - 1f,0,0);
                Asteroid asteroid = An.Asteroid.
                    WithPosition(new Vector3(-_halfWorldPlusAsteroidSize, 0,0)).
                    WithVelocity(new Vector3(-_velocityMagnitude, 0, 0)).
                    WithSize(_asteroidSize, _asteroidSize);
                
                AdvanceOneSecondAndUpdate();
                
                WrapBounds2DSystem.ProcessMove(asteroid, _worldBounds);
                var distance = Vector3.Distance(endPosition, asteroid.Position);
                Assert.AreEqual(0f, distance, _distanceTolerance);
            }

            [Test]
            public void asteroid_wraps_position_when_traveling_positive_on_x()
            {
                var endPosition = new Vector3(-_halfWorldPlusAsteroidSize + 1f,0,0);
                Asteroid asteroid = An.Asteroid.
                    WithPosition(new Vector3(_halfWorldPlusAsteroidSize, 0,0)).
                    WithVelocity(new Vector3(_velocityMagnitude, 0, 0)).
                    WithSize(_asteroidSize, _asteroidSize);
                
                AdvanceOneSecondAndUpdate();
                
                WrapBounds2DSystem.ProcessMove(asteroid, _worldBounds);
                var distance = Vector3.Distance(endPosition, asteroid.Position);
                Assert.AreEqual(0f, distance, _distanceTolerance);
            }

            [Test]
            public void asteroid_wraps_position_when_traveling_negative_on_y()
            {
                var endPosition = new Vector3(2, _halfWorldPlusAsteroidSize - 1f,0);
                Asteroid asteroid = An.Asteroid.
                    WithPosition(new Vector3(2,-_halfWorldPlusAsteroidSize, 0)).
                    WithVelocity(new Vector3(0,-_velocityMagnitude, 0)).
                    WithSize(_asteroidSize, _asteroidSize);
                
                AdvanceOneSecondAndUpdate();
                
                WrapBounds2DSystem.ProcessMove(asteroid, _worldBounds);
                var distance = Vector3.Distance(endPosition, asteroid.Position);
                Assert.AreEqual(0f, distance, _distanceTolerance);
            }

            [Test]
            public void asteroid_wraps_position_when_traveling_positive_on_y()
            {
                var endPosition = new Vector3(0,-_halfWorldPlusAsteroidSize + 1f,0);
                Asteroid asteroid = An.Asteroid.
                    WithPosition(new Vector3(0,_halfWorldPlusAsteroidSize, 0)).
                    WithVelocity(new Vector3(0,_velocityMagnitude, 0)).
                    WithSize(_asteroidSize, _asteroidSize);
                
                AdvanceOneSecondAndUpdate();
                
                WrapBounds2DSystem.ProcessMove(asteroid, _worldBounds);
                var distance = Vector3.Distance(endPosition, asteroid.Position);
                Assert.AreEqual(0f, distance, _distanceTolerance);
            }

            [Test]
            public void asteroid_wraps_position_when_traveling_diagonally_positive_on_x_and_y()
            {
                var bonusOffset = 1.07f;
                var endPosition = new Vector3(-_halfWorldPlusAsteroidSize + bonusOffset,-_halfWorldPlusAsteroidSize + bonusOffset,0f);
                Asteroid asteroid = An.Asteroid.
                    WithPosition(new Vector3(_halfWorldPlusAsteroidSize,_halfWorldPlusAsteroidSize, 0f)).
                    WithVelocity(new Vector3(_velocityMagnitude,_velocityMagnitude, 0f)).
                    WithSize(_asteroidSize, _asteroidSize);
                
                AdvanceOneSecondAndUpdate();
                
                WrapBounds2DSystem.ProcessMove(asteroid, _worldBounds);
                var distance = Vector3.Distance(endPosition, asteroid.Position);
                Assert.AreEqual(0f, distance, _distanceTolerance);
            }
        }
    }
}
