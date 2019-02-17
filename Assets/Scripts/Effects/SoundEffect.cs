using UnityEngine;

namespace Effects
{
    public class SoundEffect : SpookEffect
    {
        public AudioSource Sfx;

        public override void PlayEffect() => Sfx.Play();
    }
}
