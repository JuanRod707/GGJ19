using UI;
using UnityEngine;

namespace Player
{
    public class GameProgress : MonoBehaviour
    {
        public float TimeLimitBase;
        public float TimePerVisitor;

        public InGamePanels UiController;

        private int spookedVisitors;
        private int visitorCount;
        private float remainingTime;
        private bool gameOver;

        public void SetVisitorCount(int count)
        {
            visitorCount = count;
            remainingTime = TimeLimitBase + (visitorCount * TimePerVisitor);
        }

        public void VisitorSpooked()
        {
            spookedVisitors++;
            //UiController.AddScore();
            if (spookedVisitors >= visitorCount)
                WinGame();
        }

        public void LocalSpooked() => LoseGame();

        private void LoseGame()
        {
            gameOver = true;
            UiController.GameEnded(false);
        }

        private void WinGame()
        {
            gameOver = true;
            UiController.GameEnded(true);
        }

        private void Update()
        {
            if (!gameOver && remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                UiController.UpdateTimer(remainingTime);
                if (remainingTime <= 0)
                    LoseGame();
            }
        }
    }
}
