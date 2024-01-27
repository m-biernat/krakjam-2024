using UnityEngine;

namespace KrakJam24
{
    [RequireComponent(typeof(Rigidbody))]
    public class GrabOnPull : MonoBehaviour, IHookable
    {
        Rigidbody _rb;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void OnHookPull(Transform source, float force, float upForceMultiplier)
        {
            var dir = (transform.up * upForceMultiplier) + source.position - transform.position;
            _rb.AddForce(dir.normalized * force, ForceMode.Impulse);
        }
    }
}
