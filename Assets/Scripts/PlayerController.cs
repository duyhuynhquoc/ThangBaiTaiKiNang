using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInput input;

    private Movement movement;
    private Attack attack;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void Start()
    {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }

    private void Update()
    {
        if (TryAttack0())
        {
            return;
        }

        if (TryMove())
        {
            return;
        }
    }

    bool TryMove()
    {
        if (attack.IsAttacking)
        {
            return false;
        }

        float movementInput = input.Player.Move.ReadValue<float>();

        if (movementInput == 0f)
        {
            return false;
        }

        Vector3 velocity = new Vector3(movementInput, 0f, 0f);
        movement.StartMovement(velocity);

        return true;
    }

    private bool TryAttack0()
    {
        if (attack.IsAttacking)
        {
            return false;
        }

        movement.StopMovement();

        float attackInput = input.Player.Attack0.ReadValue<float>();

        if (attackInput == 0f)
        {
            return false;
        }

        attack.StartAttack0();

        return true;
    }
}
