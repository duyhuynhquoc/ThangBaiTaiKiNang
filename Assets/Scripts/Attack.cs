using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;

    public bool IsAttacking { get; set; } = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack0()
    {
        animator.SetTrigger("attack0");

        StartCoroutine(Attack0());
    }

    IEnumerator Attack0()
    {
        IsAttacking = true;

        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        IsAttacking = false;
    }
}
