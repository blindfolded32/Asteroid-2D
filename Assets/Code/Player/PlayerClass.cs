using Code.CommonClasses;
using Code.CommonInterfaces;
using Code.Markers;
using Code.Player.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;

namespace Code.Player
{
    [RequireComponent(typeof(DestroybleObject))]
    public class PlayerClass : MonoBehaviour,ITakeDamage
    {
        private Health _health;
        private static IPlayerController _playerController;
        private Health Health{
            get
            {
                if (_health.Current <= 0) Destroy(gameObject);
                return _health;
            }
            set
        {
            _health = value;
        }
        }
        public static PlayerView CreatePlayer(float speed, float acceleration,Health health, Transform spawnPosition)
        {
            var player = Instantiate( Resources.Load<PlayerView>("Prefabs/Player"), spawnPosition);
            player.Health = health;
            _playerController = new PlayerController(new PlayerModel(speed, acceleration), player);
            return player;
        }
        public PlayerController GetController() => _playerController as PlayerController;
        public void TakeDamage(float damage)
        {
            Health.ChangeCurrentHealth(Health.Current - damage);
        }
    }
}