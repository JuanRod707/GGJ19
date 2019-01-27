using System.Collections;
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
        public float Cooldown;

        public SpookEffect[] Effects;
        public AuraHandler Auras;
        public GhostProximity GhostProximityDetector;

        ExorcistHandler exorcistHandler;
        private ActorRepository actors;
        private bool isUsable = true;

        private bool GhostIsInRange => 
            Vector3.Distance(transform.position, actors.PlayerGhost.transform.position) < ActivationRange;

        void Start()
        {
            actors = FindObjectOfType<ActorRepository>();
            exorcistHandler = FindObjectOfType<ExorcistHandler>();
            GhostProximityDetector.Initialize(EffectRange, ActivationRange, actors, Auras);
        }

        private void OnMouseDown()
        {
            if (enabled && isUsable && GhostIsInRange)
            {
                isUsable = false;
                SpookNPCs(actors.GetNPCsInRadius(transform.position, EffectRange));
                foreach(var e in Effects)
                    e.PlayEffect();

                Auras.HideUseAura();
                exorcistHandler.CallExorcist(this);
                StartCoroutine(WaitForCooldown());
            }
        }

        private void SpookNPCs(IEnumerable<AIAgent> npcs)
        {
            foreach (var npc in npcs)
                npc.Spook();
        }

        IEnumerator WaitForCooldown()
        {
            yield return new WaitForSeconds(Cooldown);
            ResetItem();
        }

        private void ResetItem()
        {
            Auras.ShowUseAura();
            isUsable = true;
        }

        public void Exorcise()
        {
            Auras.HideUseAura();
            Auras.HideAreaOfEffect();
            enabled = false;
        }
    }
}
