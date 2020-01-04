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

        public static AsteroidManager Instance => _lazy.Value;
        
        public int AsteroidCount => _asteroids.Count;

        private AsteroidManager()
        {
            _asteroids = new List<Asteroid>();
        }

        public void Breakdown(Asteroid asteroid)
        {
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
                CreateAsteroid(asteroid);
            }
        }

        private void CreateAsteroid(Asteroid asteroid)
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
        }
    }
}