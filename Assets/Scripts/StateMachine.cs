using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;
    public StateObject idleStateObject;

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnUpdate();
        }
    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.OnFixedUpdate();
        }
    }

    public void SwitchToState(State newState)
    {
        if (currentState != null)
        {
            currentState.OnExit();
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }

        Debug.Log(currentState.GetName());
    }

    public void SetIdleStateObject(StateObject idleStateObject)
    {
        this.idleStateObject = idleStateObject;
    }

    public void SwitchToIdleState()
    {
        SwitchToState(new State(idleStateObject, 0f));
    }
}
