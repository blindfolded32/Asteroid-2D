using Code.Bullet;
using Code.CommonInterfaces;
using UnityEngine;

namespace Code.EnemyShip.Code
{
    public class EnemyShipShoot : IFire
    {

        private readonly BulletPool _bulletPool;

        public EnemyShipShoot(int capacity)
        {
            _bulletPool = new BulletPool(capacity);
        }
            
        public void Shoot(Transform spawnPosition)
        {
            var _bullet = _bulletPool.GetItem("Bullet");
            Physics2D.IgnoreCollision(spawnPosition.parent.GetComponent<Collider2D>(),_bullet.GetComponent<Collider2D>());
            _bullet.Transform.position = spawnPosition.position;
            _bullet.Transform.rotation = spawnPosition.rotation;
            _bullet.gameObject.SetActive(true);           
            _bullet.Rigidbody2D.AddForce(_bullet.Transform.position * 10 ,ForceMode2D.Impulse);
        }
    }
}