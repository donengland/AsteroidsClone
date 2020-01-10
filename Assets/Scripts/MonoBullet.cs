using UnityEngine;

namespace DonEnglandArt.Asteroids
{
    public class MonoBullet : MonoBehaviour
    {
        [SerializeField] private Vector3 _velocity = Vector3.zero;
        private Bullet _bullet;

        public void SetBullet(Bullet bullet)
        {
            _bullet = bullet;
            transform.position = _bullet.Position;
        }

        private void Update()
        {
            if (_bullet == null) return;
            
            transform.position = _bullet.Position;
            
            if (!_bullet.Active)
                Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            var asteroid = other.gameObject.GetComponent<MonoAsteroid>();
            if (asteroid == null) return;
            
            asteroid.Breakdown();
            _bullet.Active = false;
        }
    }
}