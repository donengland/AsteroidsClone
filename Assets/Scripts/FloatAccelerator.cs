namespace DonEnglandArt.Asteroids
{
    public class FloatAccelerator
    {
        private readonly float _accelerationRate;
        private readonly float _maxAcceleration;
        private float _currentAcceleration;
        private bool _accelerationOn;

        public float CurrentAcceleration => _currentAcceleration;
        public float MaxAcceleration => _maxAcceleration;

        public FloatAccelerator(float accelerationRate, float maxAcceleration)
        {
            _accelerationOn = false;
            _currentAcceleration = 0f;
            _accelerationRate = accelerationRate;
            _maxAcceleration = maxAcceleration;
        }

        public void AccelerationOn()
        {
            _accelerationOn = true;
        }

        public void AccelerationOff()
        {
            _accelerationOn = false;
            _currentAcceleration = 0f;
        }
        
        public void Tick()
        {
            if (!_accelerationOn) return;
            
            _currentAcceleration += _accelerationRate * TestableTime.deltaTime;
            if (_currentAcceleration > _maxAcceleration)
                _currentAcceleration = _maxAcceleration;
        }
    }
}