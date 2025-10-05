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
        [SerializeField] Transform playerCameraTransform;
        [SerializeField] Rigidbody playerRigidbody;
		
		[Header("Footsteps")]
		[SerializeField] AudioClip[] steps;
		[SerializeField] AudioSource audioSource;
		[SerializeField] float stepRate = 0.5f;
		float stepTimer;
		
        private float speed;
		private float xRotation = 0f;
        private Vector3 moveDirection;
        private float mouseX, mouseY;
        private float horizontal, vertical;

        void Start()
        {
            stepTimer = stepRate;
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

            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            moveDirection = (transform.right * horizontal + transform.forward * vertical).normalized;

        }

        void HandleMouseLook()
        {
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -maxLookDownAngle, maxLookUpAngle);
            playerCameraTransform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

            transform.Rotate(Vector3.up * mouseX);
        }

        void HandleMovement()
        {
			speed = walkSpeed;
			if (Math.Abs(Vector3.Angle(moveDirection, Vector3.forward)) > 90) {
				speed *= 0.8f;
			};

			
			playerRigidbody.linearVelocity = moveDirection * speed;
			
			if (moveDirection != Vector3.zero){
				stepTimer -= Time.fixedDeltaTime;
				if (stepTimer <= 0){
					int i = UnityEngine.Random.Range(0, steps.Length);
					audioSource.PlayOneShot(steps[i]);
					stepTimer = stepRate;
				}
			}
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
            if (playerCameraTransform == null)
            {
                playerCameraTransform = GetComponentInChildren<Camera>()?.transform;
            }

            if (playerRigidbody == null)
            {
                playerRigidbody = GetComponent<Rigidbody>();
            }
        }
    }
}
