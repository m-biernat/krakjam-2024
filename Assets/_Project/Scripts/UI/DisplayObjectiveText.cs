using UnityEngine;
using DG.Tweening;
using TMPro;

namespace KrakJam24
{
    public class DisplayObjectiveText : MonoBehaviour
    {
        TMP_Text _text;
        CanvasGroup _canvasGroup;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0;
        }

        private void OnEnable()
        {
            ObjectiveSystem.OnNewObjective += OnNewObjective;
        }

        private void OnDisable()
        {
            ObjectiveSystem.OnNewObjective -= OnNewObjective;
        }

        void OnNewObjective(Objective objective)
        {
            _text.text = objective.description;
            _canvasGroup.alpha = 0;
            _canvasGroup.DOFade(1, 1).OnComplete(() => _canvasGroup.DOFade(0, 1).SetDelay(3));
        }
    }
}
