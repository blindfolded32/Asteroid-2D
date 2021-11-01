using UnityEngine;

namespace Code.Player.PlayerCode


{
    internal sealed class PlayerAcceleration : PlayerMovement
    {
        private readonly float _acceleration;

        public PlayerAcceleration(Transform transform, float speed, float acceleration) : base(transform, speed)
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