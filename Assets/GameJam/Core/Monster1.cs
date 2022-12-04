#region

using FSM;
using GameJam.Core;
using GameJam.Core.States;
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

    [SerializeField]
    private int health;

#endregion

#region Unity events

    // Start is called before the first frame update
    private void Start()
    {
        SetUnityComponent(new UnityComponent(animator));
        var chasing = "Chasing";
        var death   = "Death";
        fsm = new StateMachine<string>();
        fsm.AddState(chasing , new Chasing(this));
        fsm.AddState(death , new Death(this));
        fsm.AddTransitionFromAny(death , _ => health <= 0);
        fsm.AddTransition(chasing , death , _ => health > 0);
        fsm.AddTransition(death , chasing , _ => health > 0);
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

    public string GetCurrentStateTypeName()
    {
        return fsm.ActiveState.GetType().Name;
    }

    public Facing GetFacing()
    {
        return facing;
    }

    public float GetMoveSpeed() => moveSpeed;

    public Vector3 GetPos()
    {
        return transform.position;
    }

    public string GetStateTypeName(string key)
    {
        var state = fsm.GetState(key);
        return state.GetType().Name;
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

    public void SetHealth(int value)
    {
        health = value;
    }

    public void SetMoveSpeed(float value)
    {
        moveSpeed = value;
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

#endregion
}