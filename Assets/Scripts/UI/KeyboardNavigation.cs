using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class KeyboardNavigation : MonoBehaviour
    {
        public NavigationAction EscapeAction;

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                switch (EscapeAction)
                {
                    case NavigationAction.GoToMenu:
                        SceneManager.LoadScene("MainMenu");
                        break;
                    case NavigationAction.Quit:
                        Application.Quit();
                        break;
                }
            }
        }
    }

    public enum NavigationAction
    {
        GoToMenu,
        Quit
    }
}
