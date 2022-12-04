#region

using FSM;
using GameJam.Core;
using UnityEngine;

#endregion

public class Monster1 : MonoBehaviour
{
#region Public Variables

    public IUnityComponent UnityComponent { get; private set; }

#endregion

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
        SetUnityComponent(new UnityComponent(animator));
        var chasing = "Chasing";
        fsm = new StateMachine<string>();
        // fsm.AddState(chasing , new Chasing(this , moveSpeed));
        fsm.AddState(chasing , new Chasing(this));
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

    public Transform GetTarget()
    {
        return target;
    }

    public void PlayAnimation(string animationName)
    {
        UnityComponent.PlayAnimation(animationName);
    }

    public void SetFacing(Facing facing)
    {
        if (facing == Facing.None) return;
        this.facing = facing;
        var facingValue = facing == Facing.Right ? 1 : -1;
        transform.localScale = new Vector3(facingValue , 1 , 1);
    }

    public void SetPos(Vector3 pos)
    {
        transform.position = pos;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetUnityComponent(IUnityComponent unityComponent)
    {
        UnityComponent = unityComponent;
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        this.moveSpeed = moveSpeed;
    }

    public float GetMoveSpeed() => moveSpeed;

    #endregion
}