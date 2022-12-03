#region

using FSM;
using GameJam.Core;
using UnityEngine;

#endregion

public class Monster1 : MonoBehaviour
{
#region Private Variables

    private StateMachine<string> fsm;

    private Facing facing;

    [SerializeField]
    private Animator animator;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private Transform target;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        var chasing = "Chasing";
        fsm = new StateMachine<string>();
        fsm.AddState(chasing , new Chasing(this , target , animator , moveSpeed));
        fsm.SetStartState(chasing);
        fsm.Init();
    }

    // Update is called once per frame
    private void Update()
    {
        fsm.OnLogic();
    }

#endregion

#region Public Methods

    public Facing GetFacing()
    {
        return facing;
    }

    public Vector3 GetPos()
    {
        return transform.position;
    }

    public void SetFacing(Facing facing)
    {
        this.facing = facing;
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

#endregion
}