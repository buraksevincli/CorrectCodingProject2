using System;
using System.Collections;
using System.Collections.Generic;
using GameFolders.Scripts.Concretes.Combats;
using GameFolders.Scripts.Concretes.ExtensionMethods;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Controllers
{
    public class DeadZoneController : MonoBehaviour
    {
        private Damage _damage;

        private void Awake()
        {
            _damage = GetComponent<Damage>();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            Health health = col.ObjectHasHealth();

            if (health != null)
            {
                health.TakeHit(_damage);
                health.ReturnCheckPoint();
            }
        }
    }

}
