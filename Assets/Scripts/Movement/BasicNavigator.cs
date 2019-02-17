using System;
using Items;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class BasicNavigator : MonoBehaviour
    {
        public NavMeshAgent Agent;

        private SpookItem targetItem;
        
        public void MoveTo (Vector3 targetPosition)
        {
            targetItem = null;
            Agent.SetDestination(targetPosition);
        }

        public void MoveTo(Vector3 targetPosition, SpookItem targetItem)
        {
            this.targetItem = targetItem;
            Agent.SetDestination(targetPosition);
        }

        void Update()
        {
            if(targetItem != null)
                if (targetItem.GhostIsInRange)
                {
                    targetItem.Activate();
                    targetItem = null;
                }
        }
    }
}
