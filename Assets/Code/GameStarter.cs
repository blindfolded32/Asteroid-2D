using System;
using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using System.Collections;
using Code.Asteroid;
using Code.Asteroid.Interfaces;
using Code.Bullet;
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
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        [SerializeField] private int _maxAsteroidCount;
        private int _asteroidCount = 0;
        

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
           
           AsteroidPool enemyPool = new AsteroidPool(_maxAsteroidCount);

           for (int i = 0; i < _maxAsteroidCount; i++)
           {
               var asteroid = enemyPool.GetEnemy("Asteroid");
               asteroid.transform.position = new Vector3(Random.Range(-10.0f,10.0f),Random.Range(-10.0f,10.0f),0.0f);
               asteroid.gameObject.SetActive(true);
           }
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
        }
    }
}

