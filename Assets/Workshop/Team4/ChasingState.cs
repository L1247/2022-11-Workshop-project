using FSM;

internal class ChasingState : State<StateTypes>
{
    private CharacterData _characterData;
    public ChasingState(CharacterData characterData)
    {
        _characterData = characterData;
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnLogic()
    {
        base.OnLogic();
        
        // if(_characterData.IsAlive && _characterData.IsPlayerInEngageRange && !_characterData.IsPlayerInAttackRange && _characterData.IsPlayerInSafeRange && _characterData.IsAttackCooldown)
            
    }
}