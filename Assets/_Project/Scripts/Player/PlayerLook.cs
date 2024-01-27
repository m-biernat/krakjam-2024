using UnityEngine;

namespace KrakJam24
{
    public class PlayerLook : MonoBehaviour
    {
        [SerializeField] Transform _head;

        Vector2 _mouseInput;

        [SerializeField] float _mouseSensitivity = 10;

        Vector2 _rotation;

        [SerializeField] float _clampAngleTop = 90;
        [SerializeField] float _clampAngleDown = 90;

        void Update()
        {
            HandleMouseInput();

            _head.localRotation = Quaternion.Euler(_rotation.x, 0, 0);
            transform.rotation = Quaternion.Euler(0, _rotation.y, 0);
        }

        void HandleMouseInput()
        {
            _mouseInput = new Vector2(
                Input.GetAxisRaw("Mouse X"),
                Input.GetAxisRaw("Mouse Y"));

            _rotation.y += _mouseInput.x * _mouseSensitivity;

            _rotation.x -= _mouseInput.y * _mouseSensitivity;
            _rotation.x = Mathf.Clamp(_rotation.x, -_clampAngleTop, _clampAngleDown);
        }
    }
}
