// FiringState.cs
using UnityEngine;
using System.Collections;

public class FiringState : BaseState
{
    private CharacterController3D playerController;
    private float delayBeforeExit = 5f; // Adjust this value as needed

    public FiringState(GameObject owner) : base(owner)
    {
        playerController = owner.GetComponent<CharacterController3D>();
    }

    public override void Enter()
    {
        Debug.Log("Entering Firing State");
        owner.GetComponent<MonoBehaviour>().StartCoroutine(WaitAndExitState());
    }

    public override void Execute()
    {
        // Nothing to do here since the state will change after the delay
    }

    public override void Exit()
    {
        Debug.Log("Exiting Firing State");
    }

    private IEnumerator WaitAndExitState()
    {
        yield return new WaitForSeconds(delayBeforeExit);

        // Switch back to Idle or Move state
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            owner.GetComponent<StateMachine>().ChangeState(new MoveState(owner, playerController.moveSpeed));
        }
        else
        {
            owner.GetComponent<StateMachine>().ChangeState(new IdleState(owner));
        }
    }
}
