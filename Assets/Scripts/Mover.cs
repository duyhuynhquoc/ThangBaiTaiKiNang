using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 50f;

    [SerializeField]
    private float m_MovementSmoothing = 0.05f;

    private Rigidbody2D m_Rigidbody2D;
    private Animator m_Animator;
    private Vector3 m_Velocity = Vector3.zero;
    private bool m_FacingRight = true;

    private void Start()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update() { }

    public void Move(float movement)
    {
        Vector3 targetVelocity = new Vector2(
            movement * 10f * m_Speed * Time.deltaTime,
            m_Rigidbody2D.velocity.y
        );

        Debug.Log(m_Velocity);

        m_Rigidbody2D.velocity = Vector3.SmoothDamp(
            m_Rigidbody2D.velocity,
            targetVelocity,
            ref m_Velocity,
            m_MovementSmoothing
        );

        if (movement > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (movement < 0 && m_FacingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void StartMovement(float movement) { }

    public void StopMovement()
    {
        m_Velocity = Vector3.zero;
    }
}
