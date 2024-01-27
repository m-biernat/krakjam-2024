using UnityEngine;

namespace KrakJam24
{
    public interface IHookable
    {
        public void OnHookPull(Transform source, float force, float upForceMultiplier);
    }
}
