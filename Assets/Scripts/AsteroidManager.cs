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
        public event Action<Asteroid> Created;
        
        public int AsteroidCount => _asteroids.Count;

        private AsteroidManager()
        {
            _asteroids = new List<Asteroid>();
            _spaceBounds = new Bounds(Vector3.zero, new Vector3(16f, 9f, 0f));
            Subscribe();
        }

        public void Add(Asteroid asteroid)
        {
            _asteroids.Add(asteroid);
        }

        public void Reset()
        {
            _asteroids.Clear();
            Unsubscribe();
            Subscribe();
        }

        public Bounds GetBounds()
        {
            return _spaceBounds;
        }

        private void OnTick()
        {
            foreach (var asteroid in _asteroids)
            {
                asteroid.Tick();
            }
        }

        private void OnBreakdown(Asteroid asteroid)
        {
            Scored?.Invoke((4 - asteroid.BreakdownsRemaining) * 100);
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
                CreateAsteroidAt(PositionInAsteroidBounds(asteroid));
            }
        }

        private void CreateAsteroidAt(Vector3 position)
        {
            var velocity = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f), 0f);
            var asteroid = new Asteroid(position, velocity);
            Add(asteroid);
            Created?.Invoke(asteroid);
        }

        private Vector3 PositionInAsteroidBounds(Asteroid asteroid)
        {
            return asteroid.Position.Plus(
                Random.Range(-asteroid.HalfSizeX, asteroid.HalfSizeX),
                Random.Range(-asteroid.HalfSizeY, asteroid.HalfSizeY), 0f);
        }

        public void CreateRandomAsteroids(int count)
        {
            for (int i = 0; i < count; i++)
            {
                CreateAsteroidAt(PositionOnSpaceBounds());
            }
        }

        private Vector3 PositionOnSpaceBounds()
        {
            var position = new Vector3(Random.Range(_spaceBounds.min.x, _spaceBounds.max.x),
                Random.Range(_spaceBounds.min.y, _spaceBounds.max.y), 0f);
            return _spaceBounds.ClosestPoint(position);
        }

        private void Subscribe()
        {
            UpdateManager.Instance.Update += OnTick;
            Asteroid.breakdown += OnBreakdown;
        }

        private void Unsubscribe()
        {
            UpdateManager.Instance.Update -= OnTick;
            Asteroid.breakdown -= OnBreakdown;
        }
    }
}