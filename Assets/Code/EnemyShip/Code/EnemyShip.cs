using Code.CommonClasses;
using Code.CommonInterfaces;
using UnityEngine;

namespace Code.EnemyShip.Code
{
    public abstract class EnemyShip : MonoBehaviour, ITakeDamage
    {
        private Health _health;
        public Health Health
        {
            get
            {
                if (_health.Current <=0.0f) Destroy(gameObject);
                return _health;
            }
            set=> _health = value;
        }

        public EnemyShipShoot EnemyShipShoot;
        public EnemyShipController EnemyShipController;
        public void TakeDamage(float damage)
        {
            Debug.Log($"Don't hurt me{Health.Current}");
            _health.ChangeCurrentHealth(Health.Current - damage);
        }
    }
}