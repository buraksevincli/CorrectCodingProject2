using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void NoButtonClick()
        {
            GameManager.Instance.LoadMenuAndUI(2f);
        }
    }
}

