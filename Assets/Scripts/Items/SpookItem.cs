using System.Collections.Generic;
using AI;
using Effects;
using Repositories;
using UnityEngine;

namespace Items
{
    public class SpookItem : MonoBehaviour
    {
        public float ActivationRange;
        public float EffectRange;
        public VisualEffect Vfx;

        private ActorRepository actors;

        private bool GhostIsInRange => 
            Vector3.Distance(transform.position, actors.PlayerGhost.transform.position) < ActivationRange;

        void Start() => actors = FindObjectOfType<ActorRepository>();

        private void OnMouseDown()
        {
            if (GhostIsInRange)
            {
                SpookNPCs(actors.GetNPCsInRadius(transform.position, EffectRange));
                Vfx.PlayEffect();
            }
        }

        private void SpookNPCs(IEnumerable<AIAgent> npcs)
        {
            foreach (var npc in npcs)
            {
                npc.Spook();
            }
        }
    }
}
