using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Animations;
using GameFolders.Scripts.Concretes.Combats;
using GameFolders.Scripts.Concretes.ExtensionMethods;
using GameFolders.Scripts.Concretes.Movements;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private AudioClip enemyDeadClip;
        
        private Mover _mover;
        private CharacterAnimation _characterAnimation;
        private Health _health;
        private Flip _flip;
        private OnReachedEdge _onReachedEdge;

        private bool _isOnEdge;
        private float _direction;

        public static event Action<AudioClip> OnEnemyDead;
        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _health = GetComponent<Health>();
            _flip = GetComponent<Flip>();
            _onReachedEdge = GetComponent<OnReachedEdge>();

            _direction = 1f;
        }

        private void OnEnable()
        {
            _health.OnDead += DeadAction;
            _health.OnDead += () => OnEnemyDead(enemyDeadClip);
        }

        private void FixedUpdate()
        {
            if (_health.IsDead) return;
            
            _mover.HorizontalMove(_direction);
        }

        private void LateUpdate()
        {
            if(_health.IsDead) return;
            
            if (_onReachedEdge.ReachedEdge())
            {
                _direction *= -1f;
                _flip.FlipCharacter(_direction);
            }
        }

        // WasHitLeftOrRightSide hatalı çalışıyor.
        /*private void OnCollisionEnter2D(Collision2D col)
        {
            Health health = col.ObjectHasHealth();

            if (health != null && col.WasHitLeftOrRightSide())
            {
                health.ReturnCheckPoint();
            }
        }*/

        private void DeadAction()
        {
            StartCoroutine(DeadActionAsync());
        }

        private IEnumerator DeadActionAsync()
        {
            _characterAnimation.DyingAnimation();
            yield return new WaitForSeconds(1f);
            Destroy(this.gameObject);
        }
    }
}

