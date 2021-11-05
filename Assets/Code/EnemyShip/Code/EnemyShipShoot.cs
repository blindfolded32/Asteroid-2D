using Code.Bullet;
using Code.CommonInterfaces;
using UnityEngine;

namespace Code.EnemyShip.Code
{
    public class EnemyShipShoot : IFire
    {

        private readonly BulletPool _bulletPool;

        public EnemyShipShoot()
        {
            _bulletPool = new BulletPool(5);
        }
            
        public void Shoot(Transform spawnPosition)
        {
            var _bullet = _bulletPool.GetItem("Bullet");
            _bullet.transform.position = spawnPosition.position;
            _bullet.transform.rotation = spawnPosition.rotation;
            _bullet.gameObject.SetActive(true);           
            _bullet.Rigidbody2D.AddForce(spawnPosition.position ,ForceMode2D.Impulse);
        }
    }
}