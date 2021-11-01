using Code.Player.Interfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public class ShipController : IPlayerMovement, IShipRotation
    {
        private readonly IPlayerMovement _moveImplementation;
        private readonly IShipRotation _rotationImplementation;

        public float Speed => _moveImplementation.Speed;

        public ShipController(IPlayerMovement moveImplementation, IShipRotation rotationImplementation)
        {
            _moveImplementation = moveImplementation;
            _rotationImplementation = rotationImplementation;
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            _moveImplementation.Move(horizontal, vertical, deltaTime);
        }

        public void Rotation(Vector3 direction)
        {
            _rotationImplementation.Rotation(direction);
        }

        public void AddAcceleration()
        {
            if (_moveImplementation is PlayerAcceleration accelerationMove)
            {
                accelerationMove.AddAcceleration();
            }
        }

        public void RemoveAcceleration()
        {
            if (_moveImplementation is PlayerAcceleration accelerationMove)
            {
                accelerationMove.RemoveAcceleration();
            }
        }

    }
}