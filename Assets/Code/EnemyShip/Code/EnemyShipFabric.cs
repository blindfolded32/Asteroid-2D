using System;
using Code.CommonClasses;
using Code.EnemyShip.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.EnemyShip.Code
{
    [Serializable]
    public class EnemyShipFabric : IEnemyShipFabric
    {
        public EnemyShip Create(Health health, float speed)
        {
            var enemyShip = Object.Instantiate(Resources.Load<EnemyShipView>("Prefabs/EnemyShip"));
            enemyShip.Health = health;
            health.ChangeCurrentHealth(health.Max);
            enemyShip.EnemyShipController = new EnemyShipController(new EnemyShipModel(speed),enemyShip);
            enemyShip.gameObject.transform.position = new Vector2(Random.Range(-10.0f,10.0f),Random.Range(-10.0f,10.0f));
            return enemyShip;
        }
    }
}