namespace Code.Player.Interfaces
{
    public interface IPlayerMovement
    {
        float Speed { get; }
        void Move(float horizontal, float vertical, float deltaTime);
    }
}