using UnityEngine;

namespace Effects
{
    public class VfxPlay : SpookEffect
    {
        public ParticleSystem Vfx;

        public override void PlayEffect() => Vfx.Play();
    }
}
