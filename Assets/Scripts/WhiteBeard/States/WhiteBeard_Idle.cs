using UnityEngine;

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

        // float attackInput = playerInput.Player.Attack0.ReadValue<float>();

        // if (attackInput != 0f)
        // {
        //     stateMachine.SwitchToState(new WhiteBear_Slash(playerInput));
        // }

        float movementInput = playerInput.Player.Move.ReadValue<float>();

        if (movementInput != 0f)
        {
            stateMachine.SwitchToState(new WhiteBeard_Walk(playerInput));
        }
    }
}
