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
            _asteroid = new Asteroid(transform.position, _velocity);
            AsteroidManager.Instance.Add(_asteroid);
        }

        private void Update()
        {
            WrapBounds2DSystem.ProcessMove(_asteroid, _bounds);
            transform.position = _asteroid.Position;
        }
    }
}