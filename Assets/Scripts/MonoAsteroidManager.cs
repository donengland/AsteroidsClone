using System;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public sealed class MonoAsteroidManager : MonoBehaviour
    {
        [SerializeField] private MonoAsteroid _monoAsteroid; 
        private void Awake()
        {
            AsteroidManager.Instance.Created += OnAsteroidCreated;
        }

        private void Start()
        {
            AsteroidManager.Instance.CreateRandomAsteroids(5);
        }

        private void OnAsteroidCreated(Asteroid asteroid)
        {
            if (_monoAsteroid == null)
            {
                Debug.LogWarning($"{this.GetType().Name} expected {typeof(MonoAsteroid).Name} but was null");
                return;
            }
            
            MonoAsteroid go = Instantiate(_monoAsteroid);
            go.SetAsteroid(asteroid);
        }
    }
}