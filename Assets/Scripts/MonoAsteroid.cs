using System;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class MonoAsteroid : MonoBehaviour
    {
        [SerializeField] private Vector3 _velocity = Vector3.zero;
        private Asteroid _asteroid;

        public void SetAsteroid(Asteroid asteroid)
        {
            _asteroid = asteroid;
        }

        private void Update()
        {
            if (_asteroid == null) return;
            transform.position = _asteroid.Position;
        }

        public void Breakdown()
        {
            _asteroid?.Breakdown();
            Destroy(gameObject);
        }
    }
}