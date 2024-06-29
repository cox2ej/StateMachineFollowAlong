// MoveState.cs
using UnityEngine;

public class MoveState : BaseState
{
    private float moveSpeed;

    public MoveState(GameObject owner, float moveSpeed) : base(owner)
    {
        this.moveSpeed = moveSpeed;
    }

    public override void Enter()
    {
        Debug.Log("Entering Move State");
    }

    public override void Execute()
    {
        // Logic for moving the player based on input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = owner.transform.right * moveX + owner.transform.forward * moveZ;
        owner.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // If no input is given, switch to idle state
        if (moveX == 0 && moveZ == 0)
        {
            owner.GetComponent<StateMachine>().ChangeState(new IdleState(owner));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Move State");
    }
}
