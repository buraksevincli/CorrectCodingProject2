using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class CheckpointController : MonoBehaviour
    {
        private bool _isPassed = false;

        public bool IsPassed => _isPassed;

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.GetComponent<PlayerController>() != null)
            {
                _isPassed = true;
            }
        }
    }
}

