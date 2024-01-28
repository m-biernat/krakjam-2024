using System.Collections.Generic;
using UnityEngine;

namespace KrakJam24
{
    [RequireComponent(typeof(Timer))]
    public class ObjectiveSystem : MonoBehaviour
    {
        [SerializeField] List<Objective> _tasks;
        [SerializeField] List<Objective> _punishments;

        public static int Mood { get; private set; }

        public static int CompletedTasks { get; private set; }

        public Objective CurrentObjective { get; private set; }
        bool _isPunishment;

        public Timer Timer { get; private set; }

        [SerializeField] float _startGameDelay = 5;
        [SerializeField] float _fetchObjectiveDelay = 3;
        [SerializeField] float _startObjectiveDelay = 3;

        public static event System.Action<Objective> OnNewObjective;
        public static event System.Action OnStartObjective;
        public static event System.Action OnTaskCompleted;
        public static event System.Action OnTaskFailed;

        void Awake()
        {
            Mood = 1;
            CompletedTasks = 0;
            Timer = GetComponent<Timer>();
        }

        void SetNextTask()
        {
            CurrentObjective = _tasks[Random.Range(0, _tasks.Count)];
            _isPunishment = false;
        }

        void SetNextPunishment()
        {
            CurrentObjective = _punishments[Random.Range(0, _punishments.Count)];
            _isPunishment = true;
        }

        public void CompleteTask()
        {
            Timer.Stop();

            Mood += 1;

            CurrentObjective?.Deactivate();
            
            if (!_isPunishment)
            {
                CompletedTasks += 1;
                RemoveCurrentTask();
            }

            OnTaskCompleted?.Invoke();

            if (_tasks.Count == 0)
            {
                if (Mood == 1)
                    GameManager.Instance.EndGame(false);
                else
                    GameManager.Instance.EndGame(true);
                return;
            }

            Invoke(nameof(FetchObjective), _fetchObjectiveDelay);
        }

        public void FailTask()
        {
            if (Mood > 0)
            {
                Mood = 0;

                CurrentObjective?.Deactivate();

                if (!_isPunishment)
                    RemoveCurrentTask();

                OnTaskFailed?.Invoke();
            }
            else
            {
                GameManager.Instance.EndGame(false);
                return;
            }

            Invoke(nameof(FetchObjective), _fetchObjectiveDelay);
        }

        void RemoveCurrentTask()
        {
            _tasks.Remove(CurrentObjective);
            Destroy(CurrentObjective.gameObject);
        }

        void Start()
        {
            Invoke(nameof(FetchObjective), _startGameDelay);
        }

        void FetchObjective()
        {
            if (Mood > 0)
                SetNextTask();
            else
                SetNextPunishment();

            OnNewObjective?.Invoke(CurrentObjective);
            Invoke(nameof(StartObjective), _startObjectiveDelay);
        }

        void StartObjective()
        {
            CurrentObjective.Activate(this);
            OnStartObjective?.Invoke();
        }

        void OnEnable()
        {
            Timer.OnTimesUp += OnTimesUp;
        }

        void OnDisable()
        {
            Timer.OnTimesUp -= OnTimesUp;
        }

        void OnTimesUp()
        {
            ClearObjective();
            FailTask();
        }

        public void SwapObjective(Objective target)
        {
            CurrentObjective = target;
        }

        public void ClearObjective()
        {
            CurrentObjective = null;
            _isPunishment = true;
            Timer.Stop();
        }
    }
}
