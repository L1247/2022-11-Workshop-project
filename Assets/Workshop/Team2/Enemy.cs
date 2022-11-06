using System.Collections;
using System.Collections.Generic;
using FSM;
using JetBrains.Annotations;
using UnityEngine;
using Workshop.Team2;

enum NPCState
{
    Chase,
}

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    private StateMachine<NPCState> fsm;

    void Start()
    {
        fsm = new StateMachine<NPCState>();
        fsm.AddState(NPCState.Chase, new Chase(gameObject));
        fsm.SetStartState(NPCState.Chase);
        fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnLogic();
    }
}

class Chase : State<NPCState>
{
    private GameObject owner;
    private float speed = 1;

    public Chase(GameObject _Owner) : base()
    {
        owner = _Owner;
    }

    public override void OnLogic()
    {
        MoveTo(Player.instance.transform);
    }

    private void MoveTo(Transform _Target)
    {
        var dir = (_Target.position - owner.transform.position).normalized;
        owner.transform.Translate(dir * speed * Time.deltaTime);
    }
}


