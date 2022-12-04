#region

using FSM;
using UnityEngine;

#endregion

namespace GameJam.Core.States
{
    public class Death : State<string>
    {
    #region Private Variables

        private readonly Monster1 monsterA;

    #endregion

    #region Constructor

        public Death(Monster1 monsterA)
        {
            this.monsterA = monsterA;
        }

    #endregion

    #region Public Methods

        public override void OnEnter()
        {
            Object.DestroyImmediate(monsterA.gameObject);
        }

    #endregion
    }
}