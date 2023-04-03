using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameFolders.Scripts.Abstracts.Inputs
{
    public interface IPlayerInput
    {
        public float Horizontal { get; }
        public float Vertical { get; }
        public bool IsJumpButtonDown { get; }
    }
}

