using System.Linq;
using Helpers;
using Player;
using Repositories;
using UnityEngine;

namespace AI
{
    public class NPCGenerator : MonoBehaviour
    {
        public int LocalMembers;
        public int Visitors;

        public AIAgent[] InvaderPrefabs;
        public AIAgent[] FamilyPrefabs;
        public TransformRepository FamilyNpcSpawnPoints;
        public Transform InvaderSpawnPoint;
        public GameProgress Game;

        public ActorRepository ActorRepository;
        public TransformRepository NavigationSpots;
        public Transform NPCContainer;
        
        void Start()
        {
            foreach (var _ in Enumerable.Range(0, LocalMembers))
                AddFamily();

            foreach (var _ in Enumerable.Range(0, Visitors))
                AddInvader();

            Game.SetVisitorCount(Visitors);
        }

        void AddInvader()
        {
            var actor = Instantiate(InvaderPrefabs.PickOne(), NPCContainer);
            actor.transform.position = InvaderSpawnPoint.position;
            actor.Initialize(Game, NavigationSpots, InvaderSpawnPoint);
            ActorRepository.AddNPC(actor);
        }

        void AddFamily()
        {
            var actor = Instantiate(FamilyPrefabs.PickOne(), NPCContainer);
            actor.transform.position = FamilyNpcSpawnPoints.GetRandomSpot.position;
            actor.Initialize(Game, NavigationSpots, InvaderSpawnPoint);
            ActorRepository.AddNPC(actor);
        }
    }
}
