using Code.CommonClasses;
using Code.EnemyShip.Code;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Code.EnemyShip.Interfaces
{
    public interface IEnemyShipFabric
    {
        Code.EnemyShip Create(AssetReference assetReference, Health health, float speed);
    }
}