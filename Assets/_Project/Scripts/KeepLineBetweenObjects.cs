using UnityEngine;

namespace KrakJam24
{
    [RequireComponent(typeof(LineRenderer))]
    public class KeepLineBetweenObjects : MonoBehaviour
    {
        LineRenderer _lineRenderer;

        [SerializeField] Transform _from;
        [SerializeField] Transform _to;

        void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
        }

        void LateUpdate()
        {
            _lineRenderer.SetPosition(0, _from.localPosition);
            _lineRenderer.SetPosition(1, _to.localPosition);
        }
    }
}
