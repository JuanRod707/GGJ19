using System.Collections.Generic;
using System.Linq;
using Helpers;
using UnityEngine;

namespace Repositories
{
    public class TransformRepository : MonoBehaviour
    {
        public IEnumerable<Transform> GetSpots => GetComponentsInChildren<Transform>().Where(t => t != transform);

        public Transform GetRandomSpot => GetSpots.PickOne();

        public Transform GetFurthest(Vector3 agentPosition) => GetSpots.OrderByDescending(p => Vector3.Distance(agentPosition, p.position)).First();

    }
}
