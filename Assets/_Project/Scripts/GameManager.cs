using System;
using UnityEngine;

namespace KrakJam24
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] GameObject _player;
        [SerializeField] GameObject _objectiveSystem;

        [SerializeField] GameObject _startCamera;
        [SerializeField] GameObject _endCamera;

        public static event Action<bool> OnGameEnd;

        public static GameManager Instance { get; private set; }

        void Awake()
        {
            Instance = this;
            _player.SetActive(false);
            _objectiveSystem.SetActive(false);
            
            _startCamera.SetActive(true);
        }

        public void StartGame()
        {
            _player.SetActive(true);
            _objectiveSystem.SetActive(true);

            _startCamera.SetActive(false);
        }

        public void EndGame(bool success)
        {
            _player.SetActive(false);
            _objectiveSystem.GetComponent<ObjectiveSystem>().Timer.Stop();
            _objectiveSystem.SetActive(false);

            Camera.main.gameObject.SetActive(false);
            _endCamera.SetActive(true);

            OnGameEnd?.Invoke(success);
        }
    }
}
