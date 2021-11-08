﻿using System;
using System.Collections;
using Code.Bullet.Interfaces;
using Code.CommonClasses;
using Code.CommonInterfaces;
using Code.Markers;
using UnityEngine;

namespace Code.Bullet
{
    [RequireComponent(typeof(Collider))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField]private float _damage;
        private IBulletFactory _factory;
        [SerializeField]private float _speed;
        public Sprite sprite;
        public Rigidbody2D Rigidbody2D;
        private Transform _bulletPool;
        public Transform Transform;
      
        private void Awake()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            Transform = transform;
        }

        private Transform BulletPool
        {
            get
            {
                if (_bulletPool == null)
                {
                    var find = GameObject.Find(NameManager.BULLET_POOL);
                    _bulletPool = find == null ? null : find.transform;
                }
                return _bulletPool;
            }
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<DestroybleObject>(out _))
            {
                other.gameObject.GetComponent<ITakeDamage>().TakeDamage(_damage);
                ReturnToPool();
            }
            ReturnToPool();
        }

        public void ReturnToPool()
        {
            transform.localPosition = Vector2.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(BulletPool);
            if (!BulletPool)
            {
                Destroy(gameObject);
            }
        }
    }
}