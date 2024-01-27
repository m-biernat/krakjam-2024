using UnityEngine;

namespace KrakJam24
{
    public class BringMe : Objective
    {
        [SerializeField] BringMeTarget _target;

        public override void Activate(ObjectiveSystem objectiveSystem)
        {
            base.Activate(objectiveSystem);

            _target.Init(gameObject, _objectiveSystem);
        }
    }
}
