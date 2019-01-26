using UnityEngine;

namespace PlayerInput
{
    public class MoveMarker : MonoBehaviour
    {
        public ParticleSystem Vfx;

        public void DisplayMarker(Vector3 targetPosition)
        {
            transform.position = targetPosition;
            Vfx.Play();
        }
    }
}
