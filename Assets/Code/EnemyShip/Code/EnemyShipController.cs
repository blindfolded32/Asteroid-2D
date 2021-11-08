using Code.CommonInterfaces;
using Code.EnemyShip.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.EnemyShip.Code
{
    public class EnemyShipController : IEnemyController
    {
        private readonly IEnemyShipModel _enemyShipModel;
        private readonly IEnemyShipView _enemyShipView;


        public EnemyShipController(IEnemyShipModel enemyShipModel, IEnemyShipView enemyShipView)
        {
            _enemyShipModel = enemyShipModel;
            _enemyShipView = enemyShipView;
        }
    }
}