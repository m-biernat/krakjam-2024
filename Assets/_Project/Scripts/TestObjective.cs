using UnityEngine;

namespace KrakJam24
{
    public class TestObjective : Objective
    {
        void Awake()
        {
            gameObject.SetActive(false);
        }

        public override void Activate(ObjectiveSystem objectiveSystem)
        {
            base.Activate(objectiveSystem);
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
                _objectiveSystem.CompleteTask();
        }
    }
}
