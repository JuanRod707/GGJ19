using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Effects
{
    public class FreezeRotation : MonoBehaviour
    {
        public float AngleFreeze;

        void Update()
        {
            var rotVector = transform.eulerAngles;
            rotVector.y = AngleFreeze;
            transform.eulerAngles = rotVector;
        }
    }
}
