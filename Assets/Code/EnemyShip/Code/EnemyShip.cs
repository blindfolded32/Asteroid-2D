using Code.CommonClasses;
using Code.CommonInterfaces;
using UnityEngine;

namespace Code.EnemyShip.Code
{
    public abstract class EnemyShip : MonoBehaviour, ITakeDamage
    {
        private Health _health;
        public Health Health { get => _health; set=> _health = value; }
        public EnemyShipShoot EnemyShipShoot;
        public EnemyShipController EnemyShipController;
        public void TakeDamage(float damage)
        {
            Debug.Log("Don't hurt me");
            _health.ChangeCurrentHealth(Health.Max - damage);
        }
    }
}