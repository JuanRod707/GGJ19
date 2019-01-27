using UI;
using UnityEngine;

namespace Player
{
    public class GameProgress : MonoBehaviour
    {
        public InGamePanels UiController;

        private int spookedVisitors;
        private int visitorCount;

        public void SetVisitorCount(int count) => visitorCount = count;

        public void VisitorSpooked()
        {
            spookedVisitors++;
            UiController.AddScore();
            if (spookedVisitors >= visitorCount)
                WinGame();
        }

        public void LocalSpooked() => UiController.GameEnded("You Lose");

        private void WinGame() => UiController.GameEnded("You Win");
    }
}
