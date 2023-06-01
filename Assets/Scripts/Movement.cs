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

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
        animator.SetFloat("movementSpeed", Mathf.Abs(velocity.x * speed));
    }

    public void Move()
    {
        transform.position += velocity * speed * Time.deltaTime;

        if (velocity.x < 0f)
        {
            RotateLeft();
        }
        else if (velocity.x > 0f)
        {
            RotateRight();
        }
    }

    private void RotateRight()
    {
        transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
    }

    private void RotateLeft()
    {
        transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
    }

    public void StartMovement(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    public void StopMovement()
    {
        velocity = Vector3.zero;
    }
}
