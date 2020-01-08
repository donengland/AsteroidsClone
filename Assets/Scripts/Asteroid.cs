using System;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class Asteroid : IWrapInBounds
    {
        public static event Action<Asteroid> breakdown;
        
        public int BreakdownsRemaining { get; private set; }

        public Vector3 Position { get; private set; }

        public Vector3 Velocity { get; private set; }

        public float HalfSizeX { get; private set; }
        public float HalfSizeY { get; private set; }
        public int BreakdownPieces { get; private set; }

        public void WrapTo(Vector3 position)
        {
            Position = position;
        }

        public Asteroid(Vector3 position, Vector3 velocity)
        {
            Position = position;
            Velocity = velocity;
        }

        public void Tick()
        {
            Position += TestableTime.deltaTime * Velocity;
        }

        public void SetSize(float xSize, float ySize)
        {
            HalfSizeX = xSize/2f;
            HalfSizeY = ySize/2f;
        }

        public void SetBreakdownsRemaining(int breakdownsRemaining)
        {
            BreakdownsRemaining = breakdownsRemaining;
        }

        public void SetBreakdownPieces(int breakdownPieces)
        {
            BreakdownPieces = breakdownPieces;
        }

        public void Breakdown()
        {
            BreakdownsRemaining--;
            breakdown?.Invoke(this);
        }
    }
}