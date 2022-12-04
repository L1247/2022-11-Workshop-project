#region

using FSM;
using UnityEngine;

#endregion

namespace GameJam.Core.States
{
    public class Death : State<string>
    {
        private readonly Monster1 monsterA;

        public Death(Monster1 monsterA)
        {
            this.monsterA = monsterA;
        }

        public override void OnEnter()
        {
            GameObject.DestroyImmediate(monsterA.gameObject);
        }
    }
}