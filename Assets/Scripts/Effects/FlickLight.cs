using System.Collections;
using System.Linq;
using UnityEngine;

namespace Effects
{
    public class FlickLight : SpookEffect
    {
        public float FlickInterlude;
        public int FlickAmount;
        public float ReducedRange;

        public Light[] Lights;

        private bool isOnByDefault;
        private float basicRange;

        void Start() => isOnByDefault = Lights.First().enabled;

        public override void PlayEffect()
        {
            SetLights(true);
            basicRange = Lights.First().range;
            StartCoroutine(Flick());
        }

        IEnumerator Flick()
        {
            foreach (var _ in Enumerable.Range(0, FlickAmount))
            {
                SetLightRanges(ReducedRange);
                yield return new WaitForSeconds(FlickInterlude);

                SetLightRanges(basicRange);
                yield return new WaitForSeconds(FlickInterlude);
            }

            SetLights(isOnByDefault);
        }

        void SetLightRanges(float range)
        {
            foreach (var light in Lights)
            {
                light.range = range;
            }
        }

        void SetLights(bool on)
        {
            foreach (var light in Lights)
            {
                light.enabled = on;
            }
        }
    }
}
