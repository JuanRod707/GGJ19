using System;
using System.Collections;
using Items;
using Repositories;
using UnityEngine;

namespace AI
{
    public class AIExorcistAgent : AIAgent
    {
        private SpookItem targetItem;
        private bool exorcismSuccessful;
        private Action exitCallback;

        public void Initialize(TransformRepository navigationSpots, Transform outside, SpookItem targetItem, Action exitCallback)
        {
            this.exitCallback = exitCallback;
            this.navigationSpots = navigationSpots;
            this.outside = outside;
            this.targetItem = targetItem;

            GoToTarget();
        }

        private void GoToTarget()
        {
            Controller.SetTrigger("Walk");
            Navigator.MoveTo(targetItem.transform.position, PerformExorcism);
        }

        private void PerformExorcism()
        {
            targetItem.Exorcise();
            exorcismSuccessful = true;
            GraciouslyExitHouse();
        }

        protected override IEnumerator WaitThenMove()
        {
            Navigator.Stop();
            Controller.SetTrigger("Stop");
            yield return new WaitForSeconds(RandomWaitTime);
            ResumeTask();
        }

        private void ResumeTask()
        {
            if(exorcismSuccessful)
                GraciouslyExitHouse();
            else
                GoToTarget();
        }

        protected void GraciouslyExitHouse()
        {
            Controller.SetTrigger("Walk");
            Navigator.MoveTo(outside.position, AbandonHouse);
        }

        protected override void AbandonHouse()
        {
           exitCallback();
           gameObject.SetActive(false);
        }
    }
}
