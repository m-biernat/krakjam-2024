using UnityEngine;
using TMPro;
using DG.Tweening;

namespace KrakJam24
{
    public class DisplayTimer : MonoBehaviour
    {
        TMP_Text _text;

        private void Awake()
        {
            _text = GetComponent<TMP_Text>();
            _text.enabled = false;
        }

        private void OnEnable()
        {
            Timer.OnStart += OnStart;
            Timer.OnTick += OnTick;
            Timer.OnEnd += OnEnd;
        }

        private void OnStart(int time)
        {
            _text.text = $"{time}";
            _text.enabled = true;
        }
        private void OnTick(int time)
        {
            _text.text = $"{time}";
            _text.rectTransform.DOPunchScale(Vector3.one * .25f, .1f);
        }
        private void OnEnd() => _text.enabled = false;

        private void OnDisable()
        {
            Timer.OnStart -= OnStart;
            Timer.OnTick -= OnTick;
            Timer.OnEnd -= OnEnd;
        }
    }
}
