// IdleState.cs
using UnityEngine;

public class IdleState : BaseState
{
    public IdleState(GameObject owner) : base(owner) { }

    public override void Enter()
    {
        Debug.Log("Entering Idle State");
    }

    public override void Execute()
    {
        // Logic for idle state
    }

    public override void Exit()
    {
        Debug.Log("Exiting Idle State");
    }
}