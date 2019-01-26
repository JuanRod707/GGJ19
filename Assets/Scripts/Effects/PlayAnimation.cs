using UnityEngine;

namespace Effects
{
    public class PlayAnimation : SpookEffect
    {
        public Animator Controller;

        public override void PlayEffect() => Controller.SetTrigger("Spook");
    }
}
