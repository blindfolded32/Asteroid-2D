using Code.CommonInterfaces;
using Code.Player.Interfaces;
using UnityEngine;

namespace Code.Player.PlayerCode
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider))]
    public class PlayerView : MonoBehaviour,IPlayerView, ITakeDamage
    {
        public Transform Transform { get; set; }
        public Rigidbody2D Rigidbody2D { get => _rigidbody2D ; set => _rigidbody2D = value; }
        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            Transform = transform;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void TakeDamage(float damage)
        {
            Debug.Log($"Hurts ");
        }
    }
}