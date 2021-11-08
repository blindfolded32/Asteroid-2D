using Code.EnemyShip.Interfaces;
using Code.Player.PlayerCode;
using UnityEngine;
using UnityEngine.AI;

namespace Code.EnemyShip.Code
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyShipView : EnemyShip, IEnemyShipView
    {
        private NavMeshAgent _navMeshAgent;
        private Transform _transform;
     public NavMeshAgent NavMeshAgent { get => _navMeshAgent; set=> _navMeshAgent = value; }
     public Transform Transform { get => _transform;
          set => _transform = value;
     }

     private void Start()
     {
        // _navMeshAgent = GetComponent<NavMeshAgent>();
         _transform = transform;
     }

     private void FixedUpdate()
     {
         var PlayerPosition = FindObjectOfType<PlayerView>().gameObject.transform.position;
         if (Vector2.Distance(PlayerPosition, _transform.position) > 5.0f)
         {
             _transform.position = Vector2.MoveTowards(this._transform.position,PlayerPosition,Time.fixedDeltaTime);
         }
         else
         {
             _transform.RotateAround(PlayerPosition,Vector2.up, 20.0f*Time.fixedDeltaTime);
            // _transform.position = _transform.rotation.eulerAngles;
         }
     }
    }
}