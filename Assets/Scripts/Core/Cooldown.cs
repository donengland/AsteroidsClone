using System;

namespace DonEnglandArt.Asteroids
{
    public class Cooldown
    {
        private float _seconds;
        private float _current;

        public bool IsReady => _current <= 0f;

        public Cooldown(float seconds)
        {
            _seconds = seconds;
        }

        public void Reset()
        {
            _current = _seconds;
        }

        public void Tick()
        {
            if (_current <= 0) return;
            _current -= TestableTime.deltaTime;
        }
    }
}