using UnityEngine;

namespace Code.Bullet
{
    public class BulletView
    {
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        
         private void OnCollisionEnter2D(Collision2D other)
        {
          /*  if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }*/
        }
        
    }
}