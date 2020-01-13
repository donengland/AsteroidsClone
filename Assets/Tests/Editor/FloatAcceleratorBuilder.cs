using DonEnglandArt.Asteroids;

namespace Tests
{
    public class FloatAcceleratorBuilder
    {
        private float _accelerationRate;
        private float _maxAcceleration;
        private bool _accelerationOn;

        public FloatAcceleratorBuilder WithAccelerationRate(float accelerationRate)
        {
            _accelerationRate = accelerationRate;
            return this;
        }

        public FloatAcceleratorBuilder WithMaxAcceleration(float maxAcceleration)
        {
            _maxAcceleration = maxAcceleration;
            return this;
        }

        public FloatAcceleratorBuilder WithAccelerationOn()
        {
            _accelerationOn = true;
            return this;
        }

        public FloatAcceleratorBuilder WithThrusterOff()
        {
            _accelerationOn = false;
            return this;
        }

        private FloatAccelerator Build()
        {
            var floatAccelerator = new FloatAccelerator(_accelerationRate, _maxAcceleration);
            if(_accelerationOn) floatAccelerator.AccelerationOn();
            return floatAccelerator;
        }

        public static implicit operator FloatAccelerator(FloatAcceleratorBuilder builder)
        {
            return builder.Build();
        }
    }
}