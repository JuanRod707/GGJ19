using System.Collections;
using Effects;
using Helpers;
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

        private TransformRepository navigationSpots;
        
        private float RandomWaitTime => Random.Range(MinIdleTime, MaxIdleTime);

        public void Initialize(TransformRepository navigationSpots)
        {
            this.navigationSpots = navigationSpots;
            NavigateTo(navigationSpots.GetRandomSpot.position);
        }

        private void NavigateTo(Vector3 position) => Navigator.MoveTo(position, WaitInPlace);

        void WaitInPlace() => StartCoroutine(WaitThenMove());

        IEnumerator WaitThenMove()
        {
            Navigator.Stop();
            yield return new WaitForSeconds(RandomWaitTime);
            NavigateTo(navigationSpots.GetRandomSpot.position);
        }

        public void Spook()
        {
            SpookVfx.PlayVfx();
            Navigator.RunTo(navigationSpots.GetFurthest(transform.position).position, WaitInPlace);
        }
    }
}
