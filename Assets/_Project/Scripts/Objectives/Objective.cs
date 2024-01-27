using UnityEngine;

namespace KrakJam24
{
    public abstract class Objective : MonoBehaviour
    {
        public Sprite image;
        public string description;
        public int time;

        protected ObjectiveSystem _objectiveSystem;

        public virtual void Activate(ObjectiveSystem objectiveSystem)
        {
            _objectiveSystem = objectiveSystem;
            _objectiveSystem.Timer.Init(time);
        }

        public virtual void Deactivate()
        {

        }
    }
}
