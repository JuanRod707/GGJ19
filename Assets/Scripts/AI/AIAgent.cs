using System.Collections;
using Effects;
using Movement;
using Player;
using Repositories;
using UnityEngine;

namespace AI
{
    public class AIAgent : MonoBehaviour
    {
        public float MinIdleTime;
        public float MaxIdleTime;
        public ScheduledNavigator Navigator;
        public ParticleEffect SpookVfx;
        public Animator Controller;
        public int InitialSpookPoints;
        public bool IsLocal;
        public AudioSource SpookSfx;

        protected TransformRepository navigationSpots;
        protected Transform outside;
        protected float RandomWaitTime => Random.Range(MinIdleTime, MaxIdleTime);
        protected GameProgress game;
        protected int currentSpookPoints;

        public void Initialize(GameProgress game, TransformRepository navigationSpots, Transform outside)
        {
            this.navigationSpots = navigationSpots;
            NavigateTo(navigationSpots.GetRandomSpot.position);
            this.outside = outside;
            this.game = game;
            currentSpookPoints = InitialSpookPoints;
        }

        protected void NavigateTo(Vector3 position)
        {
            Controller.SetTrigger("Walk");
            Navigator.MoveTo(position, WaitInPlace);
        }

        protected void WaitInPlace() => StartCoroutine(WaitThenMove());

        protected virtual IEnumerator WaitThenMove()
        {
            Navigator.Stop();
            Controller.SetTrigger("Stop");
            yield return new WaitForSeconds(RandomWaitTime);
            NavigateTo(navigationSpots.GetRandomSpot.position);
        }

        public virtual void Spook()
        {
            currentSpookPoints -= 1;
            SpookVfx.PlayEffect();
            SpookSfx.Play();

            if (currentSpookPoints <= 0)
                EscapeHouse();
            else
                RunAway();
        }

        protected void EscapeHouse()
        {
            Controller.SetTrigger("Run");
            Navigator.RunTo(outside.position, AbandonHouse);
        }

        protected virtual void AbandonHouse()
        {
            if(IsLocal)
                game.LocalSpooked();
            else
                game.VisitorSpooked();

            gameObject.SetActive(false);
        }

        protected void RunAway()
        {
            Controller.SetTrigger("Run");
            Navigator.RunTo(navigationSpots.GetFurthest(transform.position).position, WaitInPlace);
        }
    }
}
