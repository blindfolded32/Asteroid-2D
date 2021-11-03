using Code.Bullet;
using Code.CommonInterfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public class PlayerShoot: IFire

    {
       // private Bullet.Bullet _bullet;
        private BulletPool _bulletPool;

        public PlayerShoot()
        {
           _bulletPool = new BulletPool(3);
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