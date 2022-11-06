using FSM;
using Workshop.Team2;

public enum NPCState
{
    Chase,
}

public class Enemy : Character
{
    public float _Speed = 1;
    public float Speed { get; set; }
    private StateMachine<NPCState> fsm;

    void Start()
    {
        Speed = _Speed;
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