using FSM;
using UnityEngine;

class Death : State<Monster.State> {
    GameObject _self;
    public Death(GameObject gameObject) => _self = gameObject;

    public override void OnEnter() {
        base.OnEnter();
        Object.Destroy(_self);
    }
}
