using System;
using Code.Asteroid.Interfaces;
using Code.CommonClasses;
using Code.CommonInterfaces;
using Code.Markers;
using UnityEngine;

namespace Code.Asteroid
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(DestroybleObject))]
    public class AbstractAsteroid : MonoBehaviour
    {
        [SerializeField] private float _damage = 1.0f;
        public static IAsteroidFactory Factory;
        private Transform _rotPool;
        private Health _health;
        public Rigidbody2D Rigidbody2D;
        public Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            protected set => _health = value;
        }
        public Transform RotPool
        {
            get
            {
                if (_rotPool == null)
                {
                    var find = GameObject.Find(NameManager.POOL_AMMUNITION);
                    _rotPool = find == null ? null : find.transform;
                }

                return _rotPool;
            }
        }
        private void Start()
        {
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (transform.position.y < -10.0f)
            {
                Debug.Log("Back to pool");
                ReturnToPool();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<DestroybleObject>(out var destroybleObject))
            {
                other.gameObject.GetComponent<ITakeDamage>().TakeDamage(_damage);
                ReturnToPool();
            }
            ReturnToPool();
        }

        public static AbstractAsteroid CreateAsteroidEnemy(Health hp)
        {
            var enemy = Instantiate(Resources.Load<AbstractAsteroid>("Prefabs/Asteroid"));
            enemy.Health = hp;
            return enemy;
        }
        public void ActiveEnemy(Vector3 position, Quaternion rotation)
        {
            transform.localPosition = position;
            transform.localRotation = rotation;
            gameObject.SetActive(true);
            transform.SetParent(null);
        }
        public void DependencyInjectHealth(Health hp)
        {
            Health = hp;
        }
        protected void ReturnToPool()
        {
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }

    }
}