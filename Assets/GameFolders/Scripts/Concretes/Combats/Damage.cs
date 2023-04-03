using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] private int damage;
        public int HitDamage => damage;
    }
}

