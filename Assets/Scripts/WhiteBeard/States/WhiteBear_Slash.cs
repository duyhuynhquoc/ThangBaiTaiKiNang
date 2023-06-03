using UnityEngine;

public class WhiteBear_Slash : State
{
    public WhiteBear_Slash(PlayerInput _playerInput)
        : base(_playerInput)
    {
        duration = 1f;
    }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        Debug.Log("Slash!!!");
        animator.SetTrigger("Slash");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedTime >= duration)
        {
            stateMachine.SwitchToIdleState();
        }
    }
}
