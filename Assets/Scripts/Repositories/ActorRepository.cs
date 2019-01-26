using System.Collections.Generic;
using System.Linq;
using AI;
using UnityEngine;

namespace Repositories
{
    public class ActorRepository : MonoBehaviour
    {
        public GameObject PlayerGhost;

        private List<AIAgent> NPCs = new List<AIAgent>();

        public void AddNPC(AIAgent agent) => NPCs.Add(agent);

        public void RemoveNPC(AIAgent agent) => NPCs.Remove(agent);

        public IEnumerable<AIAgent> GetNPCsInRadius(Vector3 origin, float radius) => NPCs.Where(
            a => Vector3.Distance(origin, a.transform.position) < radius);
    }
}
