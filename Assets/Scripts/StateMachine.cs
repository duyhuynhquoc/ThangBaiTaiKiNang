using UnityEngine;
using UnityEngine.InputSystem;

public class StateMachine : MonoBehaviour
{
    [SerializeField]
    public Collider2D slashHitBox;

    public State currentState;

    [SerializeField]
    private PlayerInput playerInput;
    protected Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SetPlayerInput(PlayerInput _playerInput)
    {
        playerInput = _playerInput;
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.OnFixedUpdate();
        }
    }

    public void SwitchToState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void SwitchToIdleState()
    {
        SwitchToState(new WhiteBeard_Idle(playerInput));
    }

    public void Hit()
    {
        currentState.OnHit();
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        Debug.Log("Landing");
        SwitchToIdleState();
    }
}
