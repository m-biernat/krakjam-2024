using UnityEngine;
using DG.Tweening;

namespace KrakJam24
{
    [RequireComponent(typeof(BoxCollider))]
    public class FloorIsLava : Objective
    {
        [SerializeField] float _height;
        [SerializeField] Ease _ease = Ease.InCubic;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public override void Activate(ObjectiveSystem objectiveSystem)
        {
            _objectiveSystem = objectiveSystem;
            gameObject.SetActive(true);
            Animate();
        }

        void Animate()
        {
            transform.DOLocalMoveY(_height, time)
                .SetEase(_ease)
                .SetLoops(2, LoopType.Yoyo)
                .OnComplete(() => _objectiveSystem?.CompleteTask());
        }

        public override void Deactivate()
        {
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                Debug.Log("Kill em");
        }
    }
}
