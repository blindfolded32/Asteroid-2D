using System.Collections;
using Code.EnemyShip.Interfaces;
using Code.Markers;
using Code.Player.PlayerCode;
using UnityEngine;
using UnityEngine.AI;

namespace Code.EnemyShip.Code
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public class EnemyShipView : EnemyShip, IEnemyShipView
    {
        private NavMeshAgent _navMeshAgent;
        private Transform _transform;
     public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set=> _navMeshAgent = value; }
      private EnemyShipShoot _shipShoot;
     private float _fireDistance = 10.0f;
     public Transform Transform { get => _transform;
          set => _transform = value;
     }

     private void Start()
     {
        // _navMeshAgent = GetComponent<NavMeshAgent>();
         _transform = transform;
         _shipShoot = new EnemyShipShoot(10);
     }

     private void FixedUpdate()
     {
         Vector2 PlayerPosition = FindObjectOfType<PlayerView>().gameObject.transform.position;
         if (Vector2.Distance(PlayerPosition, _transform.position) > 5.0f)
         {
             _transform.position = Vector2.MoveTowards(this._transform.position,PlayerPosition,Time.fixedDeltaTime);
         }
         StartCoroutine(ROF(1.3f,gameObject.GetComponentInChildren<FirePoint>().transform));
     }


     IEnumerator ROF(float rof,Transform transform)
     {
         yield return new WaitForSeconds(rof);
         _shipShoot.Shoot(transform);
     }
    }
}