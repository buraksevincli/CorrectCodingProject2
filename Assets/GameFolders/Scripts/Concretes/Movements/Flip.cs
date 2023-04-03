using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Concretes.Movements
{
    public class Flip : MonoBehaviour
    {
        public void FlipCharacter(float horizontal)
        {
            if (horizontal != 0)
            {
                float mathfValue = Mathf.Sign(horizontal);
            
                if(transform.localScale.x == horizontal) return;

                transform.localScale = new Vector2(mathfValue, 1f);
            }
        }
    }
}

