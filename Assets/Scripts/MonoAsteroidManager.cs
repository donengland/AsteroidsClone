using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public sealed class MonoAsteroidManager : MonoBehaviour
    {
        [SerializeField] private MonoAsteroid _monoAsteroid = null;
        private AsteroidManager _asteroidManager; 
        private void Awake()
        {
            _asteroidManager = AsteroidManager.Instance;
            _asteroidManager.Created += OnAsteroidCreated;
        }

        private void Start()
        {
            _asteroidManager.CreateRandomAsteroids(5);
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

        private void OnDestroy()
        {
            _asteroidManager.Created -= OnAsteroidCreated;
        }
    }
}