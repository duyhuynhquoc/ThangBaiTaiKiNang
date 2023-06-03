using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;

    private Mover movement;
    private StateMachine stateMachine;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        movement = GetComponent<Mover>();
        stateMachine = GetComponent<StateMachine>();

        stateMachine.SetPlayerInput(playerInput);
        stateMachine.SwitchToIdleState();
    }

    // private void FixedUpdate()
    // {
    //     if (TryAttack0())
    //     {
    //         return;
    //     }

    //     if (TryMove())
    //     {
    //         return;
    //     }
    // }

    // bool TryMove()
    // {
    //     if (attack.IsAttacking)
    //     {
    //         return false;
    //     }

    //     float movementInput = input.Player.Move.ReadValue<float>();

    //     movement.Move(movementInput);

    //     return movementInput != 0f;
    // }

    // private bool TryAttack0()
    // {
    //     if (attack.IsAttacking)
    //     {
    //         return false;
    //     }

    //     movement.StopMovement();

    //     float attackInput = input.Player.Attack0.ReadValue<float>();

    //     if (attackInput == 0f)
    //     {
    //         return false;
    //     }

    //     attack.StartAttack0();

    //     return true;
    // }
}
