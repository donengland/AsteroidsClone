using UnityEngine;
using DonEnglandArt;

namespace Tests
{
    public class SteerableDirectionBuilder
    {
        private Vector3 _forward = Vector3.up;
        private float _degreesPerSecond = 0f;

        public SteerableDirectionBuilder WithForward(Vector3 forward)
        {
            _forward = forward;
            return this;
        }

        public SteerableDirectionBuilder WithDegreesPerSecond(float degreesPerSecond)
        {
            _degreesPerSecond = degreesPerSecond;
            return this;
        }

        private SteerableDirection Build()
        {
            var steerableDirection = new SteerableDirection(_forward);
            steerableDirection.DegreesPerSecond(_degreesPerSecond);
            return steerableDirection;
        }

        public static implicit operator SteerableDirection(SteerableDirectionBuilder builder)
        {
            return builder.Build();
        }
    }
}