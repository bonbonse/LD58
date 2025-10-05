using Ludum.Character;
using Ludum.Manager;
using UnityEngine;

namespace Ludum.GameState
{
    public class FreeMovementState : IGameState
    {
        private Player player;
        private Camera playerCamera;

        public void Enter()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
            playerCamera = Camera.main;

            // Настраиваем курсор для свободного обзора
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void LogicUpdate()
        {
            player.LogicUpdate();
        }

        public void PhysicalUpdate()
        {
            player.PhysicalUpdate();
        }

        public void Exit()
        {
        }

        private void TryInteract()
        {
            //// Логика взаимодействия с объектами
            //RaycastHit hit;
            //if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit, 3f))
            //{
            //    IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            //    interactable?.Interact();
            //}
        }
    }
}

