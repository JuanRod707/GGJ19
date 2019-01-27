using UnityEngine;

namespace Player
{
    public class GameProgress : MonoBehaviour
    {
        private int spookedVisitors;
        private int visitorCount;

        public void SetVisitorCount(int count) => visitorCount = count;

        public void VisitorSpooked()
        {
            spookedVisitors++;
            if (spookedVisitors >= visitorCount)
                WinGame();
        }

        public void LocalSpooked()
        {
            Debug.Log("you suck");
        }

        private void WinGame()
        {
            Debug.Log("you are winrar");
        }
    }
}
