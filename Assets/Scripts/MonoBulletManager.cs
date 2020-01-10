using System;
using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public sealed class MonoBulletManager : MonoBehaviour
    {
        [SerializeField] private MonoBullet _monoBullet = null;
        private BulletManager _bulletManager;

        private void Awake()
        {
            _bulletManager = BulletManager.Instance;
            _bulletManager.Created += OnBulletCreated;
        }

        // private void Update()
        // {
        //     Debug.Log($"BulletManager.Instance.BulletCount: {BulletManager.Instance.BulletCount}");
        // }

        private void OnBulletCreated(Bullet bullet)
        {
            if (_monoBullet == null)
            {
                Debug.LogWarning($"{this.GetType().Name} expected {typeof(MonoBullet).Name} but was null");
                return;
            }
            
            MonoBullet go = Instantiate(_monoBullet);
            go.SetBullet(bullet);
        }
    }
}