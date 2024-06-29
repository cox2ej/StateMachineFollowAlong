using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IState.cs
public interface IState
{
    void Enter();
    void Execute();
    void Exit();
}

