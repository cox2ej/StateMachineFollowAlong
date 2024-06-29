// BaseState.cs
using UnityEngine;

public abstract class BaseState : IState
{
    protected GameObject owner;

    public BaseState(GameObject owner)
    {
        this.owner = owner;
    }

    public abstract void Enter();
    public abstract void Execute();
    public abstract void Exit();
}
