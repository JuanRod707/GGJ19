using System;
using System.Collections;
using Items;
using Repositories;
using UnityEngine;

namespace AI
{
    public class AIExorcistAgent : AIAgent
    {
        public float ExorcismTime;
        public AudioSource ArriveSfx;
        public AudioSource ExorcismSfx;

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

            ArriveSfx.Play();
        }

        private void GoToTarget()
        {
            Controller.SetTrigger("Walk");
            Navigator.MoveTo(targetItem.transform.position, PerformExorcism);
        }

        private void PerformExorcism()
        {
            targetItem.Exorcise();
            StartCoroutine(PerformExorcismAndLeave());
        }

        protected override IEnumerator WaitThenMove()
        {
            Navigator.Stop();
            Controller.SetTrigger("Stop");
            yield return new WaitForSeconds(RandomWaitTime);
            ResumeTask();
        }

        IEnumerator PerformExorcismAndLeave()
        {
            Navigator.Stop();
            Controller.SetTrigger("Stop");
            ExorcismSfx.Play();
            yield return new WaitForSeconds(ExorcismTime);
            exorcismSuccessful = true;
            GraciouslyExitHouse();
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
