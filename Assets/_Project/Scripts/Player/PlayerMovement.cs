using UnityEngine;

namespace KrakJam24
{
    [RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
    public class PlayerMovement : MonoBehaviour
    {
        Rigidbody _rb;

        Vector2 _moveInput;
        Vector3 _moveDir;
        
        float _moveSpeed;
        [Header("Speed")]
        [SerializeField] float _groundSpeed = 60;
        [SerializeField] float _airSpeed = 40;
        
        float _rbDrag;
        [Header("Drag")]
        [SerializeField] float _groundDrag = 6;
        [SerializeField] float _airDrag = 2;

        [Space(10)]
        [SerializeField] GroundCheck _groundCheck;
        [SerializeField] float _jumpForce = 5;

        void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _rb.freezeRotation = true;
        }

        void Update()
        {
            if (_groundCheck.IsGrounded)
            {
                SetMovementParams(_groundSpeed, _groundDrag);

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    PerformJump();
                }
            }
            else 
            {
                SetMovementParams(_airSpeed, _airDrag);
            }

            HandleMovementInput();
            _rb.drag = _rbDrag;
        }

        void PerformJump()
        {
            _rb.AddForce(transform.up * _jumpForce, ForceMode.Impulse);
        }

        void HandleMovementInput()
        {
            _moveInput = new Vector2(
                Input.GetAxisRaw("Horizontal"),
                Input.GetAxisRaw("Vertical"));
            _moveInput.Normalize();

            _moveDir = transform.forward * _moveInput.y
                       + transform.right * _moveInput.x;
        }

        void FixedUpdate()
        {
            MovePlayer();
        }

        void MovePlayer()
        {
            var force = _moveDir * _moveSpeed;
            _rb.AddForce(force, ForceMode.Acceleration);
        }

        void SetMovementParams(float speed, float drag)
        {
            _moveSpeed = speed;
            _rbDrag = drag;
        }
    }
}
