using UnityEngine;
using UnityEngine.InputSystem;

public class WhiteBeard_Idle : State
{
    public WhiteBeard_Idle(PlayerInput _playerInput)
        : base(_playerInput) { }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        Debug.Log("Idle");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        float attackInput = playerInput.actions.FindAction("Action1").ReadValue<float>();

        if (attackInput != 0f)
        {
            stateMachine.SwitchToState(new WhiteBeard_Slash(playerInput));
            return;
        }

        float movementInput = playerInput.actions.FindAction("Move").ReadValue<float>();

        if (movementInput != 0f)
        {
            stateMachine.SwitchToState(new WhiteBeard_Walk(playerInput));
            return;
        }

        float jumpInput = playerInput.actions.FindAction("Jump").ReadValue<float>();

        if (jumpInput != 0f)
        {
            stateMachine.SwitchToState(new WhiteBeard_Jump(playerInput));
            return;
        }
    }
}
