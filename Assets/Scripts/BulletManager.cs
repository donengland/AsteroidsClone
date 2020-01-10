using System;
using System.Collections.Generic;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public sealed class BulletManager
    {
        private List<Bullet> _bullets;
        private static readonly Lazy<BulletManager>
            _lazy = new Lazy<BulletManager>(()=> new BulletManager());

        private float _bulletSpeed = 5f;
        private float _bulletTTL = 1.5f;
        private Bounds _spaceBounds;

        public static BulletManager Instance => _lazy.Value;
        public event Action<Bullet> Created;

        public int BulletCount => _bullets.Count;

        private BulletManager()
        {
            _bullets = new List<Bullet>();
            _spaceBounds = AsteroidManager.Instance.GetBounds();
            Subscribe();
        }

        private void OnTick()
        {
            for (int i = _bullets.Count-1; i >= 0; i--)
            {
                _bullets[i].Tick(); // NOTE: Inconsistent updating
                WrapBounds2DSystem.ProcessMove(_bullets[i], _spaceBounds);
                if (!_bullets[i].Active)
                {
                    _bullets.RemoveAt(i);
                }
            }
        }

        private void OnCreateBullet(Ship ship)
        {
            var bullet = new Bullet(ship.Position, (ship.Heading * _bulletSpeed) + ship.Velocity, _bulletTTL);
            _bullets.Add(bullet);
            Created?.Invoke(bullet);
        }

        private void Subscribe()
        {
            UpdateManager.Instance.Update += OnTick;
            Ship.Fire += OnCreateBullet;
        }
        
        private void Unsubscribe()
        {
            UpdateManager.Instance.Update -= OnTick;
            Ship.Fire -= OnCreateBullet;
        }
    }
}