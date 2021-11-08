using Code.Player.Interfaces;
using UnityEngine;


namespace Code.CommonClasses
{
    public class InputManager
    {
       private readonly IPlayerController _playerController;
        private Transform _transform;
        private Camera _camera;

       public InputManager(IPlayerController player, Camera camera)
        {
            _playerController = player;
            _transform = player.GetTransform();
            _camera = camera;
        }

       public void GetMovement()
       {
           Move();
           Rotation();
           if (Input.GetKeyDown(KeyCode.LeftShift)) Acceleration();
           if (Input.GetKeyUp(KeyCode.LeftShift)) RemoveAcceleration();
       }
        private void Move()
        {
            _playerController.Ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.fixedDeltaTime);
        }

        private void Rotation()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(_transform.position);
            _playerController.Ship.Rotation(direction);
        }
        private void Acceleration()=>_playerController.Ship.AddAcceleration();
        private void RemoveAcceleration() =>  _playerController.Ship.RemoveAcceleration();

        public void Fire(Transform firePoint)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Debug.Log(firePoint.position);
                _playerController.PlayerShoot.Shoot(firePoint);
            }
        }
    }
}