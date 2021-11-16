using Code.CommonClasses;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Code.EnemyShip.Interfaces
{
    public interface IEnemyShipFabric
    {
        Code.EnemyShip Create(AssetReference enemyShipRef, Health health, float speed);
    }
}