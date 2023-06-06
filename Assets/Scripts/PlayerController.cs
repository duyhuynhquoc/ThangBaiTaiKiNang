using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public Character character;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        character.SetPlayerInput(playerInput);
    }
}
