using UnityEngine;

namespace KrakJam24
{
    public class FollowObject : MonoBehaviour
    {
        [SerializeField] Transform _objToFollow;

        Vector3 _velocity;

        [SerializeField] float _smoothTime = 0.1f;

        void Update()
        {
            transform.position = Vector3.SmoothDamp(transform.position, _objToFollow.position, ref _velocity, _smoothTime);
        }
    }
}
