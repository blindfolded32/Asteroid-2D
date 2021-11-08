using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using Code.Asteroid;
using Code.EnemyShip.Code;
using Code.EnemyShip.Interfaces;
using Code.Markers;

namespace Code
{
    public class GameStarter : MonoBehaviour
    {
        private IPlayerController _playerController;
        private IEnemyShipFabric _enemyShipFabric;
        private AsteroidSpawner _asteroidPool;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private int _maxAsteroidCount;
        private Health _health = new Health(1,1);
        private InputManager _inputManager;
      void Start()
      {
         // _camera = Camera.main;
            _playerController = new PlayerController(new PlayerModel(_speed,_acceleration,_hp), FindObjectOfType<PlayerView>());
            _inputManager =new InputManager(_playerController,Camera.main);
            
           /*AbstractAsteroid.CreateAsteroidEnemy(new Health(3.0f, 3.0f));
            
            IAsteroidFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            AbstractAsteroid.Factory = factory;
            AbstractAsteroid.Factory.Create(new Health(100.0f, 100.0f));*/
           _asteroidPool = new AsteroidSpawner(_maxAsteroidCount, _health);
           _enemyShipFabric = new EnemyShipFabric();
           _enemyShipFabric.Create(new Health(10.0f,10.0f), _speed);
      }
      private void Update()
        {
            _inputManager.Fire(FindObjectOfType<FirePoint>().transform);
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

