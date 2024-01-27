using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;

namespace KrakJam24
{
    // Classic encounter of UI script managing the whole game, bravo!
    public class GameUI : MonoBehaviour
    {
        public GameObject startUI;
        public GameObject playerUI;
        public GameObject winUI;
        public GameObject loseUI;

        public CanvasGroup screenFade;

        private void Awake()
        {
            playerUI.SetActive(false);
            winUI.SetActive(false);
            loseUI.SetActive(false);
        }

        public void PlayGame()
        {
            FadeToView(() => {
                startUI.SetActive(false);
                playerUI.SetActive(true);
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
            screenFade.DOFade(1, 0.2f).OnComplete(() => {
                action.Invoke();
                screenFade.DOFade(0, 0.2f).OnComplete(() => {
                    screenFade.gameObject.SetActive(false);
                });
            });
        }
    }
}
