using UnityEngine;

namespace KrakJam24
{
    public class RemoveParentOnAwake : MonoBehaviour
    {
        void Awake()
        {
            transform.parent = null;
            Destroy(this);
        }
    }
}
