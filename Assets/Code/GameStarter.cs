using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using Code.Asteroid;
using Code.EnemyShip.Code;
using Code.EnemyShip.Interfaces;
using Code.Markers;
using Random = UnityEngine.Random;

namespace Code
{
    public class GameStarter : MonoBehaviour
    {
        private Camera _camera;
        private IPlayerController _playerController;
        private Vector3 _direction;
        private Transform _spawnPosition;
        private IEnemyShipFabric _enemyShipFabric;
        private AsteroidSpawner _asteroidPool;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private int _maxAsteroidCount;
        

      //  private InputManager _inputManager;
      void Start()
      {
          _spawnPosition = FindObjectOfType<FirePoint>().transform;
            _camera = Camera.main;
            _playerController = new PlayerController(new PlayerModel(_speed,_acceleration,_hp), FindObjectOfType<PlayerView>());
            
            
           /*AbstractAsteroid.CreateAsteroidEnemy(new Health(3.0f, 3.0f));
            
            IAsteroidFactory factory = new AsteroidFactory();
            factory.Create(new Health(100.0f, 100.0f));

            AbstractAsteroid.Factory = factory;
            AbstractAsteroid.Factory.Create(new Health(100.0f, 100.0f));*/
           _asteroidPool = new AsteroidSpawner(_maxAsteroidCount);
           //_asteroidPool.SpawnAsteroid(_maxAsteroidCount);
           _enemyShipFabric = new EnemyShipFabric();
           _enemyShipFabric.Create(new Health(10.0f,10.0f), _speed);
      }
      private void Update()
        {
            _direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerController.GetTransform().position);
            if (Input.GetKeyDown(KeyCode.LeftShift)) _playerController.Ship.AddAcceleration();
            if (Input.GetKeyUp(KeyCode.LeftShift)) _playerController.Ship.RemoveAcceleration();
            if (Input.GetKeyUp(KeyCode.Mouse0)) _playerController.PlayerShoot.Shoot(FindObjectOfType<FirePoint>().transform);
        }
        private void LateUpdate()
        {
            _playerController.RotateShip(_direction);
            _playerController.Ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.fixedDeltaTime);
            if (!FindObjectOfType<AbstractAsteroid>())
            {
                _asteroidPool.SpawnAsteroid(_maxAsteroidCount);
            }
        }
    }
}

