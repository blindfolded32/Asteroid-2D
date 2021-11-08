using Code.Bullet;
using Code.CommonClasses;
using Code.CommonInterfaces;
using UnityEngine;


namespace Code.EnemyShip.Code
{
    public class EnemyShipShoot : IFire
    {

        private readonly BulletPool _bulletPool;
        private bool _fired = true;

        public EnemyShipShoot(int capacity)
        {
            _bulletPool = new BulletPool(capacity);
        }

        private bool Fired() => !_fired;
            
        public void Shoot(Transform spawnPosition)
        {
            if (Fired())
            {
                var bullet = _bulletPool.GetItem("Bullet");
                Physics2D.IgnoreCollision(spawnPosition.parent.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
                bullet.Transform.position = spawnPosition.position;
                bullet.Transform.rotation = spawnPosition.rotation;
                bullet.gameObject.SetActive(true);
                bullet.Rigidbody2D.AddForce(bullet.Transform.position * 10, ForceMode2D.Impulse);
            }
        }
    }
}