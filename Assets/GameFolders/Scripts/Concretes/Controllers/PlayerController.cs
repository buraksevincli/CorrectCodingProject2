using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Abstracts.Inputs;
using GameFolders.Scripts.Concretes.Animations;
using GameFolders.Scripts.Concretes.Combats;
using GameFolders.Scripts.Concretes.ExtensionMethods;
using GameFolders.Scripts.Concretes.Inputs;
using GameFolders.Scripts.Concretes.Movements;
using GameFolders.Scripts.Concretes.UIs;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private AudioClip deadClip;
        
        private float _horizontal;
        private float _vertical;
        private bool _isJump;

        private IPlayerInput _input;
        private Mover _mover;
        private Jump _jump;
        private CharacterAnimation _characterAnimation;
        private Flip _flip;
        private OnGround _onGround;
        private Climbing _climbing;
        private Health _health;
        private Damage _damage;
        private AudioSource _audioSource;

        public static event Action<AudioClip> OnPlayerDead;
        private void Awake()
        {
            _mover = GetComponent<Mover>();
            _jump = GetComponent<Jump>();
            _characterAnimation = GetComponent<CharacterAnimation>();
            _flip = GetComponent<Flip>();
            _onGround = GetComponent<OnGround>();
            _climbing = GetComponent<Climbing>();
            _health = GetComponent<Health>();
            _damage = GetComponent<Damage>();
            _audioSource = GetComponent<AudioSource>();
            _input = new PcInput();
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if (gameCanvas != null)
            {
                _health.OnDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _health.OnHealthChanged += displayHealth.WriteHealth;
            }

            _health.OnDead += () => OnPlayerDead.Invoke(deadClip);
            
            _health.OnHealthChanged += PlayOnHit;
        }

        private void FixedUpdate()
        {
            _climbing.ClimbAction(_vertical);
            
            _mover.HorizontalMove(_horizontal);
            
            _flip.FlipCharacter(_horizontal);
            
            if (_isJump)
            {
                _jump.JumpAction();
                _isJump = false;
            }
        }

        private void Update()
        {
            if(_health.IsDead) return;
            
            _horizontal = _input.Horizontal;
            _vertical = _input.Vertical;

            if (_input.IsJumpButtonDown && _onGround.IsOnGround && !_climbing.IsClimbing)
            {
                _isJump = true;
            }
            
            _characterAnimation.MoveAnimation(_horizontal);
            _characterAnimation.JumpAnimation(!_onGround.IsOnGround && _jump.IsJump);
            _characterAnimation.ClimbAnimation(_climbing.IsClimbing);
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Health health = col.ObjectHasHealth();

            if (col.gameObject.CompareTag("Enemy"))
            {
                if (health != null && col.WasHitTopSide())
                {
                    health.TakeHit(_damage);
                
                    _jump.JumpAction();
                }
            }
        }

        private void PlayOnHit(int currentHealth, int maxHealth)
        {
            if(currentHealth == maxHealth) return;
            
            _audioSource.Play();
        }
    }
}

