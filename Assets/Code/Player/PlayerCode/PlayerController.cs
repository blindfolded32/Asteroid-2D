using Code.Player.Interfaces;
using Code.Ship.ShipCode;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public class PlayerController : IPlayerController
    {
        private readonly IPlayerView _playerView;
        public ShipController Ship { get; set; }
        public PlayerController(IPlayerModel playerModel, IPlayerView playerView)
        {
            var playerModel1 = playerModel;
            _playerView = playerView;
            var moveTransform = new PlayerAcceleration(_playerView.Rigidbody2D, playerModel1.Speed, playerModel1.Acceleration);
            var rotation = new PlayerShip(_playerView.Transform);
            Ship = new ShipController(moveTransform, rotation);
        }
        public Transform GetTransform() => _playerView.Transform;
        public void RotateShip(Vector3 direction)
        {
            Ship.Rotation(direction);
        }
        
        
       
    }
}