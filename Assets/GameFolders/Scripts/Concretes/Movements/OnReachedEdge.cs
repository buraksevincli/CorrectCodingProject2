using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class OnReachedEdge : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float distance = 0.1f;

        private Collider2D _collider2D;

        private float _xDirection;

        private void Awake()
        {
            _collider2D = GetComponent<Collider2D>();
            _xDirection = 1f;
        }

        public bool ReachedEdge()
        {
            float x = GetForwardXPosition();
            float y = _collider2D.bounds.min.y;

            Vector2 origin = new Vector2(x, y);

            Debug.DrawRay(origin, Vector2.down * 0.1f, Color.red);

            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, distance, _layerMask);

            if (hit.collider != null) return false;

            SwitchControlDirection();
            return true;
        }

        private float GetForwardXPosition()
        {
            return _xDirection == -1 ? _collider2D.bounds.min.x - 0.1f : _collider2D.bounds.max.x + 0.1f;
        }

        private void SwitchControlDirection()
        {
            _xDirection *= -1;
        }
    }
}

