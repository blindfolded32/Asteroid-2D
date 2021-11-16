using System;
using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using Code.Asteroid;
using Code.Asteroid.AsteroidCode;
using Code.Bullet;
using Code.EnemyShip;
using Code.EnemyShip.Code;
using Code.EnemyShip.Interfaces;
using Code.Markers;
using Code.Player;
using UnityEngine.AddressableAssets;
using static Code.ConfigVars;

namespace Code
{
    public class GameStarter : MonoBehaviour
    {       
        private IEnemyShipFabric _enemyShipFabric;
        private AsteroidSpawner _asteroidPool;
        private InputManager _inputManager;
        private PlayerClass _playerClass;
        private EnemyShipData _enemyShipData;
        private EnemyShipData _deepCopyData;
        AssetReference EnemyShip;

        private void Awake()
        {
            ServiceLocator.ServiceLocator.SetService<BulletPool>(new BulletPool(5));
        }

        private void Start()
        {
           EnemyShip.LoadAssetAsync<EnemyShipView>();
            _enemyShipData = new EnemyShipData(_hp,_speed);
          _deepCopyData = _enemyShipData.DeepCopy();
       _playerClass = PlayerClass.CreatePlayer(_speed, _acceleration, _hp,
            FindObjectOfType<PlayerSpawn>().transform);
         _inputManager =new InputManager(_playerClass,Camera.main);
           _asteroidPool = new AsteroidSpawner(_maxAsteroidCount,_asteroidHealth);
           _enemyShipFabric = new EnemyShipFabric();
           _enemyShipFabric.Create(EnemyShip,_enemyShipData.Health,_enemyShipData.Speed);
           
      }
      private void Update()
        {
            _inputManager.Fire(FindObjectOfType<PlayerView>().GetComponentInChildren<FirePoint>().transform);
        }
        private void FixedUpdate()
        {
            _inputManager.GetMovement();
           
        }
        private void LateUpdate()
        {
            if (!FindObjectOfType<AbstractAsteroid>())
            {
                _asteroidPool.SpawnAsteroid(_maxAsteroidCount);
            }

            if (!FindObjectOfType<EnemyShip.Code.EnemyShip>())
            {
                
                _enemyShipFabric.Create(EnemyShip,_deepCopyData.Health,_deepCopyData.Speed);
            }
        }
    }
}

