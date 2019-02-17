using UnityEngine;

namespace Effects
{
    public class AnimationEffect : SpookEffect
    {
        public Animator Controller;

        public override void PlayEffect() => Controller.SetTrigger("Spook");
    }
}
