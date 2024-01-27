using System;
using UnityEngine;

namespace KrakJam24
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrapplingHook : MonoBehaviour
    {
        Rigidbody _rb;

        [SerializeField] Transform _head;

        [SerializeField] Transform _leftHand;
        [SerializeField] Transform _rightHand;

        [SerializeField] float _range = 10;

        [SerializeField] float _force = 10;
        [SerializeField] float _upForceMultiplier = 0.5f;

        bool _isActive = false;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
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
            if (Physics.Raycast(_head.position, _head.forward, out hit, _range))
                onTargetHit(hit);
        }

        void PullMeToSth(RaycastHit hit)
        {
            var dir = (transform.up * _upForceMultiplier) + (hit.point - transform.position);
            _rb.AddForce(dir.normalized * _force, ForceMode.Impulse);
        }

        void PullSthToMe(RaycastHit hit)
        {
            IHookable hookable;
            if (hit.collider.TryGetComponent(out hookable))
                hookable.OnHookPull(transform, _force, _upForceMultiplier);
        }
    }
}
