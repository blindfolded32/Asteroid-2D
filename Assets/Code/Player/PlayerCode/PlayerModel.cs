using System;
using Code.Player.Interfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    public struct PlayerModel : IPlayerModel
    
    {
       public float Speed { get; set; }
        public float Acceleration { get; set; }
        public float Hp { get; set; }

        public PlayerModel(float speed, float acceleration, float hp)
        {
            Speed = speed;
            Acceleration = acceleration;
            Hp = hp;
        }
    }
}