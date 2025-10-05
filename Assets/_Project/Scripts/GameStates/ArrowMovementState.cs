using Ludum.Character;
using Ludum.GameState;
using Ludum.Manager;
using UnityEngine;

namespace Ludum.GameState 
{
    public class ArrowMovementState : IGameState
    {
        private Player playerController;

        public void Enter()
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

            // Настраиваем курсор
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        public void LogicUpdate()
        {
            
        }

        public void PhysicalUpdate()
        {
            
        }

        public void Exit()
        {
            

            Debug.Log("Exited Arrow Movement State");
        }
    }
}
