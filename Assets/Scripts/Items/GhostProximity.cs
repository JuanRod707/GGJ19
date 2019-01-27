using Repositories;
using UnityEngine;

namespace Items
{
    public class GhostProximity : MonoBehaviour
    {
        private ActorRepository actors;
        private float activationRange;
        private AuraHandler auras;

        private bool areaEffectAuraIsOn;
        private float spookRange;

        private bool GhostIsInRange =>
            Vector3.Distance(transform.position, actors.PlayerGhost.transform.position) < activationRange;

        public void Initialize(float spookRange, float activationRange, ActorRepository actorRepository, AuraHandler auras)
        {
            actors = actorRepository;
            this.activationRange = activationRange;
            this.auras = auras;
            this.spookRange = spookRange;
        }

        void Update()
        {
            if (areaEffectAuraIsOn && !GhostIsInRange)
            {
                auras.HideAreaOfEffect();
                areaEffectAuraIsOn = false;
            }

            if (!areaEffectAuraIsOn && !auras.IsOnCooldown && GhostIsInRange)
            {
                auras.ShowAreaOfEffect(spookRange);
                areaEffectAuraIsOn = true;
            }
        }
    }
}
