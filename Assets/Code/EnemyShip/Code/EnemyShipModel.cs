using System;
using Code.EnemyShip.Interfaces;

namespace Code.EnemyShip.Code
{
    [Serializable]
    public struct EnemyShipModel : IEnemyShipModel
    {
        public float Speed { get; }

        public EnemyShipModel(float speed)
        {
            Speed = speed;
        }
    }
}