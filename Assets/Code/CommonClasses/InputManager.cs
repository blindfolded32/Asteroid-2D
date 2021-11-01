using Code.Player.Interfaces;
using UnityEngine;


namespace Code.CommonClasses
{
    public class InputManager
    {
        private readonly IPlayerController _playerController;
        private Camera _camera;
        
        public InputManager(IPlayerController playerController,Camera camera)
        {
            _playerController = playerController;
            _camera = camera;
        }

        public void OnKeyPressed(KeyCode key)
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_playerController.GetTransform().position);
            _playerController.RotateShip(direction);
            
            if (key == KeyCode.LeftShift)
            {
                _playerController.Ship.AddAcceleration();
            }
            
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _playerController.Ship.RemoveAcceleration();
            }
        }
    }
}