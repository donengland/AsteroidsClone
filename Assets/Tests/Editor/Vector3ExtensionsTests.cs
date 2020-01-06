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

        public class PlusExtension
        {
            
        }
    }
}