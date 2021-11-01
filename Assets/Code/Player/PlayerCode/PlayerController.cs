using Code.Player.Interfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public class PlayerController : IPlayerController
    {
        private readonly IPlayerView _playerView;
        public ShipController Ship { get; set; }
       
        [SerializeField] private Rigidbody2D _bullet;
        [SerializeField] private Transform _barrel;
        [SerializeField] private float _force;
        public PlayerController(IPlayerModel playerModel, IPlayerView playerView)
        {
            var playerModel1 = playerModel;
            _playerView = playerView;
            var moveTransform = new PlayerAcceleration(_playerView.Transform, playerModel1.Speed, playerModel1.Acceleration);
            var rotation = new PlayerShip(_playerView.Transform);
            Ship = new ShipController(moveTransform, rotation);
        }

        public Transform GetTransform() => _playerView.Transform;
        

        public void RotateShip(Vector3 direction)
        {
            Ship.Rotation(direction);
        }
        
       /* private void OnCollisionEnter2D(Collision2D other)
        {
            if (_hp <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                _hp--;
            }
        }*/
    }
}