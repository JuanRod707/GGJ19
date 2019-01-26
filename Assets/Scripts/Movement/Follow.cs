using UnityEngine;

namespace Movement
{
    public class Follow : MonoBehaviour
    {
        public Transform Target;
        public float Stiffness;

        void Update() => transform.position = Vector3.Lerp(transform.position, Target.position, Stiffness);
    }
}
