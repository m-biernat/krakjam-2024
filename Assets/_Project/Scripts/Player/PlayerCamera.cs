using UnityEngine;

namespace KrakJam24
{
    public class PlayerCamera : MonoBehaviour
    {
        Transform _head;

        Vector3 _velocity = Vector3.zero;

        private void Awake()
        {
            _head = transform.parent;
            transform.parent = null;
        }

        private void Update()
        {
            transform.position = Vector3.SmoothDamp(transform.position, _head.position, ref _velocity, 0.01f);
            transform.rotation = _head.rotation;
        }
    }
}
