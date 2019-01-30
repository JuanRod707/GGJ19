using System.Collections;
using UnityEngine;

namespace UI
{
    public class FadeOut : MonoBehaviour
    {
        public float IdleTime;
        public CanvasGroup Canvas;
        public float FadeSpeed;

        private bool fadeOut;

        void Start()
        {
            StartCoroutine(WaitAndFade());
        }

        IEnumerator WaitAndFade()
        {
            yield return new WaitForSeconds(IdleTime);
            fadeOut = true;
        }

        void Update()
        {
            if (Input.anyKey)
                fadeOut = true;

            if (fadeOut)
                Canvas.alpha -= FadeSpeed;

            if (Canvas.alpha <= 0)
                enabled = false;
        }
    }
}
