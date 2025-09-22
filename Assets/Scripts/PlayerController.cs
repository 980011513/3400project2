using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float mouseSensitivity = 100f;
    public Transform playerCamera;

    private CharacterController characterController;
    private float verticalSpeed = 0f;
    private float gravity = -9.81f;
    private float cameraPitch = 0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked; // Locks the cursor to the center of the screen
    }

    void Update()
    {
        MovePlayer();
        RotateCamera();
    }

    void MovePlayer()
    {
        float speed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        verticalSpeed += gravity * Time.deltaTime;

        Vector3 velocity = move * speed + Vector3.up * verticalSpeed;
        characterController.Move(velocity * Time.deltaTime);

        if (characterController.isGrounded && verticalSpeed < 0)
        {
            verticalSpeed = -2f; // Keeps the player grounded
        }
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        cameraPitch -= mouseY;
        cameraPitch = Mathf.Clamp(cameraPitch, -90f, 90f); // Prevents over-rotation

        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }
}

