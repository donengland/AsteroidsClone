namespace DonEnglandArt.Asteroids
{
    public class Thruster
    {
        private readonly float _thrustRate;
        private readonly float _maxThrust;
        private float _currentThrust;
        private bool _thrustOn;

        public float CurrentThrust => _currentThrust;
        public float MaxThrust => _maxThrust;

        public Thruster(float thrustRate, float maxThrust)
        {
            _thrustOn = false;
            _currentThrust = 0f;
            _thrustRate = thrustRate;
            _maxThrust = maxThrust;
        }

        public void ThrustOn()
        {
            _thrustOn = true;
        }

        public void ThrustOff()
        {
            _thrustOn = false;
            _currentThrust = 0f;
        }
        
        public void Tick()
        {
            if (!_thrustOn) return;
            
            _currentThrust += _thrustRate * TestableTime.deltaTime;
            if (_currentThrust > _maxThrust)
                _currentThrust = _maxThrust;
        }
    }
}