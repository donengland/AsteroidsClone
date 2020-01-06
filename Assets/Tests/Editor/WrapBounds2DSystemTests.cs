using DonEnglandArt;
using DonEnglandArt.Asteroids;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class WrapBounds2DSystemTests
    {
        public class WrapValueMethod
        {
            private const float _tolerance = 0.05f;
            
            [Test]
            public void wrap_value_min_0_max_5_current_5_returns_5()
            {
                var result = WrapBounds2DSystem.WrapValue(0f, 5f, 5f);
                Assert.AreEqual(5f, result, _tolerance);
            }
            
            [Test]
            public void wrap_value_min_0_max_5_current_0_returns_0()
            {
                var result = WrapBounds2DSystem.WrapValue(0f, 5f, 0f);
                Assert.AreEqual(0f, result, _tolerance);
            }
            
            [Test]
            public void wrap_value_min_0_max_5_current_6_returns_1()
            {
                var result = WrapBounds2DSystem.WrapValue(0f, 5f, 6f);
                Assert.AreEqual(1f, result, _tolerance);
            }
            
            [Test]
            public void wrap_value_min_negative_5_max_5_current_6_returns_negative_4()
            {
                var result = WrapBounds2DSystem.WrapValue(-5f, 5f, 6f);
                Assert.AreEqual(-4f, result, _tolerance);
            }
            
            [Test]
            public void wrap_value_min_negative_5_max_5_current_negative_6_returns_4()
            {
                var result = WrapBounds2DSystem.WrapValue(-5f, 5f, -6f);
                Assert.AreEqual(4f, result, _tolerance);
            }
        }

        public class WrapXPositionTests
        {
            private Bounds _worldBounds;
            private const float halfSize = 0.5f;
            private IWrapInBounds _wrapper;

            [SetUp]
            public void before_every_test()
            {
                _worldBounds = AsteroidManager.Instance.GetBounds();
                _wrapper = Substitute.For<IWrapInBounds>();
                _wrapper.HalfSizeX.Returns(halfSize);
                _wrapper.HalfSizeY.Returns(halfSize);
            }
            
            [Test]
            public void wrapXPosition_does_not_wrap_when_at_bounds()
            {
                var startPosition = new Vector3(_worldBounds.max.x + halfSize, 0f, 0f);
                _wrapper.Position.Returns(startPosition);
                var result = WrapBounds2DSystem.WrapXPosition(_wrapper, _worldBounds);
                Assert.AreEqual(startPosition.x, result);
            }
            
            [Test]
            public void wrapXPosition_does_wrap_by_1_when_over_bounds_by_1()
            {
                var startPosition = new Vector3(_worldBounds.max.x + halfSize + 1f, 0f, 0f);
                var endPosition = new Vector3(_worldBounds.min.x - halfSize + 1f, 0f, 0f);
                _wrapper.Position.Returns(startPosition);
                var result = WrapBounds2DSystem.WrapXPosition(_wrapper, _worldBounds);
                Assert.AreEqual(endPosition.x, result);
            }
        }
        
        public class ProcessMoveMethod
        {
            private Bounds _worldBounds;
            private const float halfSize = 0.5f;
            private IWrapInBounds _wrapper;
            
            [SetUp]
            public void before_every_test()
            {
                _worldBounds = AsteroidManager.Instance.GetBounds();
                _wrapper = Substitute.For<IWrapInBounds>();
                _wrapper.HalfSizeX.Returns(halfSize);
                _wrapper.HalfSizeY.Returns(halfSize);
            }
            
            [Test]
            public void wraps_positive_y()
            {
                var startPosition = new Vector3(0f, _worldBounds.max.y + halfSize + 1f, 0f);
                var endPosition = new Vector3(0f, _worldBounds.min.y - halfSize + 1f, 0f);
                _wrapper.Position.Returns(startPosition);
                WrapBounds2DSystem.ProcessMove(_wrapper, _worldBounds);
                _wrapper.Received().WrapTo(endPosition);
            }
            
            [Test]
            public void wraps_negative_y()
            {
                var startPosition = new Vector3(0f, _worldBounds.min.y - halfSize - 1f, 0f);
                var endPosition = new Vector3(0f, _worldBounds.max.y + halfSize - 1f, 0f);
                _wrapper.Position.Returns(startPosition);
                WrapBounds2DSystem.ProcessMove(_wrapper, _worldBounds);
                _wrapper.Received().WrapTo(endPosition);
            }
            
            [Test]
            public void wraps_positive_x()
            {
                var startPosition = new Vector3(_worldBounds.max.x + halfSize + 1f, 0f, 0f);
                var endPosition = new Vector3(_worldBounds.min.x - halfSize + 1f, 0f, 0f);
                _wrapper.Position.Returns(startPosition);
                WrapBounds2DSystem.ProcessMove(_wrapper, _worldBounds);
                _wrapper.Received().WrapTo(endPosition);
            }
            
            [Test]
            public void wraps_negative_x()
            {
                var startPosition = new Vector3(_worldBounds.min.x - halfSize - 1f, 0f, 0f);
                var endPosition = new Vector3(_worldBounds.max.x + halfSize - 1f, 0f, 0f);
                _wrapper.Position.Returns(startPosition);
                WrapBounds2DSystem.ProcessMove(_wrapper, _worldBounds);
                _wrapper.Received().WrapTo(endPosition);
            }
            
            [Test]
            public void wraps_positive_x_and_y()
            {
                var startPosition = new Vector3(_worldBounds.max.x + halfSize + 1f, _worldBounds.max.y + halfSize + 1f, 0f);
                var endPosition = new Vector3(_worldBounds.min.x - halfSize + 1f, _worldBounds.min.y - halfSize + 1f, 0f);
                _wrapper.Position.Returns(startPosition);
                WrapBounds2DSystem.ProcessMove(_wrapper, _worldBounds);
                _wrapper.Received().WrapTo(endPosition);
            }
            
            [Test]
            public void wraps_negative_x_and_y()
            {
                var startPosition = new Vector3(_worldBounds.min.x - halfSize - 1f, _worldBounds.min.y - halfSize - 1f, 0f);
                var endPosition = new Vector3(_worldBounds.max.x + halfSize - 1f, _worldBounds.max.y + halfSize - 1f, 0f);
                _wrapper.Position.Returns(startPosition);
                WrapBounds2DSystem.ProcessMove(_wrapper, _worldBounds);
                _wrapper.Received().WrapTo(endPosition);
            }
        }
    }
}