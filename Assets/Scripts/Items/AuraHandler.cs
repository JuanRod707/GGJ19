using UnityEngine;

namespace Items
{
    public class AuraHandler : MonoBehaviour
    {
        public ParticleSystem AuraReady;
        public ParticleSystem AuraEffect;
        public ParticleSystem AuraEffectContinuous;
        public float EffectRangeMultiplier;

        public void HideUseAura()
        {
            AuraReady.Stop();
            HideAreaOfEffect();
        }

        public void ShowUseAura() => AuraReady.Play();

        public bool IsOnCooldown => AuraReady.isStopped;

        public void ShowAreaOfEffect(float range)
        {
            var mainStart = AuraEffect.main;
            var mainContinuous = AuraEffectContinuous.main;

            mainStart.startSize = range * EffectRangeMultiplier;
            mainContinuous.startSize = range * EffectRangeMultiplier;
            AuraEffect.Play();
        }

        public void Disable()
        {
            HideAreaOfEffect();
            HideUseAura();
            gameObject.SetActive(false);
        }

        public void HideAreaOfEffect() => AuraEffect.Stop();
    }
}
