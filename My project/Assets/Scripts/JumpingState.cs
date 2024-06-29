// JumpingState.cs
using UnityEngine;

public class JumpingState : BaseState
{
    private float jumpForce;

    public JumpingState(GameObject owner, float jumpForce) : base(owner)
    {
        this.jumpForce = jumpForce;
    }

    public override void Enter()
    {
        Debug.Log("Entering Jumping State");
        Jump();
    }

    public override void Execute()
    {
        // Immediately switch to Idle or Move state after jumping
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            owner.GetComponent<StateMachine>().ChangeState(new MoveState(owner, owner.GetComponent<CharacterController3D>().moveSpeed));
        }
        else
        {
            owner.GetComponent<StateMachine>().ChangeState(new IdleState(owner));
        }
    }

    public override void Exit()
    {
        Debug.Log("Exiting Jumping State");
    }

    private void Jump()
    {
        Rigidbody rb = owner.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
