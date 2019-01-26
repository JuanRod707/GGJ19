using UnityEngine;

namespace Effects
{
    public class VfxPlay : MonoBehaviour
    {
        public ParticleSystem Vfx;

        public void PlayVfx() => Vfx.Play();
    }
}
