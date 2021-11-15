using Code.Bullet;
using Code.CommonInterfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public class PlayerShoot: IFire

    {
        private readonly BulletPool _bulletPool;
        public PlayerShoot()
        {
           _bulletPool = ServiceLocator.ServiceLocator.Resolve<BulletPool>(); //_bulletPool = new BulletPool(capacity);
        }
        public void Shoot(Transform spawnPosition)
        {
          var bullet = _bulletPool.GetItem("Bullet");
          Physics2D.IgnoreCollision(spawnPosition.parent.GetComponent<Collider2D>(),bullet.GetComponent<Collider2D>());
          bullet.Transform.position = spawnPosition.position;
          bullet.Transform.rotation = spawnPosition.rotation;
           bullet.gameObject.SetActive(true);   
           bullet._timeToDie = Time.time;
          Bullet.BulletCode.Bullet.GetOrAddComponent<Rigidbody2D>(bullet.gameObject).AddForce(bullet.Transform.position.normalized * 10 ,ForceMode2D.Impulse);
        }
    }
}