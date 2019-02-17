using System.Collections;
using System.Linq;
using UnityEngine;

namespace Effects
{
    public class LightEffect : SpookEffect
    {
        public ParticleSystem[] Lights;

        public override void PlayEffect()
        {
            foreach (var light in Lights)
                light.Play();
        }
    }
}
