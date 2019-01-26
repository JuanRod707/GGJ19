using System.Collections;
using System.Linq;
using UnityEngine;

namespace Effects
{
    public class FlickLight : SpookEffect
    {
        public float FlickInterlude;
        public int FlickAmount;
        public Light Light;
        public AudioSource Sfx;

        private float basicRange;

        public override void PlayEffect()
        {
            basicRange = Light.range;
            StartCoroutine(Flick());
            Sfx?.Play();
        }

        IEnumerator Flick()
        {
            foreach (var _ in Enumerable.Range(0, FlickAmount))
            {
                Light.range = 0f;
                yield return new WaitForSeconds(FlickInterlude);

                Light.range = basicRange;
                yield return new WaitForSeconds(FlickInterlude);
            }
        }
    }
}
