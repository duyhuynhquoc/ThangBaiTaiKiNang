using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private StateObject idleState;

    private PlayerInput input;

    private Mover movement;
    private StateMachine stateMachine;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void Start()
    {
        movement = GetComponent<Mover>();
        stateMachine = GetComponent<StateMachine>();

        stateMachine.SetIdleStateObject(idleState);
        stateMachine.SwitchToIdleState();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
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
