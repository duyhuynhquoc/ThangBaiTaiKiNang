using UnityEngine;
using UnityEngine.InputSystem;

public class WhiteBeard_Jump : State
{
    public WhiteBeard_Jump(PlayerInput _playerInput)
        : base(_playerInput) { }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        Debug.Log("Jump");

        animator.SetBool("IsJumping", true);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        float movementInput = playerInput.actions.FindAction("Move").ReadValue<float>();

        mover.Move(movementInput, false, true);
    }
}
