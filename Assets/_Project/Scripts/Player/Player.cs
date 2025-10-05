using UnityEngine;
using System;

namespace Ludum.Character
{
    public class Player : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] float walkSpeed = 5f;

        [Header("Mouse Look Settings")]
        [SerializeField] float mouseSensitivity = 2f;
        [SerializeField] float maxLookUpAngle = 80f;
        [SerializeField] float maxLookDownAngle = 80f;

        [Header("References")]
        [SerializeField] Transform playerCamera;
        [SerializeField] Rigidbody playerRigidbody;

        private float speed;
		private float xRotation = 0f;
        private Vector3 moveDirection;

        // Input
        private float mouseX, mouseY;
        private float horizontal, vertical;

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
        }

        public void LogicUpdate()
        {
            GetInput();
            HandleMouseLook();
        }
        public void PhysicalUpdate()
        {
            HandleMovement();
        }

        void GetInput()
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");

            moveDirection = (transform.right * horizontal + transform.forward * vertical).normalized;

        }

        void HandleMouseLook()
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -maxLookDownAngle, maxLookUpAngle);
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }

        void HandleMovement()
        {
			speed = walkSpeed;
			if (Math.Abs(Vector3.Angle(moveDirection, Vector3.forward)) > 90) {
				speed *= 0.8f;
			};
			
			transform.position += moveDirection * speed;
        }

        public void SetMouseSensitivity(float sensitivity)
        {
            mouseSensitivity = sensitivity;
        }

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

        void Reset()
        {
            if (playerCamera == null)
            {
                playerCamera = GetComponentInChildren<Camera>()?.transform;
            }

            if (playerRigidbody == null)
            {
                playerRigidbody = GetComponent<Rigidbody>();
            }
        }
    }
}
