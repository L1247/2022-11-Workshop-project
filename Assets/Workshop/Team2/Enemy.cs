using FSM;
using Workshop.Team2;

public enum NPCState
{
    Chase,
}

public class Enemy : Character
{
    private StateMachine<NPCState> fsm;

    void Start()
    {
        fsm = new StateMachine<NPCState>();
        fsm.AddState(NPCState.Chase, new Chase(this,Player.instance));
        fsm.SetStartState(NPCState.Chase);
        fsm.Init();
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnLogic();
    }

   
}