using Code.CommonClasses;
using Code.CommonInterfaces;
using Code.Markers;
using UnityEngine;

namespace Code.Asteroid.AsteroidCode
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(DestroybleObject))]
    public class AbstractAsteroid : MonoBehaviour, ITakeDamage
    {
        [SerializeField] private float _damage = 1.0f;
        private Transform _rotPool;
        private Health _health;
        private Health Health
        {
            get
            {
                if (_health.Current <= 0.0f)
                {
                    ReturnToPool();
                }
                return _health;
            }
            set
            {
                _health = value;
            }
        }
        private Transform RotPool
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
        public AbstractAsteroid(Health health)
        {
            _health = health;
        }
        private void Update()
        {
            if (!(transform.position.y < -10.0f)) return;
            ReturnToPool();
        }
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent<DestroybleObject>(out _)) other.gameObject
                                                                            .GetComponent<ITakeDamage>().TakeDamage(_damage);
            ReturnToPool();
        }
        public void DependencyInjectHealth(Health hp) => Health = hp;
        private void ReturnToPool()
        {
            gameObject.SetActive(false);
            transform.SetParent(RotPool);
            if (!RotPool)
            {
                Destroy(gameObject);
            }
        }

        public void TakeDamage(float damage) => _health.ChangeCurrentHealth(damage);
    }
}