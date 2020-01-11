using DonEnglandArt.Asteroids;

namespace Tests
{
    public class ThrusterBuilder
    {
        private float _thrustRate;
        private float _maxThrust;
        private bool _thrusterOn;

        public ThrusterBuilder WithThrustRate(float thrustRate)
        {
            _thrustRate = thrustRate;
            return this;
        }

        public ThrusterBuilder WithMaxThrust(float maxThrust)
        {
            _maxThrust = maxThrust;
            return this;
        }

        public ThrusterBuilder WithThrusterOn()
        {
            _thrusterOn = true;
            return this;
        }

        public ThrusterBuilder WithThrusterOff()
        {
            _thrusterOn = false;
            return this;
        }

        private Thruster Build()
        {
            var thruster = new Thruster(_thrustRate, _maxThrust);
            if(_thrusterOn) thruster.ThrustOn();
            return thruster;
        }

        public static implicit operator Thruster(ThrusterBuilder builder)
        {
            return builder.Build();
        }
    }
}