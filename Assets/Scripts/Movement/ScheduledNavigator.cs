using System;
using UnityEngine;
using UnityEngine.AI;

namespace Movement
{
    public class ScheduledNavigator : MonoBehaviour
    {
        public NavMeshAgent Agent;
        public float TargetReachDistance;
        public float WalkSpeed;
        public float RunSpeed;

        private Action targetReachedCallback;
        private Vector3 target;
        
        private bool TargetReached => Vector3.Distance(target, transform.position) < TargetReachDistance;

        void Move(Vector3 targetPosition, Action onReachedCallback)
        {
            Agent.SetDestination(targetPosition);
            Agent.isStopped = false;
            target = targetPosition;
            targetReachedCallback = onReachedCallback;
        }

        public void MoveTo(Vector3 targetPosition, Action onReachedCallback)
        {
            Agent.speed = WalkSpeed;
            Move(targetPosition, onReachedCallback);
        }

        public void RunTo(Vector3 targetPosition, Action onReachedCallback)
        {
            Agent.speed = RunSpeed;
            Move(targetPosition, onReachedCallback);
        }

        public void Stop() => Agent.isStopped = true;

        void Update()
        {
            if (!Agent.isStopped && TargetReached)
                targetReachedCallback();
        }
    }
}
