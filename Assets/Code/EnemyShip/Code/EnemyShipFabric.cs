using Code.CommonClasses;
using Code.EnemyShip.Interfaces;
using UnityEngine;

namespace Code.EnemyShip.Code
{
    public class EnemyShipFabric : IEnemyShipFabric
    {
        public EnemyShip Create(Health health, float speed)
        {
            var enemyShip = Object.Instantiate(Resources.Load<EnemyShipView>("Prefabs/EnemyShip"));
            enemyShip.Health = health;
            enemyShip.EnemyShipController = new EnemyShipController(new EnemyShipModel(speed),enemyShip);
            enemyShip.gameObject.transform.position = new Vector2(Random.Range(-10.0f,10.0f),Random.Range(-10.0f,10.0f));
            return enemyShip;
        }
    }
}