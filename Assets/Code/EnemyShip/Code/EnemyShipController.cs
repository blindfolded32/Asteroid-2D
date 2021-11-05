using Code.CommonInterfaces;
using Code.EnemyShip.Interfaces;
using UnityEngine;

namespace Code.EnemyShip.Code
{
    public class EnemyShipController : IEnemyController, IFire
    {
        private readonly IEnemyShipModel _enemyShipModel;
        private readonly IEnemyShipView _enemyShipView;
        [SerializeField]private float _fireDistance = 10.0f;

        public EnemyShipController(IEnemyShipModel enemyShipModel, IEnemyShipView enemyShipView)
        {
            _enemyShipModel = enemyShipModel;
            _enemyShipView = enemyShipView;
        }

        public void Shoot(Transform spawnPosition)
        {
            if (_enemyShipView.NavMeshAgent.remainingDistance < _fireDistance)
            {
                Debug.Log("i wanna die");
            }
        }
    }
}