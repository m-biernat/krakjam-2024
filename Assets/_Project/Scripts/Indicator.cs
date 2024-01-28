using UnityEngine;
using DG.Tweening;

namespace KrakJam24
{
    public class Indicator : MonoBehaviour
    {
        [SerializeField] Transform _gfx;
        [SerializeField] Vector3 _pos;
        [SerializeField] float _time;

        Tween _tween;

        void Start()
        {
            _tween = _gfx.DOLocalMove(_pos, _time).SetLoops(-1, LoopType.Yoyo);
        }

        void OnEnabled()
        {
            if (_tween == null)
                return;

            _tween.Play();
        }

        private void OnDisable()
        {
            _tween.Pause();
        }
    }
}
