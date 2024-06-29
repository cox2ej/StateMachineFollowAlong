// StateMachine.cs
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;

    public IState CurrentState => currentState;

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.Exit();
        }
        currentState = newState;
        currentState.Enter();
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute();
        }
    }
}
