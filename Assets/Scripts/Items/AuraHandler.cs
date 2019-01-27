using UnityEngine;

namespace Items
{
    public class AuraHandler : MonoBehaviour
    {
        public ParticleSystem AuraReady;
        public ParticleSystem AuraEffect;
        public float EffectRangeMultiplier;

        public void HideUseAura() => AuraReady.Stop();

        public void ShowUseAura() => AuraReady.Play();

        public void ShowAreaOfEffect(float range)
        {
            var part = AuraEffect.main;
            part.startSize = range * EffectRangeMultiplier;
            AuraEffect.Play();
        }

        public void HideAreaOfEffect() => AuraEffect.Stop();
    }
}
