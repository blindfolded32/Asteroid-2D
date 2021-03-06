using System;
using System.ComponentModel;
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
        private UnitShipData _enemyShipData;
        private UnitShipData _deepCopyData;
        public AssetReference EnemyShip;
        private bool isReady;

        private void Awake()
        {
            ServiceLocator.ServiceLocator.SetService<BulletPool>(new BulletPool(5));
        }

        private async void Start()
        {
            _enemyShipData = new UnitShipData(EnemyShip.AssetGUID,new Health(unitMaxHealth,unitMaxHealth), _speed);
            _deepCopyData = _enemyShipData.DeepCopy();
            _playerClass = PlayerClass.CreatePlayer(_speed, _acceleration, new Health(unitMaxHealth,unitMaxHealth), FindObjectOfType<PlayerSpawn>().transform);
            _inputManager = new InputManager(_playerClass, Camera.main);
            _asteroidPool = new AsteroidSpawner(_maxAsteroidCount, _asteroidHealth);
            _enemyShipFabric = new EnemyShipFabric();
            await _enemyShipFabric.Create(_enemyShipData);
            isReady = true;
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
            if (!isReady) return;

            if (!FindObjectOfType<AbstractAsteroid>())
            {
                _asteroidPool.SpawnAsteroid(_maxAsteroidCount);
            }

            if (FindObjectOfType<EnemyShip.Code.EnemyShip>()) return;
            _enemyShipFabric.Create( _deepCopyData);
            _deepCopyData = _deepCopyData.DeepCopy();
        }
    }
}

