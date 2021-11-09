using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using Code.Asteroid;
using Code.Asteroid.AsteroidCode;
using Code.EnemyShip.Code;
using Code.EnemyShip.Interfaces;
using Code.Markers;
using Code.Player;
using static Code.ConfigVars;

namespace Code
{
    public class GameStarter : MonoBehaviour
    {       
        private IEnemyShipFabric _enemyShipFabric;
        private AsteroidSpawner _asteroidPool;
        private InputManager _inputManager;
        private PlayerClass _playerClass;

        private void Start()
      {       
       _playerClass = PlayerClass.CreatePlayer(ConfigVars._speed, ConfigVars._acceleration, ConfigVars._hp,
            FindObjectOfType<PlayerSpawn>().transform);
         _inputManager =new InputManager(_playerClass,Camera.main);
           _asteroidPool = new AsteroidSpawner(ConfigVars._maxAsteroidCount,ConfigVars._asteroidHealth);
           _enemyShipFabric = new EnemyShipFabric();
           _enemyShipFabric.Create(new Health(10.0f,10.0f), _speed);
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
        }
    }
}

