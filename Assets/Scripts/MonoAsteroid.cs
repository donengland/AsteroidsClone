using System;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class MonoAsteroid : MonoBehaviour
    {
        [SerializeField] private Vector3 _velocity = Vector3.zero;
        [SerializeField] private Bounds _bounds;
        private Asteroid _asteroid;
        private void Awake()
        {
            _bounds = AsteroidManager.Instance.GetBounds();
        }

        public void SetAsteroid(Asteroid asteroid)
        {
            _asteroid = asteroid;
        }

        private void Update()
        {
            if (_asteroid == null) return;
            
            WrapBounds2DSystem.ProcessMove(_asteroid, _bounds);
            transform.position = _asteroid.Position;
        }
    }
}