using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Animations
{
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void MoveAnimation(float horizontal)
        {
            float mathfValue = Mathf.Abs(horizontal);
            
            if (_animator.GetFloat("moveSpeed") == mathfValue) return;
            
            _animator.SetFloat("moveSpeed", mathfValue);
        }

        public void JumpAnimation(bool isJump)
        {
            if (_animator.GetBool("isJump") == isJump) return;

            _animator.SetBool("isJump", isJump);
        }

        public void ClimbAnimation(bool isClimb)
        {
            if (_animator.GetBool("isClimb") == isClimb) return;
            
            _animator.SetBool("isClimb", isClimb);
        }

        public void DyingAnimation()
        {
            _animator.SetTrigger("Dying");
        }
    }
}

