using Code.CommonClasses;

namespace Code.EnemyShip.Interfaces
{
    public interface IEnemyShipFabric
    {
        Code.EnemyShip Create(Health health, float speed);
    }
}