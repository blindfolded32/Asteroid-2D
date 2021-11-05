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
         _transform.position = Vector2.MoveTowards(this._transform.position,FindObjectOfType<PlayerView>().gameObject.transform.position,Time.fixedDeltaTime);
         //  _navMeshAgent.destination = FindObjectOfType<PlayerView>().Transform.position;
     }
    }
}