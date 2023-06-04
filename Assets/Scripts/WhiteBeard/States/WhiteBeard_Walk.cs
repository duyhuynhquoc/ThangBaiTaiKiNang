using UnityEngine;

public class WhiteBeard_Walk : State
{
    public WhiteBeard_Walk(PlayerInput _playerInput)
        : base(_playerInput) { }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        Debug.Log("Walk");

        animator.SetFloat("MovementSpeed", 10f);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        float attackInput = playerInput.Player.Attack0.ReadValue<float>();

        if (attackInput != 0f)
        {
            animator.SetFloat("MovementSpeed", 0f);
            stateMachine.SwitchToState(new WhiteBeard_Slash(playerInput));
            return;
        }

        float jumpInput = playerInput.Player.Jump.ReadValue<float>();

        if (jumpInput != 0f)
        {
            animator.SetFloat("MovementSpeed", 0f);
            stateMachine.SwitchToState(new WhiteBeard_Jump(playerInput));
            return;
        }

        float movementInput = playerInput.Player.Move.ReadValue<float>();

        mover.Move(movementInput, false, false);

        if (movementInput == 0f)
        {
            animator.SetFloat("MovementSpeed", 0f);
            stateMachine.SwitchToIdleState();
        }
    }
}
