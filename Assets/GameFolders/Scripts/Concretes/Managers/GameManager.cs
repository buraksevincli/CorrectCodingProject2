using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private float delayLevelTime = 1f;
        [SerializeField] private int score;

        public static GameManager Instance { get; private set; }

        public event Action<bool> OnSceneChanged;
        public event Action<int> OnScoreChanged;

        private void Awake()
        {
            SingletonPattern();
        }

        private void SingletonPattern()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            yield return new WaitForSeconds(delayLevelTime);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;
            int activeScene = buildIndex + levelIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);
            SceneManager.LoadSceneAsync(activeScene, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(activeScene));
            };
            
            OnSceneChanged?.Invoke(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void LoadMenuAndUI(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUIAsync(delayLoadingTime));
        }

        private IEnumerator LoadMenuAndUIAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
            
            OnSceneChanged?.Invoke(true);
        }

        public void IncreaseScore(int score = 0)
        {
            this.score += score;
            OnScoreChanged?.Invoke(this.score);
        }
    }
}

