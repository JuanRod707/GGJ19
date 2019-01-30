using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class InGamePanels : MonoBehaviour
    {
        public Sprite WinSprite;
        public Sprite LoseSprite;

        public GameObject EndPanel;
        public Image EndArt;
        public Transform ScorePanel;
        public GameObject ScoreTokenPrefab;
        public Text Timer;

        public void AddScore() => Instantiate(ScoreTokenPrefab, ScorePanel);

        public void GameEnded(bool win)
        {
            EndPanel.SetActive(true);
            EndArt.sprite = win ? WinSprite : LoseSprite;
        }

        public void UpdateTimer(float time)
        {
            Timer.text = time > 60 ? new DateTime().AddSeconds(time).ToString("M:ss") : $"0:{time:00}";
        }
    }
}
