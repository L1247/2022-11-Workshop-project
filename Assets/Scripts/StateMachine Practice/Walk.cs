#region

using FSM;
using UnityEngine;

#endregion

class Walk : State<NPCState>
{
#region Events

    public override void OnEnter()
    {
        base.OnEnter();
        Debug.Log("Walk");
    }

#endregion
}