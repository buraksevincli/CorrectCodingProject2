using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject gamePlayCanvas;
        [SerializeField] private GameObject gameOverPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(bool isActive)
        {
            if(!isActive == gamePlayCanvas.activeSelf) return;
            
            gamePlayCanvas.SetActive(!isActive);
        }

        public void ShowGameOverPanel()
        {
            gameOverPanel.gameObject.SetActive(true);
        }
    }
}

