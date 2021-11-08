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
        public static IPlayerController PlayerController;
        public Health Health{
            get
            {
                if (_health.Current <= 0) Destroy(gameObject);
                return _health;
            }
        protected set
        {
            _health = value;
        }
        }
        
        public static PlayerView CreatePlayer(float speed, float acceleration,Health health, Transform spawnPosition)
        {
            var player = Instantiate( Resources.Load<PlayerView>("Prefabs/Player"), spawnPosition);
            player.Health = health;
            PlayerController = new PlayerController(new PlayerModel(speed, acceleration), player);
            return player;
        }

        public PlayerController GetController() => PlayerController as PlayerController;

        public void TakeDamage(float damage)
        {
            Health.ChangeCurrentHealth(Health.Current - damage);
        }
    }
}