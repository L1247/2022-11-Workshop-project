using System;
using UnityEngine;

namespace Workshop.Team2
{
    public class Player : Character
    {
        public static Player instance;

        private void Awake()
        {
            instance = this;
        }
    }
}