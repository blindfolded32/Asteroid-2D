using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Code.CommonClasses;
using Code.Markers;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Code.Bullet
{
    internal sealed class BulletPool 
    {
        private readonly Dictionary<string, HashSet<BulletCode.Bullet>> _bulletPool;
        private readonly int _capacity;
        private Transform _rootPool;
        
        public BulletPool(int capacityPool)
        {
            _bulletPool = new Dictionary<string, HashSet<BulletCode.Bullet>>();
            _capacity = capacityPool;
            if (!_rootPool)
            {
                _rootPool = new GameObject(NameManager.BULLET_POOL).transform;
            }
        }
        public BulletCode.Bullet GetItem(string type)
        {
            BulletCode.Bullet result;
            switch (type)
            {
                case "Bullet":
                    result = GetBullet(GetListBullet(type));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Не предусмотрен в программе");
            }
            return result;
        }
        private HashSet<BulletCode.Bullet> GetListBullet(string type)
        {
            return _bulletPool.ContainsKey(type) ? _bulletPool[type] : _bulletPool[type] = new HashSet<BulletCode.Bullet>();
        }
        private BulletCode.Bullet GetBullet(HashSet<BulletCode.Bullet> bullets)
        {
            var bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            if (bullet == null )
            {
                var laser = Resources.Load<BulletCode.Bullet>("Prefabs/Bullet");
                for (var i = 0; i < _capacity; i++)
                {
                    var instantiate = Object.Instantiate(laser);
                    ReturnToPool(instantiate.transform);
                    bullets.Add(instantiate);
                    
                }
                GetBullet(bullets);
            }
            bullet = bullets.FirstOrDefault(a => !a.gameObject.activeSelf);
            return bullet;
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