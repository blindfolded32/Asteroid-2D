using System;
using System.ComponentModel;
using Code.CommonClasses;
using Unity.Collections;
using UnityEngine.AddressableAssets;

namespace Code.EnemyShip
{
    [Serializable]
    
    public class UnitShipData 
    {
        public Health Health;
        public float Speed;
        public string AssetGUID;
        public UnitShipData(string guid,Health health, float speed)
        {
            AssetGUID = guid;
            Health = health;
            Speed = speed;
        }
    }
}