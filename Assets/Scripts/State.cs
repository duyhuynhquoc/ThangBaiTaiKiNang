using UnityEngine;

public class State : BaseState
{
    protected Animator animator;
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
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        comboWaitTime = Mathf.Max(0f, comboWaitTime - Time.deltaTime);
    }
}
