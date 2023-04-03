using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class MenuPanel : MonoBehaviour
    {
        public void StartButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }

        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}

