using System.Linq;
using Helpers;
using Player;
using Repositories;
using UnityEngine;

namespace AI
{
    public class NPCGenerator : MonoBehaviour
    {
        public int MinLocals;
        public int MaxLocals;
        public int MinVisitors;
        public int MaxVisitors;

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
            var locals = Random.Range(MinLocals, MaxLocals + 1);
            var visitors = Random.Range(MinVisitors, MaxVisitors + 1);

            foreach (var _ in Enumerable.Range(0, locals))
                AddFamily();

            foreach (var _ in Enumerable.Range(0, visitors))
                AddInvader();

            Game.SetVisitorCount(visitors);
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
