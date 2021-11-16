using Code.CommonClasses;
using Code.CommonInterfaces;
using Code.Markers;
using UnityEngine;

namespace Code.Bullet.BulletCode
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField]private float _damage;
        [SerializeField]private float _speed;
        private Transform _bulletPool;
        public Transform Transform;
        [SerializeField] private float _ttl = 0.8f;
        public float _timeToDie;
        private void Awake()
        {
            Transform = transform;
            _timeToDie = Time.time + _ttl;
        }
        private void Update()
        {
            if (Time.time > _ttl + _timeToDie && isActiveAndEnabled)
            {
                ReturnToPool();
            }
        }
        private Transform BulletPool
        {
            get
            {
                if (_bulletPool != null) return _bulletPool;
                var find = GameObject.Find(NameManager.BULLET_POOL);
                _bulletPool = find == null ? null : find.transform;
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
        public static T GetOrAddComponent<T>(GameObject gameObject) where T : Component
        {
            var result = gameObject.GetComponent<T>();
            if (!result)
            {
                result = gameObject.AddComponent<T>();
            }
            return result;
        }
        private void ReturnToPool()
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