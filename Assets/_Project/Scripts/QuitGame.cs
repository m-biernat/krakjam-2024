using UnityEngine;

namespace KrakJam24
{
    public class QuitGame : MonoBehaviour
    {
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
        }
    }
}
