using System;
using Code.CommonClasses;

namespace Code.EnemyShip
{
    [Serializable]
    public class EnemyShipData
    {
        public Health Health;
        public float Speed;

        public EnemyShipData(Health health, float speed)
        {
            Health = health;
            Speed = speed;
        }
    }
}