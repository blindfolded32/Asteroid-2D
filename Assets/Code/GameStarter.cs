using System;
using Code.CommonClasses;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using System.Collections;

namespace Code
{
    public class GameStarter : MonoBehaviour
    {
        private Camera _camera;
        private IPlayerController _playerController;
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _hp;
        

      //  private InputManager _inputManager;
      void Start()
        {
            _camera = Camera.main;
            _playerController = new PlayerController(new PlayerModel(_speed,_acceleration,_hp), FindObjectOfType<PlayerView>());
        }

        private void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerController.GetTransform().position);
            _playerController.RotateShip(direction);
            _playerController.Ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.fixedDeltaTime);
            if (Input.GetKeyDown(KeyCode.LeftShift)) _playerController.Ship.AddAcceleration();
            if (Input.GetKeyUp(KeyCode.LeftShift)) _playerController.Ship.RemoveAcceleration();
        }
    }
}

