using Code.Player.Interfaces;

namespace Code.Player.PlayerCode
{
    public struct PlayerModel : IPlayerModel
    
    {
       public float Speed { get; set; }
        public float Acceleration { get; set; }

        public PlayerModel(float speed, float acceleration)
        {
            Speed = speed;
            Acceleration = acceleration;
        }
    }
}