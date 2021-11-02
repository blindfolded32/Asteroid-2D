using Code.Player.Interfaces;
using UnityEngine;
namespace Code.Player.PlayerCode
{
    public class PlayerMovement : IPlayerMovement
    {
        
        private readonly Rigidbody2D _rigidbody2D;
        private Vector2 _move;

        public float Speed { get; protected set; }

        protected PlayerMovement(Rigidbody2D rigidbody2D, float speed)
        {
            _rigidbody2D = rigidbody2D;
            Speed = speed;
        }

        public void Move(float horizontal, float vertical,  float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move = new Vector2(horizontal,vertical);
         _rigidbody2D.AddForce(_move * speed,ForceMode2D.Impulse);
        }

    }
}