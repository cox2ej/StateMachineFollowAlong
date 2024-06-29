using UnityEngine;

public class FirstPersonCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float gravity = 9.81f;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;

    private float xRotation = 0f;
    private Rigidbody rb;
    private bool isGrounded;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = playerBody.GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        LookAround();
        Move();
        Jump();
        GroundCheck();
    }

    private void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        Vector3 newPosition = rb.position + moveDirection * moveSpeed * Time.deltaTime;

        rb.MovePosition(newPosition);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void GroundCheck()
    {
        isGrounded = Physics.Raycast(playerBody.position, Vector3.down, groundCheckDistance, groundMask);
    }

    private void FixedUpdate()
    {
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * gravity * rb.mass);
        }
    }
}
