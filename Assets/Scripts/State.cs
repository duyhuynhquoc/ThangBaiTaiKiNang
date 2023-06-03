using System.Collections.Generic;
using UnityEngine;

public class State : BaseState
{
    private StateObject stateObject;
    private Animator animator;
    private List<State> nextStates = new List<State>();
    private float duration = 0f;
    private float comboWaitTime = 1f;

    public string GetName()
    {
        return stateObject.GetName();
    }

    public State(StateObject _stateObject)
    {
        stateObject = _stateObject;
        duration = stateObject.animationClip.length;

        for (int i = 0; i < stateObject.nextStateObjects.Length; i++)
        {
            nextStates.Add(new State(stateObject.nextStateObjects[i]));
        }
    }

    public State(StateObject _stateObject, float _duration)
    {
        stateObject = _stateObject;
        duration = _duration;

        for (int i = 0; i < stateObject.nextStateObjects.Length; i++)
        {
            nextStates.Add(new State(stateObject.nextStateObjects[i]));
        }
    }

    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        animator = GetComponent<Animator>();
        animator.Play(stateObject.GetName());
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (fixedTime >= duration)
        {
            if ((comboWaitTime == 0 && stateObject.name != "Idle") || nextStates.Count == 0)
            {
                stateMachine.SwitchToIdleState();
            }

            comboWaitTime = Mathf.Max(comboWaitTime - Time.deltaTime, 0f);

            for (int i = 0; i < nextStates.Count; i++)
            {
                bool nextStateTriggered =
                    nextStates[i].stateObject.inputAction.action.ReadValue<float>() != 0;

                if (nextStateTriggered)
                {
                    stateMachine.SwitchToState(nextStates[i]);
                    return;
                }
            }
        }
    }
}
