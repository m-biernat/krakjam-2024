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
                Debug.Log("Left");
                return;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                Debug.Log("Right");
                return;
            }
        }
    }
}
