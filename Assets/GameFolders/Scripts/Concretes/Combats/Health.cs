using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.ExtensionMethods;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Combats
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 3;
        [SerializeField] private int currentHealth = 0;

        public bool IsDead => currentHealth < 1;
        
        public event Action<int, int> OnHealthChanged;
        public event Action OnDead;
        
        private void Awake()
        {
            currentHealth = maxHealth;
        }

        private void Start()
        {
            OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }

        public void TakeHit(Damage damage)
        {
            if(IsDead) return;
            
            currentHealth -= damage.HitDamage;

            if (IsDead)
            {
                OnDead?.Invoke();
            }
        }

        public void ReturnCheckPoint()
        {
                OnHealthChanged?.Invoke(currentHealth, maxHealth);
        }
    }
}

