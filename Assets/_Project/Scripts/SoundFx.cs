using UnityEngine;

namespace KrakJam24
{
    public class SoundFx : MonoBehaviour
    {
        public AudioSource clockTick;
        public AudioSource timesUp;
        public AudioSource newTask;
        public AudioSource startTask;

        private void OnEnable()
        {
            Timer.OnTick += OnClockTick;
            Timer.OnTimesUp += OnTimesUp;
            ObjectiveSystem.OnNewObjective += OnNewTask;
            ObjectiveSystem.OnStartObjective += OnStartTask;
        }

        private void OnDisable()
        {
            Timer.OnTick -= OnClockTick;
            Timer.OnTimesUp -= OnTimesUp;
            ObjectiveSystem.OnNewObjective -= OnNewTask;
            ObjectiveSystem.OnStartObjective -= OnStartTask;
        }

        public void OnClockTick(int i)
        {
            clockTick.Play();
        }

        public void OnNewTask(Objective objective)
        {
            newTask.Play();
        }

        public void OnStartTask()
        {
            startTask.Play();
        }

        public void OnTimesUp()
        {
            timesUp.Play();
        }
    }
}
