using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] private MenuPanel _menuPanel;

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
            if(isActive == _menuPanel.gameObject.activeSelf) return;
            
            _menuPanel.gameObject.SetActive(isActive);
        }
    }
}

