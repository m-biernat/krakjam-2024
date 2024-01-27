using UnityEngine;

namespace KrakJam24
{
    public class GroundCheck : MonoBehaviour
    {
        public bool IsGrounded { get; private set; }

        void OnTriggerEnter(Collider other)
        {
            IsGrounded = true;
        }

        void OnTriggerStay(Collider other)
        {
            IsGrounded = true;
        }

        void OnTriggerExit(Collider other)
        {
            IsGrounded = false;
        }
    }
}
