using UnityEngine;
using DonEnglandArt.Asteroids;

namespace Tests
{
    public class AsteroidBuilder
    {
        private Vector3 _position;
        private Vector3 _velocity;
        private float _xSize;
        private float _ySize;
        private int _breakdownsRemaining;
        private int _breakdownPieces;

        public AsteroidBuilder WithPosition(Vector3 position)
        {
            _position = position;
            return this;
        }

        public AsteroidBuilder WithVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            return this;
        }

        public AsteroidBuilder WithSize(float xSize, float ySize)
        {
            _xSize = xSize;
            _ySize = ySize;
            return this;
        }

        public AsteroidBuilder WithBreakdownsRemaining(int breakdownsRemaining)
        {
            _breakdownsRemaining = breakdownsRemaining;
            return this;
        }

        public AsteroidBuilder WithBreakdownPieces(int breakdownPieces)
        {
            _breakdownPieces = breakdownPieces;
            return this;
        }

        private Asteroid Build()
        {
            Asteroid asteroid = new Asteroid(_position, _velocity);
            asteroid.SetSize(_xSize, _ySize);
            asteroid.SetBreakdownsRemaining(_breakdownsRemaining);
            asteroid.SetBreakdownPieces(_breakdownPieces);
            AsteroidManager.Instance.Add(asteroid);
            return asteroid;
        }

        public static implicit operator Asteroid(AsteroidBuilder builder)
        {
            return builder.Build();
        }
    }
}