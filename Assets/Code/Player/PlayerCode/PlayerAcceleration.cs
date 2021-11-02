using UnityEngine;

namespace Code.Player.PlayerCode


{
    internal sealed class PlayerAcceleration : PlayerMovement
    {
        private float _acceleration;

        public PlayerAcceleration(Rigidbody2D rigidbody2D, float speed, float acceleration) : base(rigidbody2D, speed)
        {
            _acceleration = acceleration;
        }

        public void AddAcceleration()
        {
            Speed += _acceleration;
        }

        public void RemoveAcceleration()
        {
            Speed -= _acceleration;
        }

    }
}