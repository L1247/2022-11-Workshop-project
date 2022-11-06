using FSM;
using UnityEngine;

sealed class ChaseState : State<Monster.State> {
    Transform _self;
    Transform _player;
    float _speed;

    public ChaseState(Transform self, float speed) {
        _speed = speed;
        _self = self;
    }

    public override void OnEnter() {
        base.OnEnter();
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnLogic() {
        base.OnLogic();
        FaceToPlayer();
        MoveToPlayer();
    }

    void FaceToPlayer() { }

    void MoveToPlayer() =>
        _self.position = Vector3.Lerp(_self.position, _player.position, _speed * Time.deltaTime);

}
