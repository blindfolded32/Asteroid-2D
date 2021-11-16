using System;
using Code.CommonClasses;

namespace Code.EnemyShip
{
    [Serializable]
    public class UnitShipData
    {
        public Health Health;
        public float Speed;

        public UnitShipData(Health health, float speed)
        {
            Health = health;
            Speed = speed;
        }
    }
}