using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace Effects
{
    public class FreezeRotation : MonoBehaviour
    {
        void Update()
        {
            var rotVector = transform.eulerAngles;
            rotVector.y = 0;
            transform.eulerAngles = rotVector;
        }
    }
}
