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

        public void AddScore() => Instantiate(ScoreTokenPrefab, ScorePanel);

        public void GameEnded(string message)
        {
            EndMessage.text = message;
            EndPanel.SetActive(true);
        }
    }
}
