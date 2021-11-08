using System.Collections.Generic;
using UnityEngine;

namespace Code.EnemyShip
{
    internal  sealed class EhemyShipPool
    {
        private Dictionary<string, HashSet<Code.EnemyShip>> _enemyShipPool;
        private readonly int _capacity;
        private readonly Transform _rootTransform;

        public EhemyShipPool(int capacity)
        {
            _enemyShipPool = new Dictionary<string, HashSet<Code.EnemyShip>>();
            _capacity = capacity;
        }

        public Code.EnemyShip GetEnemyShip(string type)
        {
            Code.EnemyShip _enemyShip;
            _enemyShip = null;
            return _enemyShip;
        }
    }
}