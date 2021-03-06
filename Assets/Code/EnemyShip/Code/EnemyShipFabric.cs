using System;
using System.Reflection;
using System.Threading.Tasks;
using Code.CommonClasses;
using Code.EnemyShip.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace Code.EnemyShip.Code
{
    [Serializable]
    public class EnemyShipFabric : IEnemyShipFabric
    {

        public async Task<EnemyShip> Create(UnitShipData unitShipData)
        {
            var Ref =  Addressables.InstantiateAsync((unitShipData.AssetGUID));
            var viewRef = await Ref.Task;
           // var viewRef = await unitShipData.AssetReference.InstantiateAsync().Task;
            var enemyShip = viewRef.GetComponent<EnemyShipView>();
            enemyShip.Health = unitShipData.Health;
            enemyShip.EnemyShipController = new EnemyShipController(new EnemyShipModel(unitShipData.Speed), enemyShip);
            enemyShip.gameObject.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            return enemyShip;
        }
        
      /*  public async Task<EnemyShip> Create(AssetReference assetReference, Health health, float speed)
        {
            var viewRef = await assetReference.InstantiateAsync().Task;
            var enemyShip = viewRef.GetComponent<EnemyShipView>();
            enemyShip.Health = health;
            enemyShip.EnemyShipController = new EnemyShipController(new EnemyShipModel(speed), enemyShip);
            enemyShip.gameObject.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
            return enemyShip;
        }*/
    }
}

//