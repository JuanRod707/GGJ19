using System;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class BasicNavigator : MonoBehaviour
    {
        public NavMeshAgent Agent;
        
        public void MoveTo (Vector3 targetPosition) => Agent.SetDestination(targetPosition);
    }
}
