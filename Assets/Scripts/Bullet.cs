using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class Bullet : IWrapInBounds
    {
        private float _timeToLive;
        public bool Active { get; set; }
        public Vector3 Position { get; private set; }
        public Vector3 Velocity { get; private set; }
        public float HalfSizeX { get; private set; }
        public float HalfSizeY { get; private set; }

        public Bullet(Vector3 position, Vector3 velocity, float timeToLive)
        {
            Position = position;
            Velocity = velocity;
            _timeToLive = timeToLive;
            Active = true;
        }
        
        public void WrapTo(Vector3 position)
        {
            Position = position;
        }

        public void SetSize(float xSize, float ySize)
        {
            HalfSizeX = xSize/2f;
            HalfSizeY = ySize/2f;
        }

        public void Tick()
        {
            if (!Active) return;
            
            Position += TestableTime.deltaTime * Velocity;
            _timeToLive -= TestableTime.deltaTime;
            
            if (_timeToLive <= 0f)
            {
                Active = false;
            }
        }
    }
}