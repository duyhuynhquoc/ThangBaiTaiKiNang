using UnityEngine;
using UnityEngine.InputSystem;

public class GameMaster : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    [SerializeField]
    private GameObject characterPrefab;

    private void Start()
    {
        var player1 = PlayerInput.Instantiate(
            playerPrefab,
            controlScheme: "WASD",
            pairWithDevice: Keyboard.current
        );

        GameObject whiteBeard1 = Instantiate(
            characterPrefab,
            new Vector3(-7.41f, -3.963f, 0),
            Quaternion.identity
        );

        player1.GetComponent<PlayerController>().character = whiteBeard1.GetComponent<Character>();

        player1
            .GetComponent<PlayerController>()
            .character.SetPlayerInput(player1.GetComponent<PlayerInput>());

        var player2 = PlayerInput.Instantiate(
            playerPrefab,
            controlScheme: "ArrowKeys",
            pairWithDevice: Keyboard.current
        );

        GameObject whiteBeard2 = Instantiate(
            characterPrefab,
            new Vector3(7.41f, -3.963f, 0),
            Quaternion.identity
        );

        player2.GetComponent<PlayerController>().character = whiteBeard2.GetComponent<Character>();

        player2
            .GetComponent<PlayerController>()
            .character.SetPlayerInput(player2.GetComponent<PlayerInput>());
    }
}
