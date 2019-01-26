using UnityEngine;

namespace Effects
{
    public class PlaySound : SpookEffect
    {
        public AudioSource Sfx;

        public override void PlayEffect() => Sfx.Play();
    }
}
