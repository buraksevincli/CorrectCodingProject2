using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Climbing : MonoBehaviour
    {
        [SerializeField] private float climbSpeed = 5f;

        private Rigidbody2D _rigidbody2D;
        public Rigidbody2D Rigidbody2D => _rigidbody2D;
        public bool IsClimbing { get; set; }

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void ClimbAction(float direction)
        {
            if (IsClimbing)
            {
                transform.Translate(Vector2.up * (direction * Time.deltaTime * climbSpeed));
            }
        }
    }
}

