using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GameFolders.Scripts.Concretes.Combats;
using GameFolders.Scripts.Concretes.Controllers;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Managers
{
    public class CheckpointManager : MonoBehaviour
    {
        private CheckpointController[] _checkpointControllers;
        private Health _health;
        private void Awake()
        {
            _checkpointControllers = GetComponentsInChildren<CheckpointController>();
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
        }

        private void Start()
        {
            _health.OnHealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {
            _health.transform.position = _checkpointControllers.LastOrDefault(x => x.IsPassed)!.transform.position;
        }
    }
}

