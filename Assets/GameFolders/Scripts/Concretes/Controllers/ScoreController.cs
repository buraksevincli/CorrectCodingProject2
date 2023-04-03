using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Managers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class ScoreController : MonoBehaviour
    {
        [SerializeField] private int score = 1;
        [SerializeField] private AudioClip _scoreClip;

        public static event System.Action<AudioClip> OnScorePlaySound; 
        private void OnTriggerEnter2D(Collider2D col)
        {
            PlayerController player = col.GetComponent<PlayerController>();

            if (player != null)
            {
                GameManager.Instance.IncreaseScore(score);
                OnScorePlaySound.Invoke(_scoreClip);
                Destroy(this.gameObject);
            }
        }
    }
}

