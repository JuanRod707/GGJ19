using System.Collections.Generic;
using System.Linq;
using Helpers;
using UnityEngine;

namespace Structures
{
    public class ActiveSpots : MonoBehaviour
    {
        public IEnumerable<Transform> GetSpots => GetComponentsInChildren<Transform>().Where(t => t != transform);

        public Transform GetRandomSpot => GetSpots.PickOne();
    }
}
