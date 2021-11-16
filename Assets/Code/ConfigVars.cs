using System;
using Code.CommonClasses;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Code
{
    [Serializable]
    public class ConfigVars 
    {
        public const float _speed = 10.0f;
        public const float _acceleration = 20.0f;
        public static Health _hp = new Health(10.0f,10.0f);
        public const int _maxAsteroidCount  = 10;
        public static Health _asteroidHealth = new Health(1.0f,1.0f);
    }
}