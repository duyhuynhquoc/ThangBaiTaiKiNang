using UnityEngine;
using UnityEngine.InputSystem;

public class Character : MonoBehaviour
{
    private Mover mover;
    private StateMachine stateMachine;

    [SerializeField]
    private PlayerInput playerInput;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        stateMachine = GetComponent<StateMachine>();
    }

    private void Start()
    {
        stateMachine.SetPlayerInput(playerInput);
    }

    public void SetPlayerInput(PlayerInput _playerInput)
    {
        playerInput = _playerInput;
        Debug.Log(playerInput);
        Debug.Log(stateMachine);
        stateMachine.SetPlayerInput(_playerInput);
        stateMachine.SwitchToIdleState();
    }

    public void OnMove()
    {
        Debug.Log(1);
    }
}
