using System;
using Code.CommonClasses;
using UnityEngine;

namespace Code
{
    [Serializable]
    public class ConfigVars 
    {
        public static float _speed = 10.0f;
        public static float _acceleration = 20.0f;
        public static float _hp = 10.0f;
        public static int _maxAsteroidCount  = 1;
        public static Health _asteroidHealth = new Health(1.0f,1.0f);
    }
}