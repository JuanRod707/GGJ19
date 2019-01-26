using Helpers;
using Repositories;
using UnityEngine;

namespace AI
{
    public class NPCGenerator : MonoBehaviour
    {
        public AIAgent[] InvaderPrefabs;
        public AIAgent[] FamilyPrefabs;
        public TransformRepository FamilyNpcSpawnPoints;
        public Transform InvaderSpawnPoint;

        public ActorRepository ActorRepository;
        public TransformRepository NavigationSpots;
        public Transform NPCContainer;

        void Start()
        {
            AddFamily();
            AddFamily();
            AddInvader();
            AddInvader();
            AddInvader();
        }

        void AddInvader()
        {
            var actor = Instantiate(InvaderPrefabs.PickOne(), NPCContainer);
            actor.transform.position = InvaderSpawnPoint.position;
            actor.Initialize(NavigationSpots);
            ActorRepository.AddNPC(actor);
        }

        void AddFamily()
        {
            var actor = Instantiate(FamilyPrefabs.PickOne(), NPCContainer);
            actor.transform.position = FamilyNpcSpawnPoints.GetRandomSpot.position;
            actor.Initialize(NavigationSpots);
            ActorRepository.AddNPC(actor);
        }
    }
}
