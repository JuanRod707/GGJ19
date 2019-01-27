using Items;
using Repositories;
using UnityEngine;

namespace AI
{
    public class ExorcistHandler : MonoBehaviour
    {
        public int ExorcistChance;
        public Transform InvaderSpawnPoint;
        public AIExorcistAgent ExorcistPrefab;
        public TransformRepository NavigationPoints;
        public ActorRepository ActorRepository;
        public Transform NPCContainer;

        private AIExorcistAgent exorcist;
        private bool exorcistAtHome;

        public void CallExorcist(SpookItem targetItem)
        {
            if (!exorcistAtHome && Random.Range(1, 101) < ExorcistChance)
                SpawnExorcist(targetItem);
        }

        private void SpawnExorcist(SpookItem targetItem)
        {
            exorcistAtHome = true;
            if (exorcist == null)
            {
                exorcist = Instantiate(ExorcistPrefab, NPCContainer);
                exorcist.transform.position = InvaderSpawnPoint.position;
                ActorRepository.AddNPC(exorcist);
            }

            exorcist.gameObject.SetActive(true);
            exorcist.Initialize(NavigationPoints, InvaderSpawnPoint, targetItem, ExorcistLeaves);
        }

        private void ExorcistLeaves()
        {
            exorcistAtHome = false;
        }
    }
}
