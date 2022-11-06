using FSM;
using UnityEngine;

sealed class Chase : State<Monster.State> {
    Transform _self;
    SpriteRenderer _spriteRenderer;
    Animator _animator;
    float _speed;

    Transform _player;

    public Chase(Transform self, SpriteRenderer spriteRenderer, Animator animator, float speed) {
        _self = self;
        _spriteRenderer = spriteRenderer;
        _animator = animator;
        _speed = speed;
    }

    public override void OnEnter() {
        base.OnEnter();
        _animator.Play("Walk");
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public override void OnLogic() {
        base.OnLogic();
        FaceToPlayer();
        MoveToPlayer();
    }

     void FaceToPlayer() => _spriteRenderer.flipX = _self.position.x > _player.position.x;

    void MoveToPlayer() =>
        _self.position = Vector3.Lerp(_self.position, _player.position, _speed * Time.deltaTime);
}
