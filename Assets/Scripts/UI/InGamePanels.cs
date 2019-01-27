using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGamePanels : MonoBehaviour
    {
        public GameObject EndPanel;
        public Text EndMessage;
        public Transform ScorePanel;
        public GameObject ScoreTokenPrefab;
        public Text Timer;

        public void AddScore() => Instantiate(ScoreTokenPrefab, ScorePanel);

        public void GameEnded(string message)
        {
            EndMessage.text = message;
            EndPanel.SetActive(true);
        }

        public void UpdateTimer(float time) => Timer.text = time.ToString("0");
    }
}
