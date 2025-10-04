using UnityEngine;

namespace Ludum.Character
{
    public class Player : MonoBehaviour
    {
        [Header("Movement Settings")]
        public float walkSpeed = 5f;
        public float runSpeed = 8f;
        public float jumpForce = 7f;
        public float airControl = 0.5f;

        [Header("Mouse Look Settings")]
        public float mouseSensitivity = 2f;
        public float maxLookUpAngle = 80f;
        public float maxLookDownAngle = 80f;

        [Header("References")]
        public Transform playerCamera;
        public Rigidbody playerRigidbody;

        [Header("Ground Detection")]
        public LayerMask groundLayer = 1;
        public float groundCheckDistance = 0.1f;
        public Transform groundCheckPoint;

        private float xRotation = 0f;
        private bool isGrounded;
        private Vector3 moveDirection;

        // Input
        private float mouseX, mouseY;
        private float horizontal, vertical;
        private bool jumpPressed;
        private bool isRunning;

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if (playerRigidbody == null)
                playerRigidbody = GetComponent<Rigidbody>();

            if (playerRigidbody != null)
            {
                playerRigidbody.freezeRotation = true;
                playerRigidbody.collisionDetectionMode = CollisionDetectionMode.Continuous;
            }

            if (groundCheckPoint == null)
                groundCheckPoint = transform;
        }

        public void LogicUpdate()
        {
            GetInput();
            HandleMouseLook();
            CheckGrounded();
        }
        public void PhysicalUpdate()
        {
            HandleMovement();
            HandleJump();
        }

        void GetInput()
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            isRunning = Input.GetKey(KeyCode.LeftShift);
            jumpPressed = Input.GetButtonDown("Jump");

            moveDirection = transform.right * horizontal + transform.forward * vertical;
        }

        void HandleMouseLook()
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -maxLookDownAngle, maxLookUpAngle);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }

        void CheckGrounded()
        {
            RaycastHit hit;
            isGrounded = Physics.Raycast(groundCheckPoint.position, Vector3.down, out hit, groundCheckDistance, groundLayer);

            Debug.DrawRay(groundCheckPoint.position, Vector3.down * groundCheckDistance, isGrounded ? Color.green : Color.red);
        }

        void HandleMovement()
        {
            if (playerRigidbody == null) return;

            Vector3 currentVelocity = playerRigidbody.linearVelocity;
            Vector3 targetVelocity = moveDirection.normalized * (isRunning ? runSpeed : walkSpeed);

            targetVelocity.y = currentVelocity.y;

            if (isGrounded)
            {
                playerRigidbody.linearVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.fixedDeltaTime * 10f);
            }
            else
            {
                Vector3 airVelocity = new Vector3(targetVelocity.x * airControl, currentVelocity.y, targetVelocity.z * airControl);
                playerRigidbody.linearVelocity = Vector3.Lerp(currentVelocity, airVelocity, Time.fixedDeltaTime * 5f);
            }
        }

        void HandleJump()
        {
            if (jumpPressed && isGrounded && playerRigidbody != null)
            {
                Vector3 velocity = playerRigidbody.linearVelocity;
                velocity.y = 0f;
                playerRigidbody.linearVelocity = velocity;

                playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        public bool IsGrounded()
        {
            return isGrounded;
        }

        public float GetCurrentSpeed()
        {
            if (playerRigidbody == null) return 0f;
            return new Vector3(playerRigidbody.linearVelocity.x, 0f, playerRigidbody.linearVelocity.z).magnitude;
        }

        // ����� ��� ����� ���������������� ����
        public void SetMouseSensitivity(float sensitivity)
        {
            mouseSensitivity = sensitivity;
        }

        // ����� ��� ������������� �������
        public void SetCursorLock(bool locked)
        {
            if (locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        // �������������� ��������� ��� ���������� �������
        void Reset()
        {
            // ������������� ������� ������ ���� ��� ��������
            if (playerCamera == null)
            {
                playerCamera = GetComponentInChildren<Camera>()?.transform;
            }

            // ������������� ������� Rigidbody
            if (playerRigidbody == null)
            {
                playerRigidbody = GetComponent<Rigidbody>();
            }
        }
    }
}
