using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KrakJam24
{
    public class Child : MonoBehaviour
    {
        public AudioSource happySfx;
        public AudioSource sadSfx;

        public GameObject dialog;
        public SpriteRenderer spriteRenderer;

        public Sprite happyGfx;
        public Sprite sadGfx;

        public bool useObjectiveImage;

        private void Awake()
        {
            dialog.SetActive(false);
        }

        private void OnEnable()
        {
            ObjectiveSystem.OnTaskCompleted += OnTaskCompleted;
            ObjectiveSystem.OnTaskFailed += OnTaskFailed;
            ObjectiveSystem.OnNewObjective += OnNewTask;
            ObjectiveSystem.OnStartObjective += OnStartTask;
            GameManager.OnGameEnd += OnGameEnd;
        }

        private void OnDisable()
        {
            ObjectiveSystem.OnTaskCompleted += OnTaskCompleted;
            ObjectiveSystem.OnTaskFailed += OnTaskFailed;
            ObjectiveSystem.OnNewObjective -= OnNewTask;
            ObjectiveSystem.OnStartObjective -= OnStartTask;
            GameManager.OnGameEnd -= OnGameEnd;
        }

        void OnTaskCompleted()
        {
            dialog.SetActive(true);
            happySfx.Play();
            spriteRenderer.sprite = happyGfx;
        }

        void OnTaskFailed()
        {
            dialog.SetActive(true);
            sadSfx.Play();
            spriteRenderer.sprite = sadGfx;
        }

        void OnNewTask(Objective objective)
        {
            if (!useObjectiveImage)
            {
                dialog.SetActive(false);
                return;
            }

            dialog.SetActive(true);
            spriteRenderer.sprite = objective.image;
        }

        void OnStartTask()
        {
            if (useObjectiveImage)
                dialog.SetActive(false);
        }

        void OnGameEnd(bool success)
        {
            dialog.SetActive(true);

            if (success)
                spriteRenderer.sprite = happyGfx;
            else
                spriteRenderer.sprite = sadGfx;
        }
    }
}
