using System;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class Asteroid : IWrapInBounds
    {
        private Vector3 _position;
        private readonly Vector3 _velocity;
        private int _breakdownsRemaining;
        private int _breakdownPieces;

        public int BreakdownsRemaining => _breakdownsRemaining;

        public Vector3 Position => _position;
        public float HalfSizeX { get; private set; }
        public float HalfSizeY { get; private set; }
        public int BreakdownPieces => _breakdownPieces;

        public void WrapTo(Vector3 position)
        {
            _position = position;
        }

        public Asteroid(Vector3 position, Vector3 velocity)
        {
            _position = position;
            _velocity = velocity;
        }

        public void Tick()
        {
            _position += TestableTime.deltaTime * _velocity;
        }

        public void SetSize(float xSize, float ySize)
        {
            HalfSizeX = xSize/2f;
            HalfSizeY = ySize/2f;
        }

        public void SetBreakdownsRemaining(int breakdownsRemaining)
        {
            _breakdownsRemaining = breakdownsRemaining;
        }

        public void SetBreakdownPieces(int breakdownPieces)
        {
            _breakdownPieces = breakdownPieces;
        }

        public void Breakdown()
        {
            _breakdownsRemaining--;
            AsteroidManager.Instance.Breakdown(this);
        }
    }
}