using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.UIs
{
    public class DisplayHealth : MonoBehaviour
    {
        private TextMeshProUGUI _healthText;

        private void Awake()
        {
            _healthText = GetComponent<TextMeshProUGUI>();
        }

        public void WriteHealth(int currentHelath, int maxHealth)
        {
            _healthText.text = currentHelath.ToString();
        }
    }
}

