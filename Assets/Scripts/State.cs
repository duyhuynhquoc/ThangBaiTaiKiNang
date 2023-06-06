using UnityEngine;
using UnityEngine.InputSystem;

public class State : BaseState
{
    protected Animator animator;
    protected Mover mover;

    protected PlayerInput playerInput;

    protected float duration = 0f;
    protected float comboWaitTime = 2f;

    public State(PlayerInput _playerInput)
    {
        playerInput = _playerInput;
    }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        animator = GetComponent<Animator>();
        mover = GetComponent<Mover>();
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        comboWaitTime = Mathf.Max(0f, comboWaitTime - Time.deltaTime);
    }

    public virtual void OnHit() { }
}
