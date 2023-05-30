using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private Animator animator;

    private PlayerInput input;
    private Vector3 movement;

    private void Awake()
    {
        input = new PlayerInput();
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        input.Enable();

        input.Player.Move.performed += OnMovePerformed;
        input.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        Move();
        UpdateAnimation();
    }

    void OnMovePerformed(InputAction.CallbackContext context)
    {
        float moveInput = context.ReadValue<float>();
        movement = new Vector3(moveInput, 0f, 0f);

        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("movementSpeed", Mathf.Abs(movement.x * speed));
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        float moveInput = 0f;
        movement = new Vector3(moveInput, 0f, 0f);
    }

    void Move()
    {
        transform.position += movement * speed * Time.deltaTime;
        float rotationY = movement.x >= 0 ? 0 : 180f;
        transform.rotation = new Quaternion(0f, rotationY, 0f, 0f);
    }
}
