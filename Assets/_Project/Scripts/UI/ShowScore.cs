using UnityEngine;
using TMPro;

namespace KrakJam24
{
    public class ShowScore : MonoBehaviour
    {
        private void Start()
        {
            var text = gameObject.GetComponent<TMP_Text>();
            text.text = $"Completed tasks: {ObjectiveSystem.CompletedTasks}";
        }
    }
}
