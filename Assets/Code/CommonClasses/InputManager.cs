using Code.Player.Interfaces;
using UnityEngine;


namespace Code.CommonClasses
{
    public class InputManager
    {
        private readonly IPlayerController _playerController;
       
        
        public InputManager(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void OnKeyPressed(Event _event)
        {
            
            
            if (_event.keyCode == KeyCode.LeftShift)
            {
                _playerController.Ship.AddAcceleration();
            }
            if (_event.keyCode == KeyCode.W)
            {
                _playerController.Ship.Move(Input.GetAxis("Horizontal"), 0, Time.deltaTime);
            }
        }
    }
}