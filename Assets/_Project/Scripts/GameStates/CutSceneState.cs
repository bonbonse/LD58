using UnityEngine;
using System.Collections;
using Ludum.GameState;
using Ludum.Manager;

namespace Ludum.GameState
{
    public class CutsceneState : IGameState
    {
        //private CutsceneManager cutsceneManager;

        public void Enter()
        {
            //cutsceneManager = CutsceneManager.Instance;

            //// Блокируем управление игроком
            //Cursor.lockState = CursorLockMode.None;
            //Cursor.visible = true;

            //// Останавливаем время игры если нужно
            //// Time.timeScale = 0f;

            //// Запускаем катсцену
            //if (cutsceneManager != null)
            //{
            //    cutsceneManager.StartCutscene();
            //    cutsceneManager.OnCutsceneEnded += OnCutsceneEnded;
            //}

            Debug.Log("Entered Cutscene State");
        }

        public void LogicUpdate()
        {
            // Проверяем возможность пропуска катсцены
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Escape))
            {
                SkipCutscene();
            }
        }

        public void PhysicalUpdate()
        {
            // В катсцене обрабатываем только специфичные inputs
        }

        public void Exit()
        {
            //if (cutsceneManager != null)
            //{
            //    cutsceneManager.OnCutsceneEnded -= OnCutsceneEnded;
            //}

            // Восстанавливаем нормальное время
            Time.timeScale = 1f;

            Debug.Log("Exited Cutscene State");
        }

        private void SkipCutscene()
        {
            //cutsceneManager?.SkipCutscene();
        }

        private void OnCutsceneEnded()
        {
            // Переходим в свободное передвижение после катсцены
            GameStateManager.Instance.ChangeState(
                GameStateManager.Instance.freeMovementState
            );
        }
    }
}
