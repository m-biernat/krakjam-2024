using UnityEngine;
using UnityEngine.SceneManagement;

namespace KrakJam24
{
    public class RestartGame : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }
}
