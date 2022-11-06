#region

using FSM;
using UnityEngine;

#endregion

public class Monster1 : MonoBehaviour
{
#region Private Variables

    private StateMachine<string> fsm;

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
        fsm.AddState(chasing , new Chasing(transform , target , animator , moveSpeed));
        fsm.SetStartState(chasing);
        fsm.Init();
    }

#endregion

#region Private Methods

    // Update is called once per frame
    private void Update()
    {
        fsm.OnLogic();
    }

#endregion
}