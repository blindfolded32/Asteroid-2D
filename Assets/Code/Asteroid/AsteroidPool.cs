using System;
using System.Collections.Generic;
using System.Linq;
using Code.CommonClasses;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Asteroid
{
    internal sealed class AsteroidPool
    {
        private readonly Dictionary<string, HashSet<AbstractAsteroid>> _enemyPool;
        private readonly int _capacityPool;
        private readonly Transform _rootPool;

        public AsteroidPool(int capacityPool)
        {
            _enemyPool = new Dictionary<string, HashSet<AbstractAsteroid>>();
            _capacityPool = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.POOL_AMMUNITION).transform;
            }
        }
        
        public AbstractAsteroid GetEnemy(string type)
        {
            AbstractAsteroid result;
            switch (type)
            {
                case "Asteroid":
                    result = GetAsteroid(GetListEnemies(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            return result;
        }

        private HashSet<AbstractAsteroid> GetListEnemies(string type)
        {
            return _enemyPool.ContainsKey(type) ? _enemyPool[type] : _enemyPool[type] = new HashSet<AbstractAsteroid>();
        }

        private AbstractAsteroid GetAsteroid(HashSet<AbstractAsteroid> enemies)
        {
            var enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (enemy == null )
            {
                var laser = Resources.Load<AbstractAsteroid>("Prefabs/Asteroid");
                for (var i = 0; i < _capacityPool; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    enemies.Add(instantiate);
                }

                GetAsteroid(enemies);
            }
            enemy = enemies.FirstOrDefault(a => !a.gameObject.activeSelf);
            return enemy;
        }

        private void ReturnToPool(Transform transform)
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            transform.gameObject.SetActive(false);
            transform.SetParent(_rootPool);
        }

        public void RemovePool()
        {
            Object.Destroy(_rootPool.gameObject);
        }
    }

}