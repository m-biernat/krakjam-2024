using UnityEngine;

namespace KrakJam24
{
    public class BringMeTarget : MonoBehaviour
    {
        GameObject _targetToy;
        ObjectiveSystem _objectiveSystem;

        private void Awake()
        {
            gameObject.SetActive(false);
        }

        public void Init(GameObject toy, ObjectiveSystem system)
        {
            _targetToy = toy;
            _objectiveSystem = system;
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject == _targetToy)
                _objectiveSystem.CompleteTask();
            else
            {
                BringMe mistake;
                if (TryGetComponent(out mistake))
                {
                    _objectiveSystem.SwapObjective(mistake);
                }
                else
                {
                    _objectiveSystem.ClearObjective();
                    Destroy(other.gameObject); 
                }

                _objectiveSystem.FailTask();
            }

            gameObject.SetActive(false);
        }
    }
}
