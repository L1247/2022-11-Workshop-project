using System;
using UnityEngine;

namespace Workshop.Team2
{
    public class Player : MonoBehaviour
    {
        public static Player instance;

        private void Awake()
        {
            instance = this;
        }
    }
}