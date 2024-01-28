using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

namespace KrakJam24
{
    public class GameUI : MonoBehaviour
    {
        public GameObject startUI;
        public GameObject playerUI;
        public GameObject winUI;
        public GameObject loseUI;

        public CanvasGroup screenFade;
        public float fadeTime = 2.5f;

        private void Awake()
        {
            startUI.SetActive(true);
            playerUI.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
        }

        public void PlayGame()
        {
            FadeToView(() => {
                startUI.SetActive(false);
                playerUI.SetActive(true);
                GameManager.Instance.StartGame();
            });
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }

        void FadeToView(Action action)
        {
            screenFade.alpha = 0;
            screenFade.gameObject.SetActive(true);
            screenFade.DOFade(1, fadeTime).OnComplete(() => {
                action.Invoke();
                screenFade.DOFade(0, fadeTime).OnComplete(() => {
                    screenFade.gameObject.SetActive(false);
                });
            });
        }

        private void OnEnable()
        {
            GameManager.OnGameEnd += OnGameEnd;
        }

        private void OnDisable()
        {
            GameManager.OnGameEnd -= OnGameEnd;
        }

        void OnGameEnd(bool success)
        {
            FadeToView(() => {
                playerUI.SetActive(false);

                if (success)
                    winUI.SetActive(true);
                else
                    loseUI.SetActive(true);

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            });
        }
    }
}
