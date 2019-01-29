using UnityEngine;

namespace Movement
{
    public class Oscillate : MonoBehaviour
    {
        public float Frequency;
        public float Strength;

        private float angle;

        void FixedUpdate()
        {
            var pos = transform.localPosition;
            pos.y += Mathf.Sin(angle) * Strength;
            angle += Frequency;

            transform.localPosition = pos;
        }
    }
}
