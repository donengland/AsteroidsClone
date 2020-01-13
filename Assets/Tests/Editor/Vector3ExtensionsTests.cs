using DonEnglandArt;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Vector3ExtensionsTests
    {
        public class WithExtension
        {
            private Vector3 _input;
            
            [SetUp]
            public void before_every_test()
            {
                _input = new Vector3(5f,5f,5f);
            }

            [Test]
            public void _with_0_params_does_not_change_original()
            {
                var output = _input.With();
                Assert.AreEqual(_input, output);
            }
            
            [Test]
            public void with_x_param_does_not_change_y_or_z()
            {
                var expectedOutput = new Vector3(2f, 5f, 5f);
                var output = _input.With(x: 2);
                Assert.AreEqual(expectedOutput, output);
            }
            
            [Test]
            public void with_y_param_does_not_change_x_or_z()
            {
                var expectedOutput = new Vector3(5f, 2f, 5f);
                var output = _input.With(y: 2);
                Assert.AreEqual(expectedOutput, output);
            }
            
            [Test]
            public void with_z_param_does_not_change_y_or_x()
            {
                var expectedOutput = new Vector3(5f, 5f, 2f);
                var output = _input.With(z: 2);
                Assert.AreEqual(expectedOutput, output);
            }
        }

        public class Rotate2DExtension
        {
            private const float RotationTolerance = 0.01f;

            [Test]
            public void rotate_up_PI_over_2_returns_right()
            {
                var result = Vector3.up.RotateOnZ(Mathf.PI/2f);
                var resultX = result.x;
                var resultY = result.y;
                
                Assert.AreEqual(Vector3.right.x, resultX, RotationTolerance);
                Assert.AreEqual(Vector3.right.y, resultY, RotationTolerance);
            }
            
            [Test]
            public void rotate_up_negative_PI_over_2_returns_right()
            {
                var result = Vector3.up.RotateOnZ(-Mathf.PI/2f);
                var resultX = result.x;
                var resultY = result.y;
                
                Assert.AreEqual(Vector3.left.x, resultX, RotationTolerance);
                Assert.AreEqual(Vector3.left.y, resultY, RotationTolerance);
            }
            
            [Test]
            public void rotate_up_PI_returns_down()
            {
                var result = Vector3.up.RotateOnZ(Mathf.PI);
                var resultX = result.x;
                var resultY = result.y;
                
                Assert.AreEqual(Vector3.down.x, resultX, RotationTolerance);
                Assert.AreEqual(Vector3.down.y, resultY, RotationTolerance);
            }
            
            [Test]
            public void rotate_up_2_PI_returns_up()
            {
                var result = Vector3.up.RotateOnZ(2f*Mathf.PI);
                var resultX = result.x;
                var resultY = result.y;
                
                Assert.AreEqual(Vector3.up.x, resultX, RotationTolerance);
                Assert.AreEqual(Vector3.up.y, resultY, RotationTolerance);
            }
        }
    }
}