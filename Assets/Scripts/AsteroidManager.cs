using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DonEnglandArt.Asteroids
{
    public sealed class AsteroidManager
    {
        private List<Asteroid> _asteroids;
        private static readonly Lazy<AsteroidManager>
            _lazy = new Lazy<AsteroidManager>(()=> new AsteroidManager());

        private Bounds _spaceBounds;
        
        public static AsteroidManager Instance => _lazy.Value;
        public event Action<int> Scored;
        
        public int AsteroidCount => _asteroids.Count;

        private AsteroidManager()
        {
            _asteroids = new List<Asteroid>();
            _spaceBounds = new Bounds(Vector3.zero, new Vector3(16f, 9f, 0f));
            UpdateCaller.Update += Tick;
        }

        private void Tick()
        {
            foreach (var asteroid in _asteroids)
            {
                asteroid.Tick();
            }
        }

        public void Breakdown(Asteroid asteroid)
        {
            Scored?.Invoke((asteroid.BreakdownsRemaining + 1) * 100);
            if (asteroid.BreakdownsRemaining > 0)
            {
                CreateBreakdownAsteroids(asteroid);
            }
            _asteroids.Remove(asteroid);
        }

        private void CreateBreakdownAsteroids(Asteroid asteroid)
        {
            for (int i = 0; i < asteroid.BreakdownPieces; i++)
            {
                CreateRandomAsteroid(asteroid);
            }
        }

        private void CreateRandomAsteroid(Asteroid asteroid)
        {
            var position = asteroid.Position.Plus(
                Random.Range(-asteroid.HalfSizeX, asteroid.HalfSizeX),
                Random.Range(-asteroid.HalfSizeY, asteroid.HalfSizeY), 0f);
            var velocity = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);
            var breakDownAsteroid = new Asteroid(position, velocity);
            Add(breakDownAsteroid);
        }

        public void Add(Asteroid asteroid)
        {
            _asteroids.Add(asteroid);
        }

        public void Reset()
        {
            _asteroids.Clear();
            UpdateCaller.Update -= Tick;
            UpdateCaller.Update += Tick;
        }

        public Bounds GetBounds()
        {
            return _spaceBounds;
        }
    }
}