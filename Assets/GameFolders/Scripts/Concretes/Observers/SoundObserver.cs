using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Combats;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

namespace GameFolders.Scripts.Concretes.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerController.OnPlayerDead += PlaySoundOneShot;
            EnemyController.OnEnemyDead += PlaySoundOneShot;
            ScoreController.OnScorePlaySound += PlaySoundOneShot;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerDead -= PlaySoundOneShot;
            EnemyController.OnEnemyDead -= PlaySoundOneShot;
            ScoreController.OnScorePlaySound -= PlaySoundOneShot;
        }

        private void PlaySoundOneShot(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }
    }
}

