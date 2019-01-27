using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Navigate : MonoBehaviour
    {
        public void NavigateToScene(string scene)
        {
            SceneManager.LoadScene(scene);
        }
    }
}
