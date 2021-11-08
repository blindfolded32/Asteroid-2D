using UnityEngine;
using UnityEngine.AI;

namespace Code.EnemyShip.Interfaces
{
    public interface IEnemyShipView
    {
        Transform Transform { get; set; }
        NavMeshAgent NavMeshAgent { get; set; }
    }
}