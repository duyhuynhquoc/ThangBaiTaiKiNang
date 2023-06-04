using UnityEngine;

public class WhiteBear_Slash : State
{
    public WhiteBear_Slash(PlayerInput _playerInput)
        : base(_playerInput)
    {
        duration = 1f;
    }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        Debug.Log("Slash!!!");
        animator.SetTrigger("Slash");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedTime >= duration)
        {
            stateMachine.SwitchToIdleState();
        }
    }

    public override void OnHit()
    {
        Collider2D[] slashHitBoxResults = new Collider2D[10];

        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;

        stateMachine.slashHitBox.OverlapCollider(filter, slashHitBoxResults);

        foreach (Collider2D collider in slashHitBoxResults)
        {
            if (collider == null)
            {
                continue;
            }

            if (collider.gameObject.CompareTag("Player2"))
            {
                Debug.Log("Hit Enemy!!!");
            }
        }
    }
}
