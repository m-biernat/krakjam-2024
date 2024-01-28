using System;
using UnityEngine;
using DG.Tweening;

namespace KrakJam24
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrapplingHook : MonoBehaviour
    {
        Rigidbody _rb;

        [SerializeField] Transform _head;

        [SerializeField] Transform _leftHook;
        [SerializeField] Transform _rightHook;

        [SerializeField] float _range = 10;
        [SerializeField] LayerMask _layerMask;

        [SerializeField] float _force = 10;
        [SerializeField] float _upForceMultiplier = 0.5f;

        bool _isActive = false;

        [SerializeField] float _animationDuration = 0.2f;

        AudioSource _audioSrc;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _audioSrc = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (_isActive)
                return;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                TryShootingHook(PullMeToSth);
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                TryShootingHook(PullSthToMe);
                return;
            }
        }

        void TryShootingHook(Action<RaycastHit> onTargetHit)
        {
            RaycastHit hit;
            if (Physics.Raycast(_head.position, _head.forward, out hit, _range, _layerMask))
            {
                _isActive = true;
                onTargetHit(hit);
            }
        }

        void PullMeToSth(RaycastHit hit)
        {
            var dir = (transform.up * _upForceMultiplier) + (hit.point - transform.position);
            _rb.AddForce(dir.normalized * _force, ForceMode.Impulse);

            AnimateHook(_leftHook, hit);
        }

        void PullSthToMe(RaycastHit hit)
        {
            IHookable hookable;
            if (hit.collider.TryGetComponent(out hookable))
                hookable.OnHookPull(transform, _force, _upForceMultiplier);

            AnimateHook(_rightHook, hit);
        }

        void AnimateHook(Transform hook, RaycastHit hit)
        {
            hook.DOPunchPosition(transform.InverseTransformPoint(hit.point), _animationDuration)
                .OnComplete(() => _isActive = false);

            _audioSrc.pitch = UnityEngine.Random.Range(0.8f, 1.2f);
            _audioSrc.Play();
        }
    }
}
