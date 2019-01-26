using System.Collections;
using Effects;
using Movement;
using Repositories;
using UnityEngine;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public float MinIdleTime;
        public float MaxIdleTime;
        public ScheduledNavigator Navigator;
        public VfxPlay SpookVfx;
        public Animator Controller;

        private TransformRepository navigationSpots;
        
        private float RandomWaitTime => Random.Range(MinIdleTime, MaxIdleTime);

        public void Initialize(TransformRepository navigationSpots)
        {
            this.navigationSpots = navigationSpots;
            NavigateTo(navigationSpots.GetRandomSpot.position);
        }

        private void NavigateTo(Vector3 position)
        {
            Controller.SetTrigger("Walk");
            Navigator.MoveTo(position, WaitInPlace);
        }

        void WaitInPlace() => StartCoroutine(WaitThenMove());
        
        IEnumerator WaitThenMove()
        {
            Navigator.Stop();
            Controller.SetTrigger("Stop");
            yield return new WaitForSeconds(RandomWaitTime);
            NavigateTo(navigationSpots.GetRandomSpot.position);
        }

        public void Spook()
        {
            SpookVfx.PlayVfx();
            Controller.SetTrigger("Run");
            Navigator.RunTo(navigationSpots.GetFurthest(transform.position).position, WaitInPlace);
        }
    }
}
