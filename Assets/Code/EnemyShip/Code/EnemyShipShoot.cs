using Code.Bullet;
using Code.CommonClasses;
using Code.CommonInterfaces;
using UnityEngine;


namespace Code.EnemyShip.Code
{
    public class EnemyShipShoot : IFire
    {

        private readonly BulletPool _bulletPool;
        private readonly float _fireRate = 0.5f;
        private float _nextShot;

        public EnemyShipShoot(int capacity)
        {
            _bulletPool = new BulletPool(capacity);
        }
            
        public void Shoot(Transform spawnPosition)
        {
            if (Time.time > _fireRate + _nextShot)
            {
                _nextShot = Time.time + _fireRate;
                
                var bullet = _bulletPool.GetItem("Bullet");
                Physics2D.IgnoreCollision(spawnPosition.parent.GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
                bullet.Transform.position = spawnPosition.position;
                bullet.Transform.rotation = spawnPosition.rotation;
                bullet.gameObject.SetActive(true);
                bullet.Rigidbody2D.AddForce(bullet.Transform.position.normalized * 10, ForceMode2D.Impulse);
            }
        }
    }
}