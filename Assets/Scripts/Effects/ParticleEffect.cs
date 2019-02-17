using UnityEngine;

namespace Effects
{
    public class ParticleEffect : SpookEffect
    {
        public ParticleSystem Vfx;

        public override void PlayEffect() => Vfx.Play();
    }
}
